package com.hassanihsan.translationapp.navigation

import android.content.Intent
import androidx.compose.runtime.Composable
import androidx.compose.ui.platform.LocalContext
import androidx.navigation.NavHostController
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import com.hassanihsan.translationapp.MainScreenContent
import com.hassanihsan.translationapp.Splash
import com.hassanihsan.translationapp.firebase.login

@Composable
fun Navigation(
    navHostController: NavHostController
) {
    NavHost(navController = navHostController, startDestination = "splash") {
        composable("splash") {
            Splash(navController = navHostController)
        }

        composable("login") {
         //   MainScreenContent()

            val intent = Intent(LocalContext.current, login::class.java)
            LocalContext.current.startActivity(intent)
        }

        composable("main") {
            MainScreenContent()
        }
    }
}