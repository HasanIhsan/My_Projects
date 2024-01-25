package com.lwong.threadcoroutineworkmanager

import android.content.Context
import android.util.Log
import androidx.work.Data
import androidx.work.Worker
import androidx.work.WorkerParameters

class WorkManagerImpl(appContext: Context, workerParams:WorkerParameters):Worker(appContext,workerParams) {
    override fun doWork(): Result {
        // read the input data
        val text:String? = inputData.getString("myData")
        Log.d("workManager", text!!)

        // do the work on the other thread
        Log.d("workManager", "Doing the work on another thread")

        // pass any information back
        val outputData = Data.Builder()
            .putString("myOutputData", "results to be passed back")
            .build()
        // indicate whether the work finished successfully
        return Result.success(outputData)
    }

}