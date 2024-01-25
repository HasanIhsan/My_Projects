package com.lwong.threadcoroutineworkmanager

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.os.Handler
import android.os.Looper
import android.util.Log
import android.view.View
import androidx.core.os.HandlerCompat
import com.lwong.threadcoroutineworkmanager.databinding.ActivityMainBinding
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.SupervisorJob
import kotlinx.coroutines.async
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import java.text.SimpleDateFormat
import java.util.Date
import androidx.work.*
import java.text.DateFormat.getDateTimeInstance

class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding
    // ThreadHandler for basic threads
    // Looper class used to run a message loop for the thread
    private val mainThreadHandler: Handler = HandlerCompat.createAsync(Looper.getMainLooper()) {
            message ->
        val bundle = message.data
        binding.textViewStatus.text = bundle.getString("myKey")
        true
    }
    // used for second thread
    private var balance:Int = 0

    // job and Dispatcher for Coroutines
    // lazy keyword initializes once and only when called
    // avoids unnecessary creation
    private val job = SupervisorJob()
    // 3 types of dispatchers.
    // MAIN-main thread,
    // IO for networks,
    // DEFAULT for CPU Intensive work
    private val ioScope by lazy { CoroutineScope(job + Dispatchers.IO) }



    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        // viewbinding
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)
    }

    fun onButtonClick(view: View) {
        when(view.id) {
            R.id.buttonThread -> {
                runThread1()
                runThread2()
            }
            R.id.buttonCoroutine -> {
                onCoroutine()
            }
            R.id.buttonWorkManager -> {
                onWorkManager()
            }
        }
    }

    // thread 1 example for basic threads
    private fun runThread1() {
        val runnable=Runnable {
            val msg = mainThreadHandler.obtainMessage()
            val bundle = Bundle()
            val dateFormat = getDateTimeInstance()
            val dateString = dateFormat.format(Date())
            bundle.putString("myKey", "Thread1: $dateString")
            msg.data = bundle
            mainThreadHandler.sendMessage(msg)
        }
        val myThread = Thread(runnable)
        myThread.start()
    }
    // thread 2 example for basic threads
    private fun runThread2() {
        val runnable2=Runnable {
            val msg = mainThreadHandler.obtainMessage()
            val bundle = Bundle()
            balance += 30
            bundle.putString("myKey", "Thread2: $balance")
            msg.data = bundle
            mainThreadHandler.sendMessage(msg)
        }
        val myThread2 = Thread(runnable2)
        myThread2.start()
    }
    // coroutine example
    private var sumDouble:Double = 0.0
    private fun onCoroutine() {
        // launch the coroutine
        ioScope.launch {
            val one = async {  randOne() }
            val two = async { randTwo() }
            if(one.await() && two.await()) {
                sumDouble = randomNumber1 + randomNumber2
            }
            else {
                Log.d("couroutine", "not all threads returned true")
            }
            // use Dispatchers.MAIN to get modify the main thread
            withContext(Dispatchers.Main) {
                // update the UI
                binding.textViewStatus.text = sumDouble.toString()
            }
        }
    }
    // function called by coroutine, note function is a suspended function
    // that could be started, stopped and resumed
    private var randomNumber1:Double = 0.0
    private suspend fun randOne():Boolean {
        // fetch data from API
        randomNumber1 =Math.random()*100 // for values 0..99.99
        // like sleep
        delay(100L)
        Log.d("coroutines", "randNumber1 = $randomNumber1")
        return true
    }
    private var randomNumber2:Double = 0.0
    private suspend fun randTwo():Boolean {
        // fetch data from API
        randomNumber2 =Math.random()*100 // for values 0..99.99
        // like sleep
        delay(200L)
        Log.d("coroutines", "randNumber2 = $randomNumber2")
        return true
    }

    // launching a workManager
    private fun onWorkManager() {
        // create items to send into the work manager
        val data = Data.Builder()
            .putString("myData", "Data to be passed to the work manager")
            .build()
        // set constraints
        val constraints = androidx.work.Constraints.Builder()
            .setRequiredNetworkType(NetworkType.CONNECTED)
            .build()
        val authenticateWorkRequest:WorkRequest = OneTimeWorkRequestBuilder<WorkManagerImpl>()
            .setInputData(data)
            .setConstraints(constraints)
            .build()
        // queue the workManager to run the task
        val workManager = WorkManager.getInstance(this)
        workManager.enqueue(authenticateWorkRequest)
        // get data back from the workManager
        workManager.getWorkInfoByIdLiveData(authenticateWorkRequest.id)
            .observe(this, androidx.lifecycle.Observer {
                    workInfo ->
                if(workInfo.state == WorkInfo.State.SUCCEEDED) {
                    val authResults = workInfo.outputData.getString("myOutputData")
                    binding.textViewStatus.text = authResults.toString()
                }
            })
    }
}