package com.hassanihsan.test2practice1

import android.widget.TextView
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlin.random.Random

class MainViewModel: ViewModel() {
   var getRand1T = MutableLiveData<Int>(0)
    var getRand2T = MutableLiveData<Int>(0)

    init {
        println("viewModel init")
    }


    fun GenerateRandomeNumber() : Int {

        val min = 1 // Change this to your desired minimum value
        val max = 100 // Change this to your desired maximum value
        return Random.nextInt(min, max + 1)
    }


    fun getRand1 () {

        val rand1 = GenerateRandomeNumber()
        CoroutineScope(Dispatchers.Main).launch {
            getRand1T.value = rand1
        }
    }


    fun getRand2 () {

        val rand2 = GenerateRandomeNumber()
        CoroutineScope(Dispatchers.Main).launch {
            getRand2T.value = rand2
        }
    }

}