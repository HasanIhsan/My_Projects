package com.lwong.databindingmvvm1

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import com.lwong.databindingmvvm1.databinding.ActivityMainBinding
import androidx.databinding.DataBindingUtil
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import com.lwong.databindingmvvm1.model.LoginState
import com.lwong.databindingmvvm1.model.Person
import com.lwong.databindingmvvm1.viewmodel.MainViewModel

class MainActivity : AppCompatActivity() {
    lateinit var binding:ActivityMainBinding
    lateinit var person:Person
    lateinit var viewModel:MainViewModel
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = DataBindingUtil.setContentView(this, R.layout.activity_main)
//        person = Person("Lianne", 3)
//        binding.name = person.name
//        binding.count = person.count
//        binding.person = person

        // instantiate viewModel
        viewModel = ViewModelProvider(this)[MainViewModel::class.java]

        val personObserver = Observer<Person> {
            newPerson ->
            binding.person = newPerson
        }

        viewModel.mPerson.observe(this, personObserver)

        val stateObserver = Observer<LoginState>{
            newState ->
            binding.login = newState
        }
        viewModel.mLogin.observe(this, stateObserver)
    }

    fun onButtonClick(view: View) {
//        person = Person("Garth", 10)
//        binding.name = person.name
//        binding.count = person.count
//        binding.person = person
        viewModel.updatePerson("Garth",10)
    }
}