package com.example.helloworld

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.Button
import android.widget.ProgressBar
import android.widget.TextView
import androidx.lifecycle.ViewModelProvider
import kotlinx.coroutines.*

class MainActivity : AppCompatActivity() {

    private lateinit var tv: TextView
    private lateinit var btn: Button
    private lateinit var launchButton: Button
    private lateinit var asyncButton: Button
    private lateinit var fetchDataBtn: Button
    private lateinit var btnFetchLiveData: Button
    private lateinit var tvResponse: TextView
    private lateinit var pb: ProgressBar

    private lateinit var mainVM: MainViewModel
    private lateinit var albumsInterface: AlbumsInterface

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        Log.i("MainActivity", "onCreate")
        setContentView(R.layout.activity_main)
        initViews()
        mainVM = ViewModelProvider(this).get(MainViewModel::class.java)
        mainVM.countLiveData.value = CountData(0)
        albumsInterface = RetrofitProvider.retrofitInstance.create(AlbumsInterface::class.java)
        showCount()
        initClickListener()
        observerLiveData()
    }

    private fun initViews() {
        tv = findViewById(R.id.textView)
        btn = findViewById(R.id.button)
        launchButton = findViewById(R.id.button2)
        asyncButton = findViewById(R.id.button3)
        fetchDataBtn = findViewById(R.id.button4)
        btnFetchLiveData = findViewById(R.id.btnFetchLiveData)
        tvResponse = findViewById(R.id.tvResponse)
        pb = findViewById(R.id.pb)
    }

    private fun initClickListener() {
        //Button click
        btn.setOnClickListener {
            mainVM.increaseCount()
        }

        btnFetchLiveData.setOnClickListener {
            CoroutineScope(Dispatchers.Main).launch {
                pb.visibility = View.VISIBLE
                mainVM.fetchDataUsingLiveData(albumsInterface)
                pb.visibility = View.GONE
            }
        }

        launchButton.setOnClickListener {
            val intent = Intent(this, ViewBindingActivity::class.java)
            startActivity(intent)
        }

        asyncButton.setOnClickListener {
            CoroutineScope(Dispatchers.Main).launch {
                Log.i("MainActivity", "before firstSuspendCall")
                val result = mainVM.firstSuspendCall()
                Log.i("MainActivity", "after firstSuspendCall result $result")
            }
            Log.i("MainActivity", "Click listener ends")
        }

        fetchDataBtn.setOnClickListener {
            CoroutineScope(Dispatchers.Main).launch {
                pb.visibility = View.VISIBLE
                val data = mainVM.fetchData(albumsInterface)
                displayData(data)
                pb.visibility = View.GONE
            }
        }
    }


    private fun observerLiveData() {
        //Observe data changes
        mainVM.countLiveData.observe(this) {
            showCount()
        }

        mainVM.albumLiveDate.observe(this) { albums ->
            displayData(albums)
        }
    }

    private fun displayData(albums: Albums?) {
        val albumList = albums?.listIterator()
        if (albumList != null) {
            while (albumList.hasNext()) {
                val albumsItem = albumList.next()
                val result = " " + "Album Title : ${albumsItem.title}" + "\n" +
                        " " + "Album id : ${albumsItem.id}" + "\n" +
                        " " + "User id : ${albumsItem.userId}" + "\n\n\n"
                tvResponse.append(result)
            }
        }
    }


    private fun showCount() {
        tv.text = mainVM.countLiveData.value?.count?.toString()
    }

//    private fun initButton() {
//        val btnAddFragment = findViewById<Button>(R.id.btnAddFragment)
//        val btnReplace = findViewById<Button>(R.id.btnReplace)
//
//        btnAddFragment.setOnClickListener {
//            addMyDynamicFragment()
//        }
//
//        btnReplace.setOnClickListener {
//            replaceFragment()
//        }
//
//    }
//
//    private fun addMyDynamicFragment() {
//        val dynamicFragment = DynamicFragment()
//        val transaction = supportFragmentManager.beginTransaction()
//        transaction.add(R.id.dynamicFragment, dynamicFragment)
//        transaction.commit() // asynchronous
////        transaction.commitNow() // synchronous
//    }
//
//    private fun replaceFragment() {
//        val staticFrag = StaticFragment()
//        val transaction = supportFragmentManager.beginTransaction()
//        transaction.replace(R.id.dynamicFragment, staticFrag)
//        transaction.addToBackStack(null);
//        transaction.commit()
//    }
}