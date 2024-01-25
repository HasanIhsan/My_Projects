package com.hassanihsan.translationapp.firebase

import android.content.Intent
import android.os.Bundle
import android.text.TextUtils
import android.view.View
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import com.google.firebase.auth.FirebaseAuth
import com.hassanihsan.translationapp.R
import com.hassanihsan.translationapp.databinding.ActivityLoginBinding
import com.hassanihsan.translationapp.mvviewmodel.MainViewModel
import com.hassanihsan.translationapp.translationpage.TranslationActivity
import android.content.pm.ActivityInfo

class login : AppCompatActivity() {


    private lateinit var viewModel: MainViewModel
    private lateinit var binding:ActivityLoginBinding

    private lateinit var mAuth: FirebaseAuth

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        //lock the orientation
        requestedOrientation = ActivityInfo.SCREEN_ORIENTATION_PORTRAIT


        binding = ActivityLoginBinding.inflate(layoutInflater)
        setContentView(binding.root)

        viewModel = ViewModelProvider(this)[MainViewModel::class.java]
        mAuth = FirebaseAuth.getInstance()



        binding.textViewRegisterHere?.setOnClickListener {
            viewModel.finishActivity.observe(this, Observer {
                finish()
            })
            viewModel.changeActivity(this, "register")
        }


    }

    fun onLoginClick(view: View) {

        //viewModel.isLoggedIn(this)
        var email = binding.editTextEmail.text.toString()
        var password = binding.editTextPassword.text.toString()

        viewModel.logIn(this, email, password, mAuth)

    }

    fun onCreditBtnClick(view: View) {
        viewModel.changeActivity(this, "credit")
    }
}
