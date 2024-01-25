package com.hassanihsan.ocrspace_api

import android.app.Activity
import android.app.ProgressDialog
import android.content.Context
import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.graphics.ImageDecoder
import android.net.Uri
import android.provider.MediaStore
import android.util.Base64
import android.util.Log
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import org.json.JSONObject
import java.io.BufferedReader
import java.io.ByteArrayOutputStream
import java.io.DataOutputStream
import java.io.IOException
import java.io.InputStreamReader
import java.net.URL
import java.net.URLEncoder
import javax.net.ssl.HttpsURLConnection
import kotlin.coroutines.resume
import kotlin.coroutines.suspendCoroutine

class OCRAsyncTask(
    private val context: Context,
    private val mApiKey: String,
    isOverlayRequired: Boolean,
    imageUrl: String,
    language: String,
    private val mIOCRCallBack: IOCRCallBack
) {
    private val url = "https://api.ocr.space/parse/image" // OCR API Endpoints
    private var isOverlayRequired = false
    private val mImageUrl: String
    private val mLanguage: String
    private var mProgressDialog: ProgressDialog? = null

    init {
        this.isOverlayRequired = isOverlayRequired
        mImageUrl = imageUrl
        mLanguage = language
    }

    suspend fun recognizeImage(): String? = withContext(Dispatchers.IO) {
        suspendCoroutine { continuation ->
            try {
                val obj = URL(url)
                val con = obj.openConnection() as HttpsURLConnection

                con.requestMethod = "POST"
                con.setRequestProperty("User-Agent", "Mozilla/5.0")
                con.setRequestProperty("Accept-Language", "en-US,en;q=0.5")
                con.setRequestProperty("Content-Type", "application/json")

              /*  val bitmap = if (mImageUrl.startsWith("http")) {
                    // Remote URL, download the image
                    val imageUrl = URL(mImageUrl)
                    BitmapFactory.decodeStream(imageUrl.openConnection().getInputStream())
                } else {
                    // Local file path
                    getBitmapFromUri(Uri.parse(mImageUrl))

                }*/

              //  var bitmap = getBitmapFromUri(Uri.parse(mImageUrl))
                var bitmap = getBitmapFromAssets(context, "stop.jpg")
                Log.d("ImageURI", "URI: $mImageUrl")
                Log.d("BITMAP", "BITMAP: $bitmap")
                val base64Image = convertBitmapToBase64(bitmap)



                val postDataParams = JSONObject()
                postDataParams.put("apikey", mApiKey)
                postDataParams.put("isOverlayRequired", isOverlayRequired)
                postDataParams.put("base64Image", base64Image)
                postDataParams.put("language", mLanguage)




                con.doOutput = true
                val wr = DataOutputStream(con.outputStream)
                wr.writeBytes(getPostDataString(postDataParams))
                wr.flush()
                wr.close()

                val `in` = BufferedReader(InputStreamReader(con.inputStream))
                var inputLine: String?
                val response = StringBuffer()
                while (`in`.readLine().also { inputLine = it } != null) {
                    response.append(inputLine)
                }
                `in`.close()
                println(response.toString())
                continuation.resume(response.toString())
            } catch (e: Exception) {
                e.printStackTrace()
                continuation.resume(null)
            }
        }
    }
    private fun getBitmapFromAssets(context: Context, fileName: String): Bitmap? {
        return try {
            val inputStream = context.assets.open(fileName)
            BitmapFactory.decodeStream(inputStream)
        } catch (e: IOException) {
            e.printStackTrace()
            Log.e("ImageDecoder", "Error decoding bitmap from assets", e)
            null
        }
    }

    private fun getBitmapFromUri(uri: Uri): Bitmap? {
        return try {
            val inputStream = context.contentResolver.openInputStream(uri)
            BitmapFactory.decodeStream(inputStream)
        } catch (e: IOException) {
            e.printStackTrace()
            Log.e("ImageDecoder", "Error decoding bitmap", e)
            null
        }
    }



    private fun convertBitmapToBase64(bitmap: Bitmap?): String {
        val byteArrayOutputStream = ByteArrayOutputStream()
        bitmap?.compress(Bitmap.CompressFormat.JPEG, 100, byteArrayOutputStream)
        val byteArray = byteArrayOutputStream.toByteArray()
        return Base64.encodeToString(byteArray, Base64.DEFAULT)
    }

    private fun getPostDataString(params: JSONObject): String {
        val result = StringBuilder()
        var first = true
        val itr = params.keys()
        while (itr.hasNext()) {
            val key = itr.next()
            val value = params[key]
            if (first) first = false else result.append("&")
            result.append(URLEncoder.encode(key, "UTF-8"))
            result.append("=")
            result.append(URLEncoder.encode(value.toString(), "UTF-8"))
        }
        println(result.toString())
        return result.toString()
    }
}
