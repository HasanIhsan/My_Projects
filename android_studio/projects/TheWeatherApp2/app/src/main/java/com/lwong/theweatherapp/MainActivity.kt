package com.lwong.theweatherapp

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.gson.Gson
import com.lwong.theweatherapp.databinding.ActivityMainBinding
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.async
import kotlinx.coroutines.launch
import java.io.InputStreamReader
import java.net.URL
import javax.net.ssl.HttpsURLConnection

class MainActivity : AppCompatActivity() {
    private lateinit var recyclerViewManager: RecyclerView.LayoutManager
    lateinit var binding:ActivityMainBinding
    private lateinit var weatherDays:List<WeatherDay>
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        // setup recyclerView
        recyclerViewManager = LinearLayoutManager(applicationContext)
        binding.recyclerView.layoutManager = recyclerViewManager
        binding.recyclerView.setHasFixedSize(true)
    }

    fun onButtonGo(view: View) {
        println("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/London%2C%20Ontario?unitGroup=metric&elements=datetime%2Ctempmax%2Ctempmin%2Ctemp%2Cprecipprob%2Cdescription&include=current&key=BNR9A4ND6HNMB3WX2RTE7R63Q&contentType=json")
//        getWeatherData(binding.editTextCity.text.toString()).start()
            // for coroutines
        CoroutineScope(Dispatchers.Main).launch {
            val request = getWeatherDataFromCoroutine(binding.editTextCity.text.toString())
            if(request != null)
            {
                // update the ui
                binding.textView.text = "${request.address}"
                binding.textViewCurTemp.text ="${request.currentConditions.temp} ${getString(R.string.deg_c)}"
                binding.recyclerView.adapter = RecyclerAdapter(request.days!!)
            }
            else
            {
                binding.textView.text = getString(R.string.no_weather)
            }
        }

    }

    private fun getWeatherData(sCity:String):Thread {
        return Thread {
            val url = URL("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/$sCity?unitGroup=metric&elements=datetime%2Ctempmax%2Ctempmin%2Ctemp%2Cprecipprob%2Cdescription&include=current&key=BNR9A4ND6HNMB3WX2RTE7R63Q&contentType=json")
            val connection = url.openConnection() as HttpsURLConnection
            if(connection.responseCode == 200) {
                val inputSystem = connection.inputStream
                val inputStreamReader = InputStreamReader(inputSystem,"UTF-8")
                val request = Gson().fromJson(inputStreamReader, APIFormat::class.java)
                // update UI on the UI Thread
                updateUI(request)
                println(request.toString())
                inputStreamReader.close()
                inputSystem.close()
            }
            else {
                binding.textView.text = getString(R.string.no_weather)
            }
        }
    }

    fun updateUI(request:APIFormat) {
        runOnUiThread {
            kotlin.run {
                binding.textView.text = "${request.address}"
                binding.textViewCurTemp.text ="${request.currentConditions.temp} ${getString(R.string.deg_c)}"
                binding.recyclerView.adapter = RecyclerAdapter(request.days!!)
            }
        }
    }

    private suspend fun getWeatherDataFromCoroutine(sCity:String):APIFormat? {
        val defer = CoroutineScope(Dispatchers.IO).async {
            val url =
                URL("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/$sCity?unitGroup=metric&elements=datetime%2Ctempmax%2Ctempmin%2Ctemp%2Cprecipprob%2Cdescription&include=current&key=BNR9A4ND6HNMB3WX2RTE7R63Q&contentType=json")
            val connection = url.openConnection() as HttpsURLConnection
            if (connection.responseCode == 200) {
                val inputSystem = connection.inputStream
                val inputStreamReader = InputStreamReader(inputSystem, "UTF-8")
                val request = Gson().fromJson(inputStreamReader, APIFormat::class.java)
                // update UI on the UI Thread
                // in a coroutine update the UI back in the Dispatchers.Main
                println(request.toString())
                inputStreamReader.close()
                inputSystem.close()
                return@async request
            } else {
                return@async null
            }
        }
        return defer.await()
    }
}