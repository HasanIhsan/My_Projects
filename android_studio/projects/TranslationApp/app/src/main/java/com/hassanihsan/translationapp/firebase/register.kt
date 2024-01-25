package com.hassanihsan.translationapp.firebase

import android.content.ContentValues.TAG
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.text.TextUtils
import android.util.Log
import android.view.View
import android.widget.TextView
import android.widget.Toast
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import androidx.lifecycle.viewmodel.compose.viewModel
import com.google.firebase.auth.FirebaseAuth
import com.hassanihsan.translationapp.R
import com.hassanihsan.translationapp.databinding.ActivityLoginBinding
import com.hassanihsan.translationapp.databinding.ActivityRegisterBinding
import com.hassanihsan.translationapp.mvviewmodel.MainViewModel
import com.hassanihsan.translationapp.translationpage.TranslationActivity
import android.content.pm.ActivityInfo

class register : AppCompatActivity() {
    private lateinit var binding:ActivityRegisterBinding
    private lateinit var viewModel: MainViewModel
    private lateinit var mAuth: FirebaseAuth

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        //lock the orientation
        requestedOrientation = ActivityInfo.SCREEN_ORIENTATION_PORTRAIT

        binding = ActivityRegisterBinding.inflate(layoutInflater)
        setContentView(binding.root)


        viewModel = ViewModelProvider(this)[MainViewModel::class.java]
        mAuth = FirebaseAuth.getInstance()



        binding.textViewRegLogin?.setOnClickListener{

            viewModel.finishActivity.observe(this, Observer {
                finish()
            })
            viewModel.changeActivity(this, "login")
        }


    }

    fun onClickRegister(view: View) {


        var email = binding.editTextRegEmail.text.toString()
        var password = binding.editTextRegPassword.text.toString()
        var repassword = binding.editTextRegConfermPass.text.toString()


       viewModel.regisTer(this, email, password, repassword, mAuth)


    }
}