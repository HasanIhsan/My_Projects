package com.hassanihsan.translationapp.translationpage

import android.content.ContentValues.TAG
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.ArrayAdapter
import android.widget.EditText
import android.widget.LinearLayout
import android.widget.Spinner
import android.widget.TextView
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import com.google.firebase.Firebase
import com.google.firebase.firestore.FirebaseFirestore
import com.google.firebase.firestore.firestore
import com.hassanihsan.translationapp.R
import com.hassanihsan.translationapp.databinding.ActivityRegisterBinding
import com.hassanihsan.translationapp.databinding.ActivityTranslationBinding
import com.hassanihsan.translationapp.mvviewmodel.MainViewModel
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import android.content.pm.ActivityInfo

class TranslationActivity : AppCompatActivity() {
    private lateinit var viewModel: MainViewModel
    private lateinit var userReadableLanguages: List<String>
    private lateinit var binding: ActivityTranslationBinding

    private var fromLanguage: String = ""
    private var toLanguage: String = ""

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        //lock the orientation
        requestedOrientation = ActivityInfo.SCREEN_ORIENTATION_PORTRAIT

        binding = ActivityTranslationBinding.inflate(layoutInflater)
        setContentView(binding.root)

        viewModel = ViewModelProvider(this)[MainViewModel::class.java]
        userReadableLanguages = viewModel.getUserReadableLanguages()

        val adapter = ArrayAdapter(this, android.R.layout.simple_spinner_item, userReadableLanguages)
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)

        binding.spinnerFromLanguage.adapter = adapter
        binding.spinnerToLanguage.adapter = adapter



        viewModel.textTranslation.observe(this) { result ->
            binding.textViewTranslatedText.text = result
          //  viewModel.saveToDatabase(binding.editTextTranslation.text.toString(), result)
        }


    }

    fun onClickTranlate(view: View) {
        // Initialize fromLanguage and toLanguage here, after binding is initialized
        fromLanguage = binding.spinnerFromLanguage.selectedItem.toString()
        toLanguage = binding.spinnerToLanguage.selectedItem.toString()

        binding.resultLayout.visibility = View.VISIBLE
        binding.textViewTranslatedLanguage.text = toLanguage

        viewModel.getTranslation(
            binding.editTextTranslation.text.toString(),
            viewModel.getShortForm(fromLanguage),
            viewModel.getShortForm(toLanguage)
        )
    }
}
