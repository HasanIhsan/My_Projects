package com.example.a2danimation

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.view.animation.Animation
import android.view.animation.AnimationUtils
import android.widget.Button
import android.widget.ImageView
import com.example.a2danimation.databinding.ActivityTweenAnimationBinding

class TweenAnimationActivity : AppCompatActivity() {
    lateinit var binding:ActivityTweenAnimationBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityTweenAnimationBinding.inflate(layoutInflater)
        setContentView(binding.root)
    }

    fun onClick(view: View?) {
        when(view?.id)
        {
            R.id.button->finishAfterTransition()
            R.id.buttonGrow->cubeAnimation(R.animator.grow)
            R.id.buttonMove->cubeAnimation(R.animator.translate_position)
            R.id.buttonSpin->cubeAnimation(R.animator.spin)
            R.id.buttonTransparency->cubeAnimation(R.animator.transparency)
            R.id.buttonShake->cubeAnimation(R.animator.shakennotstirred)
        }
    }

    lateinit var imageViewRect:ImageView

    private fun cubeAnimation(animationResourceID: Int) {
//        val imageViewRect:ImageView = findViewById(R.id.imageViewRect) as ImageView
        binding.imageViewRect.setImageResource(R.drawable.green_rect)

        binding.imageViewRect.visibility = View.VISIBLE
        // load appropriate animation
        val anim:Animation = AnimationUtils.loadAnimation(this,animationResourceID)
        // set up listener
        anim.setAnimationListener(MyAnimationListener())
        // start the animation
        binding.imageViewRect.startAnimation(anim)

        // showing that you can animate any widget not only the imageView
        binding.buttonShake.visibility = View.VISIBLE
        // load appropriate animation
        val animbutton:Animation = AnimationUtils.loadAnimation(this,animationResourceID)
        // start the animation
        binding.buttonShake.startAnimation(animbutton)

    }

    inner class MyAnimationListener: Animation.AnimationListener {
        override fun onAnimationStart(p0: Animation?) {

        }

        override fun onAnimationEnd(p0: Animation?) {
            binding.imageViewRect.visibility = View.INVISIBLE
        }

        override fun onAnimationRepeat(p0: Animation?) {

        }

    }
}

