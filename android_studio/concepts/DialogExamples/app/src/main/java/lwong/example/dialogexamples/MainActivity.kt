package lwong.example.dialogexamples

import android.app.DatePickerDialog
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.Button
import android.widget.TextView
import androidx.appcompat.app.AlertDialog
import androidx.fragment.app.DialogFragment
import lwong.example.dialogexamples.databinding.ActivityMainBinding
import java.text.DateFormat.getDateTimeInstance
import java.text.SimpleDateFormat
import java.util.*


class MainActivity : AppCompatActivity() , View.OnClickListener, ConfirmationFragment.SendMessages{

    // setup the viewBinding
    private lateinit var binding: ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        // inflates the viewBinding
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)
        // button layout onClick event not set.
        // Another method for setting onClick at runtime
        // Note: MainActivity class above add View.OnClickListener
        binding.buttonCalendar.setOnClickListener(this)
        binding.buttonConfirm.setOnClickListener(this)
        binding.buttonSimple.setOnClickListener(this)
    }

    override fun onClick(view: View?) {
        when(view?.id)
        {
         R.id.buttonSimple-> {
             Log.d("dialog", "Simple pressed")
             // using dialog directly without a fragment
             val builder = AlertDialog.Builder(this)
             builder.setTitle(R.string.simpleheader)
             builder.setMessage(R.string.simpletext)
             builder.setPositiveButton(android.R.string.ok) {
                     _, _ ->
                 binding.tvMsg.setText(android.R.string.ok)
             }
             builder.setNegativeButton(android.R.string.cancel) {
                     _, _ ->
                 binding.tvMsg.setText(android.R.string.cancel)
             }
             builder.show()
         }
            R.id.buttonCalendar-> {
                // use the existing datepicker dialog
                binding.tvMsg.text = getDateTimeInstance().format(System.currentTimeMillis())
                val cal = Calendar.getInstance()
                val dateSetListener = DatePickerDialog.OnDateSetListener {
                        _, year, monthOfYear, dayOfMonth ->
                    cal.set(Calendar.YEAR, year)
                    cal.set(Calendar.MONTH, monthOfYear)
                    cal.set(Calendar.DAY_OF_MONTH, dayOfMonth)
                    val myFormat = "dd.MM.yyyy"
                    val sdf = SimpleDateFormat(myFormat, Locale.CANADA)
                    binding.tvMsg.text = sdf.format(cal.time)
                }
                DatePickerDialog(this@MainActivity, dateSetListener,
                cal.get(Calendar.YEAR),
                cal.get(Calendar.MONTH),
                cal.get(Calendar.DAY_OF_MONTH)).show()
            }
            R.id.buttonConfirm -> {
                val confirmFrag: DialogFragment? = ConfirmationFragment
                    .newInstance(R.string.confirm)
                confirmFrag!!.show(supportFragmentManager, "dialog")
            }
        }
    }
    override fun choiceMade(msg: Int?)
    {
        binding.tvMsg.text = "My choice is: ${ConfirmationFragment.levels[msg!!]}"
        ConfirmationFragment.checkedItem = msg
    }
}