package com.hassanihsan.translationapp

import android.os.Bundle
import android.view.LayoutInflater
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.material.Surface
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.viewinterop.AndroidView
import androidx.navigation.compose.rememberNavController
import com.hassanihsan.translationapp.navigation.Navigation

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            Surface(
                color = Color(0xFFFFFFFF),
                modifier = Modifier.fillMaxSize()
            ) {
                Navigation(navHostController = rememberNavController())
            }
        }
    }
}

@Composable
fun MainScreenContent() {
    AndroidView(
        factory = { context ->
            val layoutInflater = LayoutInflater.from(context)

            // Inflate the XML layout directly
            layoutInflater.inflate(R.layout.activity_main, null)
        },
        modifier = Modifier.fillMaxSize()
    )
}
