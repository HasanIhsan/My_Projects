package com.lwong.databindingmvvm1.viewmodel

import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.lwong.databindingmvvm1.model.LoginState
import com.lwong.databindingmvvm1.model.Person

class MainViewModel: ViewModel() {
    var mPerson = MutableLiveData<Person>(Person("Lianne", 3))
    var mLogin = MutableLiveData<LoginState>(LoginState(true))
    init {
        println("viewModel init")
    }

    override fun onCleared() {
        println("viewModel onCleared")
        super.onCleared()
    }

    fun updatePerson(namep:String, countp:Int){
        mPerson.value = Person(namep,countp)
        mLogin.value = LoginState(!mLogin.value!!.on)
    }

}