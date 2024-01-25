package com.example.helloworld

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import kotlinx.coroutines.*

class MainViewModel : ViewModel() {
    val countLiveData = MutableLiveData<CountData>()
    private val albumLiveData_ = MutableLiveData<Albums?>()

    val albumLiveDate: LiveData<Albums?> get() = albumLiveData_

    fun increaseCount() {
        countLiveData.value?.count = countLiveData.value?.count!! + 1
        countLiveData.value = countLiveData.value
    }

    suspend fun firstSuspendCall(): Int {
        val defer = CoroutineScope(Dispatchers.IO).async {
            Log.i("MainActivity", "inside firstSuspendCall ${Thread.currentThread().name}")
            delay(3000) //to simulate a network call
            return@async 100
        }

        return defer.await()
    }

    suspend fun fetchData(albumsInterface: AlbumsInterface): Albums? {
        val defer = CoroutineScope(Dispatchers.IO).async {
            //making api call
            val albumsResponse = albumsInterface.getAlbums()

            return@async albumsResponse.body()
        }
        return defer.await()
    }

    suspend fun fetchDataUsingLiveData(albumsInterface: AlbumsInterface) {
        val defer = CoroutineScope(Dispatchers.IO).launch {
            //making api call
            val albumsResponse = albumsInterface.getAlbums()
            val albums = albumsResponse.body()
            albumLiveData_.postValue(albums)
        }
    }
}


