package com.hassanihsan.ocrspace_api


import android.app.Activity
import android.content.Intent
import android.net.Uri
import android.os.Bundle
import android.provider.MediaStore
import android.widget.TextView
import android.widget.Toast
import androidx.activity.result.contract.ActivityResultContracts
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import kotlinx.coroutines.launch


class MainActivity : AppCompatActivity(), IOCRCallBack {
    private val mAPiKey = "helloworld" //TODO Add your own Registered API key

    private var isOverlayRequired = false
    private var mImageUrl: String? = null
    private var mLanguage: String? = null
    private var mTxtResult: TextView? = null
    private var mIOCRCallBack: IOCRCallBack? = null

    private val pickImage = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) { result ->
        if (result.resultCode == Activity.RESULT_OK) {
            val selectedImageUri = result.data?.data
            if (selectedImageUri != null) {
                // Use lifecycleScope.launch to launch a coroutine
                lifecycleScope.launch {
                    // Call the recognizeImage function in the coroutine
                    recognizeImage(selectedImageUri)
                }
            } else {
                Toast.makeText(this, "Failed to retrieve selected image", Toast.LENGTH_SHORT).show()
            }
        }
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        mIOCRCallBack = this
        mImageUrl =
            "http://dl.a9t9.com/blog/ocr-online/screenshot.jpg" // Image url to apply OCR API

        mLanguage = "eng" //Language

        isOverlayRequired = true
        init()
    }

    private fun init() {
        mTxtResult = findViewById(R.id.actual_result) as TextView
        val btnSelectImage = findViewById(R.id.btn_select_image) as TextView
        val btnCallAPI = findViewById(R.id.btn_call_api) as TextView

        btnSelectImage?.setOnClickListener {
            // Open the image picker
            val galleryIntent = Intent(Intent.ACTION_PICK, MediaStore.Images.Media.EXTERNAL_CONTENT_URI)
            pickImage.launch(galleryIntent)
        }

        btnCallAPI?.setOnClickListener {
            // Use lifecycleScope.launch to launch a coroutine
            lifecycleScope.launch {
                // Call the recognizeImage function in the coroutine
                recognizeImage(Uri.parse(mImageUrl)) // Assuming mImageUrl is a String representing the URL or URI of the selected image
            }
        }
    }
    private suspend fun recognizeImage(imageUri: Uri) {
        // Convert imageUri to a file path or handle it accordingly based on your requirements
        val filePath = getPathFromUri(imageUri)

        if (!filePath.isNullOrBlank()) {
            // Call the OCR recognition with the selected image file path
            val result = OCRAsyncTask(
                this@MainActivity, mAPiKey, isOverlayRequired,
                filePath,
                mLanguage!!,
                mIOCRCallBack!!
            ).recognizeImage()

            // Update UI with the result
            mTxtResult?.text = result
        } else {
            Toast.makeText(this, "Failed to retrieve file path from the selected image", Toast.LENGTH_SHORT).show()
        }
    }

    private fun getPathFromUri(uri: Uri): String? {
        val projection = arrayOf(MediaStore.Images.Media.DATA)
        val cursor = contentResolver.query(uri, projection, null, null, null)
        val columnIndex = cursor?.getColumnIndexOrThrow(MediaStore.Images.Media.DATA)
        cursor?.moveToFirst()
        val filePath = columnIndex?.let { cursor?.getString(it) }
        cursor?.close()
        return filePath
    }
    override fun getOCRCallBackResult(response: String?) {
        mTxtResult!!.text = response
    }
}
