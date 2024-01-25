package com.hassanihsan.translationapp.mvviewmodel

import android.content.ContentValues
import android.content.Context
import android.content.Intent
import android.text.TextUtils
import android.util.Log
import android.widget.TextView
import android.widget.Toast
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.google.firebase.Firebase
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.firestore.firestore
import com.hassanihsan.translationapp.R
import com.hassanihsan.translationapp.firebase.register
import com.hassanihsan.translationapp.translationpage.TranslationActivity
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import java.io.IOException
import okhttp3.*
import com.google.gson.Gson
import com.hassanihsan.translationapp.CreditsActivity
import com.hassanihsan.translationapp.MainActivity
import com.hassanihsan.translationapp.firebase.login
import kotlinx.coroutines.async
import java.net.URLEncoder

class MainViewModel : ViewModel() {

    private val _finishActivity = MutableLiveData<Unit>()
    val finishActivity: LiveData<Unit> get() = _finishActivity


    var textTranslation = MutableLiveData<String>("")
    var dataToSave: MutableMap<String, Any> = HashMap()

    private val rapidApiKey = "ac73b9cd69msh96f21a9c98ff274p1fbf26jsn123967ae6908"
    private val apiUrl = "https://google-translate1.p.rapidapi.com/language/translate/v2"
    private val db = Firebase.firestore

    companion object {
        // Static properties and methods go here
        const val DB_NAME = "TranslatedText"

    }

    init {
        println("viewmodel init")
    }

    override fun onCleared() {
        println("viewmodel onCleared")
        super.onCleared()
    }

    private val languageMap = mapOf(
        "Afrikaans" to "af",
        "Albanian" to "sq",
        "Amharic" to "am",
        "Arabic" to "ar",
        "Armenian" to "hy",
        "Assamese" to "as",
        "Aymara" to "ay",
        "Azerbaijani" to "az",
        "Bambara" to "bm",
        "Basque" to "eu",
        "Belarusian" to "be",
        "Bengali" to "bn",
        "Bhojpuri" to "bho",
        "Bosnian" to "bs",
        "Bulgarian" to "bg",
        "Catalan" to "ca",
        "Cebuano" to "ceb",
        "Chinese (Simplified)" to "zh-CN",
        "Chinese (Traditional)" to "zh-TW",
        "Corsican" to "co",
        "Croatian" to "hr",
        "Czech" to "cs",
        "Danish" to "da",
        "Dhivehi" to "dv",
        "Dogri" to "doi",
        "Dutch" to "nl",
        "English" to "en",
        "Esperanto" to "eo",
        "Estonian" to "et",
        "Ewe" to "ee",
        "Filipino (Tagalog)" to "fil",
        "Finnish" to "fi",
        "French" to "fr",
        "Frisian" to "fy",
        "Galician" to "gl",
        "Georgian" to "ka",
        "German" to "de",
        "Greek" to "el",
        "Guarani" to "gn",
        "Gujarati" to "gu",
        "Haitian Creole" to "ht",
        "Hausa" to "ha",
        "Hawaiian" to "haw",
        "Hebrew" to "he",
        "Hindi" to "hi",
        "Hmong" to "hmn",
        "Hungarian" to "hu",
        "Icelandic" to "is",
        "Igbo" to "ig",
        "Ilocano" to "ilo",
        "Indonesian" to "id",
        "Irish" to "ga",
        "Italian" to "it",
        "Japanese" to "ja",
        "Javanese" to "jv",
        "Kannada" to "kn",
        "Kazakh" to "kk",
        "Khmer" to "km",
        "Kinyarwanda" to "rw",
        "Konkani" to "gom",
        "Korean" to "ko",
        "Krio" to "kri",
        "Kurdish" to "ku",
        "Kurdish (Sorani)" to "ckb",
        "Kyrgyz" to "ky",
        "Lao" to "lo",
        "Latin" to "la",
        "Latvian" to "lv",
        "Lingala" to "ln",
        "Lithuanian" to "lt",
        "Luganda" to "lg",
        "Luxembourgish" to "lb",
        "Macedonian" to "mk",
        "Maithili" to "mai",
        "Malagasy" to "mg",
        "Malay" to "ms",
        "Malayalam" to "ml",
        "Maltese" to "mt",
        "Maori" to "mi",
        "Marathi" to "mr",
        "Meiteilon (Manipuri)" to "mni-Mtei",
        "Mizo" to "lus",
        "Mongolian" to "mn",
        "Myanmar (Burmese)" to "my",
        "Nepali" to "ne",
        "Norwegian" to "no",
        "Nyanja (Chichewa)" to "ny",
        "Odia (Oriya)" to "or",
        "Oromo" to "om",
        "Pashto" to "ps",
        "Persian" to "fa",
        "Polish" to "pl",
        "Portuguese (Portugal)" to "pt",
        "Portuguese (Brazil)" to "pt",
        "Punjabi" to "pa",
        "Quechua" to "qu",
        "Romanian" to "ro",
        "Russian" to "ru",
        "Samoan" to "sm",
        "Sanskrit" to "sa",
        "Scots Gaelic" to "gd",
        "Sepedi" to "nso",
        "Serbian" to "sr",
        "Sesotho" to "st",
        "Shona" to "sn",
        "Sindhi" to "sd",
        "Sinhala (Sinhalese)" to "si",
        "Slovak" to "sk",
        "Slovenian" to "sl",
        "Somali" to "so",
        "Spanish" to "es",
        "Sundanese" to "su",
        "Swahili" to "sw",
        "Swedish" to "sv",
        "Tagalog (Filipino)" to "tl",
        "Tajik" to "tg",
        "Tamil" to "ta",
        "Tatar" to "tt",
        "Telugu" to "te",
        "Thai" to "th",
        "Tigrinya" to "ti",
        "Tsonga" to "ts",
        "Turkish" to "tr",
        "Turkmen" to "tk",
        "Twi (Akan)" to "ak",
        "Ukrainian" to "uk",
        "Urdu" to "ur",
        "Uyghur" to "ug",
        "Uzbek" to "uz",
        "Vietnamese" to "vi",
        "Welsh" to "cy",
        "Xhosa" to "xh",
        "Yiddish" to "yi",
        "Yoruba" to "yo",
        "Zulu" to "zu"
    )



    fun getUserReadableLanguages(): List<String> {
        return languageMap.keys.toList()
    }


    fun getShortForm(language: String): String? {
        return languageMap[language]
    }


    suspend fun translationApi(source: String, fromLangauge: String?, toLangauge: String?): APIFormat? {
        return try {
            val client = OkHttpClient()

            // Encode only the parameters, not the entire source text
            val encodedTarget = URLEncoder.encode(toLangauge ?: "", "UTF-8")
            val encodedSourceLang = URLEncoder.encode(fromLangauge ?: "", "UTF-8")

            val requestBody = FormBody.Builder()
                .add("q", source)
                .add("target", encodedTarget)
                .add("source", encodedSourceLang)
                .build()

            val request = Request.Builder()
                .url(apiUrl)
                .post(requestBody)
                .addHeader("content-type", "application/x-www-form-urlencoded")
                .addHeader("Accept-Encoding", "application/gzip")
                .addHeader("X-RapidAPI-Key", rapidApiKey)
                .addHeader("X-RapidAPI-Host", "google-translate1.p.rapidapi.com")
                .build()

            val response = withContext(Dispatchers.IO) {
                client.newCall(request).execute()
            }

            println(response)

            if (response.isSuccessful) {
                println("yeah u got through")
                val responseString = response.body?.string()
                Gson().fromJson(responseString, APIFormat::class.java)
            } else {
                println("nope")
                null
            }
        } catch (e: Exception) {
            e.printStackTrace()
            null
        }
    }



    fun getTranslation(source: String, fromLangauge: String?, toLangauge: String?) {

        println("$source $fromLangauge $toLangauge")

        CoroutineScope(Dispatchers.Main).launch {
            val apiFormat = translationApi(source, fromLangauge, toLangauge)

            println(apiFormat)
            if (apiFormat != null) {
                textTranslation.value = apiFormat.data.translations.firstOrNull()?.translatedText?.replace("+", " ")
                saveToDatabase(source, textTranslation.value.toString())
            } else {
                textTranslation.value = "Translation failed. Please try again."
            }
        }
    }


    fun logIn(context: Context, email:String, password: String, mAuth: FirebaseAuth)
    {
       // val intent = Intent(context, TranslationActivity::class.java)
      //  context.startActivity(intent)



        if(TextUtils.isEmpty(email))
        {
            Toast.makeText(context, "Enter Email", Toast.LENGTH_SHORT).show()
            return
        }

        if(TextUtils.isEmpty(password))
        {
            Toast.makeText(context, "Enter Password", Toast.LENGTH_SHORT).show()
            return
        }

        mAuth.signInWithEmailAndPassword(email, password)
            .addOnCompleteListener() { task ->
                if (task.isSuccessful) {
                    Toast.makeText(
                        context,
                        "Login Sucessfull",
                        Toast.LENGTH_SHORT,
                    ).show()

                    changeActivity(context, "translation")


                } else {
                    // If sign in fails, display a message to the user.

                    Toast.makeText(
                        context,
                        "Login Failed",
                        Toast.LENGTH_SHORT,
                    ).show()

                }
            }
    }

    fun regisTer(context: Context, email:String, password: String, rePassword:String, mAuth: FirebaseAuth)
    {
        if(TextUtils.isEmpty(email))
        {
            Toast.makeText(context, "Enter Email", Toast.LENGTH_SHORT).show()
            return
        }

        if(TextUtils.isEmpty(password))
        {
            Toast.makeText(context, "Enter Password", Toast.LENGTH_SHORT).show()
            return
        }

        if(!rePassword.equals(password))
        {
            Toast.makeText(context, "Paswords do not match", Toast.LENGTH_SHORT).show()
            return
        }

        mAuth.createUserWithEmailAndPassword(email, password)
            .addOnCompleteListener() { task ->

                if (task.isSuccessful) {


                    Toast.makeText(
                        context,
                        "Account Created.",
                        Toast.LENGTH_SHORT,
                    ).show()

                    changeActivity(context, "login")


                } else {

                    Toast.makeText(
                        context,
                        "Authentication failed.",
                        Toast.LENGTH_SHORT,
                    ).show()

                }
            }

    }

    fun changeActivity(context: Context, activityName: String) {
        val activityMap: Map<String, Class<*>> = mapOf(
            "register" to register::class.java,
            "login" to login::class.java,
            "translation" to TranslationActivity::class.java,
            "credit" to CreditsActivity::class.java
            // Add more mappings as needed
        )

        println(activityName)

        _finishActivity.value = Unit

        val intent = Intent(context, activityMap[activityName] ?: MainActivity::class.java)
        context.startActivity(intent)
    }

    fun saveToDatabase(beforeTranslation: String, afterTranslation:String)
    {

        dataToSave.put("before Translation", beforeTranslation)
        dataToSave.put("after Translation", afterTranslation)

        // Add a new document with a generated ID
        db.collection(DB_NAME)
            .add(dataToSave)
            .addOnSuccessListener { documentReference ->
                Log.d(ContentValues.TAG, "DocumentSnapshot added with ID: ${documentReference.id}")
            }
            .addOnFailureListener { e ->
                Log.w(ContentValues.TAG, "Error adding document", e)
            }

    }
}
