package com.hassanihsan.finalpractice2

import android.os.Bundle
import android.view.View
import android.view.animation.Animation
import android.view.animation.AnimationUtils
import android.widget.RelativeLayout
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class MainActivity : AppCompatActivity() {

    private lateinit var textView: TextView
    private lateinit var greenRectangle: RelativeLayout

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        textView = findViewById(R.id.textView)
        greenRectangle = findViewById(R.id.greenRectangle)

        textView.setOnClickListener {
            rotateText()
        }

        greenRectangle.setOnClickListener {
            fadeRectangle()
        }
    }

    private fun rotateText() {
        val rotateAnimation: Animation = AnimationUtils.loadAnimation(this, R.anim.rotate_animation)
        rotateAnimation.setAnimationListener(object : Animation.AnimationListener {
            override fun onAnimationStart(animation: Animation) {
                textView.text = "TextView"
            }

            override fun onAnimationEnd(animation: Animation) { }

            override fun onAnimationRepeat(animation: Animation) {}
        })
        textView.startAnimation(rotateAnimation)
    }

    private fun fadeRectangle() {
        val fadeAnimation: Animation = AnimationUtils.loadAnimation(this, R.anim.fade_animation)
        fadeAnimation.setAnimationListener(object : Animation.AnimationListener {
            override fun onAnimationStart(animation: Animation) {
                greenRectangle.visibility = View.INVISIBLE
                textView.text = "Rectangle"
            }

            override fun onAnimationEnd(animation: Animation) {
                greenRectangle.visibility = View.VISIBLE
                textView.text = "Rectangle"
            }

            override fun onAnimationRepeat(animation: Animation) {}
        })
        greenRectangle.startAnimation(fadeAnimation)
    }
}
