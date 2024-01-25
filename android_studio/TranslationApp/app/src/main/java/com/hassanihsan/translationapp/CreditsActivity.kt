package com.hassanihsan.translationapp

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import androidx.lifecycle.ViewModelProvider
import com.hassanihsan.translationapp.databinding.ActivityCreditsBinding
import com.hassanihsan.translationapp.databinding.ActivityTranslationBinding
import com.hassanihsan.translationapp.mvviewmodel.MainViewModel
import android.content.pm.ActivityInfo

class CreditsActivity : AppCompatActivity() {
    private lateinit var viewModel: MainViewModel
    private lateinit var binding: ActivityCreditsBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        //lock the orientation
        requestedOrientation = ActivityInfo.SCREEN_ORIENTATION_PORTRAIT

        binding = ActivityCreditsBinding.inflate(layoutInflater)
        setContentView(binding.root)

        viewModel = ViewModelProvider(this)[MainViewModel::class.java]
    }

    fun onClickLoginBtn(view: View) {
        viewModel.changeActivity(this, "login")
    }
}