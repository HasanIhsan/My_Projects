package com.hassanihsan.takeimageprojectv2

import android.Manifest
import android.app.ProgressDialog
import android.content.Context
import android.content.Intent
import android.content.pm.PackageManager
import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.net.Uri
import android.os.Bundle
import android.os.Environment
import android.os.StrictMode
import android.os.StrictMode.VmPolicy
import android.provider.MediaStore
import android.support.v4.app.ActivityCompat
import android.util.Log
import android.widget.ImageView
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import butterknife.BindView
import butterknife.ButterKnife
import butterknife.OnClick
import java.io.File
import java.io.FileOutputStream
import java.io.IOException
import java.io.OutputStream
import java.text.SimpleDateFormat
import java.util.Date


class MainActivity : AppCompatActivity() {
    private var mProgressDialog: ProgressDialog? = null
    private var mTessOCR: TesseractOCR? = null
    private var context: Context? = null
    protected var mCurrentPhotoPath: String? = null
    private var photoURI1: Uri? = null
    private var oldPhotoURI: Uri? = null


     var firstImage: ImageView? = findViewById(R.id.ocr_image)


    var ocrText: TextView? = findViewById(R.id.ocr_text)
    var PERMISSION_ALL = 1
    var flagPermissions = false
    var PERMISSIONS = arrayOf(
        Manifest.permission.WRITE_EXTERNAL_STORAGE,
        Manifest.permission.CAMERA
    )

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        context = this@MainActivity
        ButterKnife.bind(this)
        val builder = VmPolicy.Builder()
        StrictMode.setVmPolicy(builder.build())
        if (!flagPermissions) {
            checkPermissions()
        }
        val language = "eng"
        mTessOCR = TesseractOCR(this, language)
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)
        when (requestCode) {
            REQUEST_IMAGE1_CAPTURE -> {
                if (resultCode == RESULT_OK) {
                    var bmp: Bitmap? = null
                    try {
                        val `is` = context!!.contentResolver.openInputStream(
                            photoURI1!!
                        )
                        val options = BitmapFactory.Options()
                        bmp = BitmapFactory.decodeStream(`is`, null, options)
                    } catch (ex: Exception) {
                        Log.i(javaClass.simpleName, ex.message!!)
                        Toast.makeText(context, errorConvert, Toast.LENGTH_SHORT).show()
                    }
                    firstImage!!.setImageBitmap(bmp)
                    doOCR(bmp)
                    val os: OutputStream
                    try {
                        os = FileOutputStream(photoURI1!!.path)
                        bmp?.compress(Bitmap.CompressFormat.JPEG, 100, os)
                        os.flush()
                        os.close()
                    } catch (ex: Exception) {
                        Log.e(javaClass.simpleName, ex.message!!)
                        Toast.makeText(context, errorFileCreate, Toast.LENGTH_SHORT).show()
                    }
                } else {
                    run {
                        photoURI1 = oldPhotoURI
                        firstImage!!.setImageURI(photoURI1)
                    }
                }
            }
        }
    }


    fun onClickScanButton() {
        // check permissions
        if (!flagPermissions) {
            checkPermissions()
            return
        }
        //prepare intent
        val takePictureIntent = Intent(MediaStore.ACTION_IMAGE_CAPTURE)
        if (takePictureIntent.resolveActivity(context!!.packageManager) != null) {
            var photoFile: File? = null
            try {
                photoFile = createImageFile()
            } catch (ex: IOException) {
                Toast.makeText(context, errorFileCreate, Toast.LENGTH_SHORT).show()
                Log.i("File error", ex.toString())
            }
            // Continue only if the File was successfully created
            if (photoFile != null) {
                oldPhotoURI = photoURI1
                photoURI1 = Uri.fromFile(photoFile)
                takePictureIntent.putExtra(MediaStore.EXTRA_OUTPUT, photoURI1)
                startActivityForResult(takePictureIntent, REQUEST_IMAGE1_CAPTURE)
            }
        }
    }

    @Throws(IOException::class)
    fun createImageFile(): File {
        // Create an image file name
        val timeStamp = SimpleDateFormat("MMdd_HHmmss").format(Date())
        val imageFileName = "JPEG_" + timeStamp + "_"
        val storageDir = context!!.getExternalFilesDir(Environment.DIRECTORY_PICTURES)
        val image = File.createTempFile(
            imageFileName,  /* prefix */
            ".jpg",  /* suffix */
            storageDir /* directory */
        )
        // Save a file: path for use with ACTION_VIEW intents
        mCurrentPhotoPath = image.absolutePath
        return image
    }

    fun checkPermissions() {
        if (!hasPermissions(context, *PERMISSIONS)) {
            requestPermissions(
                PERMISSIONS,
                PERMISSION_ALL
            )
            flagPermissions = false
        }
        flagPermissions = true
    }

    private fun doOCR(bitmap: Bitmap?) {
        if (mProgressDialog == null) {
            mProgressDialog = ProgressDialog.show(
                this, "Processing",
                "Doing OCR...", true
            )
        } else {
            mProgressDialog!!.show()
        }
        Thread {
            val srcText = mTessOCR!!.getOCRResult(bitmap)
            runOnUiThread {
                if (srcText != null && srcText != "") {
                    ocrText!!.text = srcText
                }
                mProgressDialog!!.dismiss()
            }
        }.start()
    }

    companion object {
        private const val errorFileCreate = "Error file create!"
        private const val errorConvert = "Error convert!"
        private const val REQUEST_IMAGE1_CAPTURE = 1
        fun hasPermissions(context: Context?, vararg permissions: String?): Boolean {
            if (context != null && permissions != null) {
                for (permission in permissions) {
                    if (ActivityCompat.checkSelfPermission(
                            context,
                            permission!!
                        ) != PackageManager.PERMISSION_GRANTED
                    ) {
                        return false
                    }
                }
            }
            return true
        }
    }
}
