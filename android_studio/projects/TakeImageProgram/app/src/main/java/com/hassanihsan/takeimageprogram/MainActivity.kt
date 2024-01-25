package com.hassanihsan.takeimageprogram

import android.Manifest
import android.content.Intent
import android.content.SharedPreferences
import android.content.pm.PackageManager
import android.graphics.Bitmap
import android.os.Bundle
import android.provider.MediaStore
import android.widget.Button
import android.widget.ImageView
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import androidx.core.content.ContextCompat
import android.util.Base64
import android.util.Log
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import java.io.BufferedReader
import java.io.DataOutputStream
import java.io.InputStreamReader
import java.net.HttpURLConnection
import java.net.URL
import org.json.JSONObject
import java.io.ByteArrayOutputStream

class MainActivity : AppCompatActivity() {
    private val CAMERA_REQUEST_CODE = 101
    private val sharedPreferencesKey = "photo_key"

    private lateinit var imgCamera: ImageView
    private lateinit var sharedPreferences: SharedPreferences

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        imgCamera = findViewById(R.id.imgCamera)
        val btnCamera = findViewById<Button>(R.id.btnCamera)

        // Initialize SharedPreferences
        sharedPreferences = getSharedPreferences("MyPrefs", MODE_PRIVATE)

        // Check and request camera permission if not granted
        if (ContextCompat.checkSelfPermission(this, Manifest.permission.CAMERA) != PackageManager.PERMISSION_GRANTED) {
            ActivityCompat.requestPermissions(this, arrayOf(Manifest.permission.CAMERA), CAMERA_REQUEST_CODE)
        }

        btnCamera.setOnClickListener {
            if (ContextCompat.checkSelfPermission(this, Manifest.permission.CAMERA) == PackageManager.PERMISSION_GRANTED) {
                // Open the camera to take a photo
                val cameraIntent = Intent(MediaStore.ACTION_IMAGE_CAPTURE)
                startActivityForResult(cameraIntent, CAMERA_REQUEST_CODE)
            } else {
                // Handle the case where camera permission is not granted
                // You may display a message to the user to grant the permission.
            }
        }
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)

        if (requestCode == CAMERA_REQUEST_CODE && resultCode == RESULT_OK && data != null) {



                // Execute the OCR task using coroutines
               /* GlobalScope.launch {
                    val imageUrl =  "https://dpdajlq3ew794.cloudfront.net/20190618082849/stop-arret-french-sign.jpg?format=auto&width=1080"/* Get the URL from your source */

                    val extractedText = sendUrlToOCRSpace(imageUrl)

                    // Update the UI on the main thread
                    withContext(Dispatchers.Main) {
                        // Display the extracted text in the TextView
                        val textView = findViewById<TextView>(R.id.textView)
                        textView.text = extractedText
                    }
                }*/
            val photo = data.extras?.get("data") as Bitmap

            imgCamera.setImageBitmap(photo)
            // Execute the OCR task using coroutines
            GlobalScope.launch {
                val extractedText = sendImageToOCRSpace(photo)

                // Update the UI on the main thread
                withContext(Dispatchers.Main) {
                    // Display the extracted text in the TextView
                    val textView = findViewById<TextView>(R.id.textView)
                    textView.text = extractedText
                }
            }
        }
    }


    private fun convertBitmapToBase64(bitmap: Bitmap): String {
        val byteArrayOutputStream = ByteArrayOutputStream()
        bitmap.compress(Bitmap.CompressFormat.JPEG, 100, byteArrayOutputStream)
        val byteArray = byteArrayOutputStream.toByteArray()
        return "data:image/jpeg;base64," + Base64.encodeToString(byteArray, Base64.NO_WRAP)
    }

    // Function to send a Bitmap image to OCR.space
    private suspend fun sendImageToOCRSpace(bitmap: Bitmap): String {
        val apiKey = "K84208875088957" // Replace with your actual API key
        val ocrEngineVersion = "3" // Specify the OCR engine version

        // Convert the bitmap to base64
       // val base64Image = convertBitmapToBase64(bitmap)

        var base64Image:String =  "data:image/jpg;base64,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"

        val apiEndpoint = "https://api.ocr.space/parse/image"
        val apiUrl = "$apiEndpoint?apikey=$apiKey&ocrengine=$ocrEngineVersion"


        println(apiUrl)
        try {
            val url = URL(apiUrl)
            val connection = url.openConnection() as HttpURLConnection
            connection.requestMethod = "POST"
            connection.setRequestProperty("Content-Type", "application/x-www-form-urlencoded")
            connection.setRequestProperty("apikey", apiKey) // Set API key as a header

            val requestBody = "base64Image=$base64Image"

            println("Request Body: $requestBody")
            connection.doOutput = true
            val wr = DataOutputStream(connection.outputStream)
            wr.writeBytes(requestBody)
            wr.flush()
            wr.close()

            val responseCode = connection.responseCode
            println(responseCode)
            if (responseCode == HttpURLConnection.HTTP_OK) {
                val reader = BufferedReader(InputStreamReader(connection.inputStream))
                val response = StringBuilder()
                var line: String?
                while (reader.readLine().also { line = it } != null) {
                    response.append(line)
                }
                reader.close()

                // Parse the JSON response and extract the text
                val jsonResponse = JSONObject(response.toString())
                val parsedResults = jsonResponse.optJSONArray("ParsedResults")

                Log.d("MyApp", jsonResponse.toString())
                Log.e("MyApp", "")
                println(jsonResponse)

                if (parsedResults != null && parsedResults.length() > 0) {
                    val firstResult = parsedResults.getJSONObject(0)
                    val extractedText = firstResult.optString("ParsedText")

                    return extractedText
                } else {
                    return "No text extracted."
                }
            } else {
                return "Error: Unable to extract text. Response Code: $responseCode"
            }
        } catch (e: Exception) {
            e.printStackTrace()
            return "Error: ${e.message}"
        }
    }





    private fun sendUrlToOCRSpace(imageUrl: String): String {
        val apiKey = "K84208875088957" // Replace with your actual API key
        val ocrEngineVersion = "3" // Specify the OCR engine version

        val encodedUrl = java.net.URLEncoder.encode(imageUrl, "UTF-8") // Encode the URL

        // Append the "ocrengine" parameter to the URL
        val apiUrl = "https://api.ocr.space/parse/imageurl?apikey=$apiKey&url=$encodedUrl&ocrengine=$ocrEngineVersion"

        try {
            val url = URL(apiUrl)
            val connection = url.openConnection() as HttpURLConnection
            connection.requestMethod = "GET"

            val responseCode = connection.responseCode
            if (responseCode == HttpURLConnection.HTTP_OK) {
                val reader = BufferedReader(InputStreamReader(connection.inputStream))
                val response = StringBuilder()
                var line: String?
                while (reader.readLine().also { line = it } != null) {
                    response.append(line)
                }
                reader.close()

                // Parse the JSON response and extract the text
                val jsonResponse = JSONObject(response.toString())
                val parsedResults = jsonResponse.optJSONArray("ParsedResults")

                println(jsonResponse)

                if (parsedResults != null && parsedResults.length() > 0) {
                    val firstResult = parsedResults.getJSONObject(0)
                    val extractedText = firstResult.optString("ParsedText")

                    return extractedText
                } else {
                    return "No text extracted."
                }
            } else {
                return "Error: Unable to extract text."
            }
        } catch (e: Exception) {
            e.printStackTrace()
            return "Error: ${e.message}"
        }
    }









}
