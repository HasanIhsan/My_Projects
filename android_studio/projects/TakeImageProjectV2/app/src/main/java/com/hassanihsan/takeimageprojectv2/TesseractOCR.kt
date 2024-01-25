package com.hassanihsan.takeimageprojectv2

import android.content.ContentValues
import android.content.Context
import android.graphics.Bitmap
import android.util.Log
import android.widget.Toast
import com.googlecode.tesseract.android.TessBaseAPI
import java.io.File
import java.io.FileOutputStream
import java.io.InputStream


class TesseractOCR(context: Context, language: String?) {
    private val mTess: TessBaseAPI?

    init {
        mTess = TessBaseAPI()
        var fileExistFlag = false
        val assetManager = context.assets
        var dstPathDir = "/tesseract/tessdata/"
        val srcFile = "eng.traineddata"
        var inFile: InputStream? = null
        dstPathDir = context.filesDir.toString() + dstPathDir
        val dstInitPathDir = context.filesDir.toString() + "/tesseract"
        val dstPathFile = dstPathDir + srcFile
        var outFile: FileOutputStream? = null
        try {
            inFile = assetManager.open(srcFile)
            val f = File(dstPathDir)
            if (!f.exists()) {
                if (!f.mkdirs()) {
                    Toast.makeText(context, "$srcFile can't be created.", Toast.LENGTH_SHORT).show()
                }
                outFile = FileOutputStream(File(dstPathFile))
            } else {
                fileExistFlag = true
            }
        } catch (ex: Exception) {
            Log.e(ContentValues.TAG, ex.message!!)
        } finally {
            if (fileExistFlag) {
                try {
                    inFile?.close()
                    mTess.init(dstInitPathDir, language)

                } catch (ex: Exception) {
                    Log.e(ContentValues.TAG, ex.message!!)
                }
            }
            if (inFile != null && outFile != null) {
                try {
                    //copy file
                    val buf = ByteArray(1024)
                    var len: Int
                    while (inFile.read(buf).also { len = it } != -1) {
                        outFile.write(buf, 0, len)
                    }
                    inFile.close()
                    outFile.close()
                    mTess.init(dstInitPathDir, language)
                } catch (ex: Exception) {
                    Log.e(ContentValues.TAG, ex.message!!)
                }
            } else {
                Toast.makeText(context, "$srcFile can't be read.", Toast.LENGTH_SHORT).show()
            }
        }
    }

    fun getOCRResult(bitmap: Bitmap?): String {
        mTess!!.setImage(bitmap)
        return mTess.utF8Text
    }

    fun onDestroy() {
        mTess?.end()
    }
}
