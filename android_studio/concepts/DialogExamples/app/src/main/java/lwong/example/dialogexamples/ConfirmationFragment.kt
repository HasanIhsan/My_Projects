package lwong.example.dialogexamples

import android.app.AlertDialog
import android.app.Dialog
import android.content.Context
import android.content.DialogInterface
import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.DialogFragment

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
private const val ARG_PARAM1 = "param1"
private const val ARG_PARAM2 = "param2"

/**
 * A simple [Fragment] subclass.
 * Use the [ConfirmationFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class ConfirmationFragment : DialogFragment() {
    // TODO: Rename and change types of parameters
    private var param1: String? = null
    private var param2: String? = null
    private var sendMessages: SendMessages? = null
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        arguments?.let {
            param1 = it.getString(ARG_PARAM1)
            param2 = it.getString(ARG_PARAM2)
        }
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_confirmation, container, false)
    }

    override fun onCreateDialog(savedInstanceState: Bundle?): Dialog {
        return AlertDialog.Builder(activity)
            .setTitle(R.string.choice)
            .setSingleChoiceItems(levels, checkedItem, DialogInterface.OnClickListener {
                    _, which ->
                sendMessages!!.choiceMade(which)
            })
            .setPositiveButton(android.R.string.ok, DialogInterface.OnClickListener {
                    _, _ ->
                Log.d("confirmation dialog", "positive button")
        })
            .setNegativeButton(android.R.string.cancel, DialogInterface.OnClickListener {
                    _, _ -> Log.d("confirmation dialog", "negative button")
            }).create()

    }

    companion object {
        /**
         * Use this factory method to create a new instance of
         * this fragment using the provided parameters.
         *
         * @param param1 Parameter 1.
         * @param param2 Parameter 2.
         * @return A new instance of fragment ConfirmationFragment.
         */
        // TODO: Rename and change types and number of parameters
        // create the dialog
        var levels = arrayOf( "Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6")
        var checkedItem = 0

        @JvmStatic
        fun newInstance(title: Int):
                ConfirmationFragment {
               val fragment = ConfirmationFragment()
                val args = Bundle()
                args.putInt("title", title)
                fragment.arguments =args
            return fragment
            }
    }

    // attach the interface
    override fun onAttach(context: Context) {
        super.onAttach(context)
        // send information through interface
        sendMessages = context as SendMessages
    }

    // Interface to send information from the fragment to MainActivity
    internal interface SendMessages {
        fun choiceMade(msg:Int?)
    }

}