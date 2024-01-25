package com.hassanihsan.hassanihsaninfo5126inclass

import android.graphics.Color
import android.os.Bundle
import android.view.View
import androidx.appcompat.app.AppCompatActivity
import com.hassanihsan.hassanihsaninfo5126inclass.databinding.ActivityVisualizeBinding


class VisualizeActivity : AppCompatActivity() {
    private lateinit var binding:ActivityVisualizeBinding;
    private  var backgroundColor:Int = 0;
    private var textcolor:Int = 0;
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityVisualizeBinding.inflate(layoutInflater);
        setContentView(binding.root);

        binding.selectedText.setText(intent.getStringExtra("color_name"));

        textcolor = Color.parseColor(intent.getStringExtra("color_name"));
        binding.selectedText.setTextColor(textcolor);

         backgroundColor = Color.parseColor(intent.getStringExtra("background_color"));
        binding.selectedText.setBackgroundColor(backgroundColor);


    }
    fun onButtonClick(view: View) {
        binding.selectedText.setText("red");
         binding.selectedText.setTextColor(Color.parseColor("Red"));
    }

    fun getColorName(colorInt: Int): String {
        when (colorInt) {
            Color.RED -> return "red"
            Color.GREEN -> return "green"
            Color.BLUE -> return "blue"

            else -> return "Unknown"
        }
    }

    fun OnButtonClose(view: View) {
       // MainActivity.color = binding.selectedText.getCurrentTextColor().toString();
        val currentColorInt = binding.selectedText.currentTextColor;


        MainActivity.color = getColorName(currentColorInt);
        finish();
    }


}