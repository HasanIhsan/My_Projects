package com.hassanihsan.translationapi

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import android.view.View
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import okhttp3.*
import org.json.JSONObject
import java.io.IOException

class MainActivity : AppCompatActivity() {

    private val rapidApiKey = "ac73b9cd69msh96f21a9c98ff274p1fbf26jsn123967ae6908"
    private val apiUrl = "https://google-translate1.p.rapidapi.com/language/translate/v2"

    private lateinit var editTextSource: EditText
    private lateinit var buttonTranslate: Button
    private lateinit var textViewTranslation: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        editTextSource = findViewById(R.id.editTextSource)
        buttonTranslate = findViewById(R.id.buttonTranslate)
        textViewTranslation = findViewById(R.id.textViewTranslation)

        buttonTranslate.setOnClickListener {
            // Get the text to be translated from the EditText
            val sourceText = editTextSource.text.toString()
            // Define the target language (e.g., "es" for Spanish)
            val targetLanguage = "es"

            // Use Coroutines to perform the network request in the background
            GlobalScope.launch(Dispatchers.IO) {
                translateText(sourceText, targetLanguage)
            }
        }
    }

    private fun translateText(sourceText: String, targetLanguage: String) {
        val client = OkHttpClient()
        val requestBody = FormBody.Builder()
            .add("q", sourceText)
            .add("target", targetLanguage)
            .add("source", "en") // Source language (optional)
            .build()

        val request = Request.Builder()
            .url(apiUrl)
            .post(requestBody)
            .addHeader("content-type", "application/x-www-form-urlencoded")
            .addHeader("Accept-Encoding", "application/gzip")
            .addHeader("X-RapidAPI-Key", rapidApiKey)
            .addHeader("X-RapidAPI-Host", "google-translate1.p.rapidapi.com")
            .build()

        client.newCall(request).enqueue(object : Callback {
            override fun onFailure(call: Call, e: IOException) {
                e.printStackTrace()
                // Handle the failure, e.g., show an error message
                runOnUiThread {
                    textViewTranslation.text = "Translation failed. Please try again."
                }
            }

            override fun onResponse(call: Call, response: Response) {
                response.body?.string()?.let { responseString ->
                    val jsonResponse = JSONObject(responseString)
                    val data = jsonResponse.getJSONObject("data")
                    val translations = data.getJSONArray("translations")
                    if (translations.length() > 0) {
                        val translation = translations.getJSONObject(0).getString("translatedText")
                        // Update the UI with the translation result
                        runOnUiThread {
                            textViewTranslation.text = translation
                        }
                    } else {
                        runOnUiThread {
                            textViewTranslation.text = "Translation not found."
                        }
                    }
                }
            }
        })
    }
}
