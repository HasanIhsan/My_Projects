package com.lwong.thenewyorktimes

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.gson.Gson
import com.lwong.thenewyorktimes.databinding.ActivityMainBinding
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.async
import kotlinx.coroutines.launch
import java.io.InputStreamReader
import java.net.URL
import javax.net.ssl.HttpsURLConnection

class MainActivity : AppCompatActivity() {
    private lateinit var recyclerViewManager: RecyclerView.LayoutManager
    private lateinit var binding:ActivityMainBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)
        // setup recyclerView
        recyclerViewManager = LinearLayoutManager(applicationContext)
        binding.recyclerView.layoutManager = recyclerViewManager
        binding.recyclerView.setHasFixedSize(true)

        CoroutineScope(Dispatchers.Main).launch {
            val request = getBookDataFromCoroutine()
            if (request != null){
                binding.textViewCopyright.text = "${request.copyright}"
                binding.recyclerView.adapter = RecyclerAdapter(request.results.books)
                // or you could just use the updateUI
                //                updateUI(request)
            }
            else {
                binding.textViewCopyright.text = getString(R.string.nobooks)
            }
        }
    }
    // coroutine to getWeather
    private suspend fun getBookDataFromCoroutine():APIFormat? {
        val defer = CoroutineScope(Dispatchers.IO).async {
            val url = URL("https://api.nytimes.com/svc/books/v3/lists/current/hardcover-fiction.json?api-key=T2EAcub58TIt7xmggIdm3XwbmsPbHMWl")
            val connection = url.openConnection() as HttpsURLConnection
            if(connection.responseCode == 200)
            {
                val inputSystem = connection.inputStream
                val inputStreamReader = InputStreamReader(inputSystem, "UTF-8")
                val request = Gson().fromJson(inputStreamReader, APIFormat::class.java)
                inputStreamReader.close()
                inputSystem.close()
                return@async request
            }
            else {
                return@async null
            }
        }
        return defer.await()
    }

}