package com.example.a2danimation

import android.app.ActivityOptions
import android.content.Intent
import android.graphics.drawable.AnimationDrawable
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.ImageView
import com.example.a2danimation.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {
    lateinit var binding:ActivityMainBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        // frame animation
        binding.imageView.setBackgroundResource(R.drawable.bird_animation)
        val frameAnimation = binding.imageView.background as AnimationDrawable
        frameAnimation.start()
    }

    fun onClick(view: View?) {
        val intent = Intent(this,TweenAnimationActivity::class.java)
        startActivity(intent, ActivityOptions.makeSceneTransitionAnimation(this).toBundle())
    }
}