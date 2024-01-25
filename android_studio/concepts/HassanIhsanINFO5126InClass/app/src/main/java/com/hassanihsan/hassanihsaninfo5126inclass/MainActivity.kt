package com.hassanihsan.hassanihsaninfo5126inclass

import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.view.View
import androidx.appcompat.app.AppCompatActivity
import com.hassanihsan.hassanihsaninfo5126inclass.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {

    private lateinit var binding:ActivityMainBinding;

    companion object {
        const val BACKGROUND_KEY = "background_color";
        const val COLOR_KEY = "color_name";
        var color = "";
        var backcolor = "";
        const val SHARED_PREF_KEY = "HassanIhsanInClass"
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root);

        val refsEditor = getSharedPreferences(SHARED_PREF_KEY, Context.MODE_PRIVATE);
        color = refsEditor.getString(COLOR_KEY, "red").toString();

        println(color);
    }

    fun onButtonClick(view: View) {

        when(binding.radioGroupColor.checkedRadioButtonId)
        {
            R.id.radioButtonRed -> color = "red";
            R.id.radioButtonGreen -> color = "green";
            R.id.radioButtonBlue -> color = "blue";
        }

        backcolor = binding.spinner.getSelectedItem().toString()

        var intent = Intent(this, VisualizeActivity::class.java);
        //intent.putExtra("name", binding.editTextTextPersonName.text.toString());
        intent.putExtra(BACKGROUND_KEY, backcolor);
        intent.putExtra(COLOR_KEY, color );
        startActivity(intent);


        println(color);
        println(backcolor);
    }
    override fun onResume() {
        super.onResume()

        val refsEditor = getSharedPreferences(SHARED_PREF_KEY, Context.MODE_PRIVATE);

        println(color);


        when(color)
        {
            "red" -> binding.radioButtonRed.isChecked = true;
            "green" -> binding.radioButtonGreen.isChecked = true;
            "blue" -> binding.radioButtonBlue.isChecked = true;
        }
    }

    override fun onPause() {
        val prefsEditor = getSharedPreferences(SHARED_PREF_KEY, Context.MODE_PRIVATE).edit();

        prefsEditor.putString(COLOR_KEY, color);
        prefsEditor.apply();
        super.onPause()
    }

}