package com.hassanihsan.test2practice1

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import androidx.databinding.DataBindingUtil
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import com.hassanihsan.test2practice1.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {

    private lateinit var binding:ActivityMainBinding
    private lateinit var viewModel:MainViewModel

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = DataBindingUtil.setContentView(this, R.layout.activity_main)

        viewModel = ViewModelProvider(this)[MainViewModel::class.java]

        val getRand1Observer = Observer<Int> {
                newPerson ->
            binding.rand1 = newPerson
        }

        val getRand2Observer = Observer<Int> {
            newRand ->
            binding.rand2 = newRand
        }

        viewModel.getRand1T.observe(this, getRand1Observer)
        viewModel.getRand2T.observe(this, getRand2Observer)


    }

    fun onGetRand1() {
        viewModel.getRand1()
    }

    fun onGetRand2() {
        viewModel.getRand2()
    }
}