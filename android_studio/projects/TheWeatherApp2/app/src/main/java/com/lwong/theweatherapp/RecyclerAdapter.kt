package com.lwong.theweatherapp

import android.content.Context
import android.content.res.Resources
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import java.security.AccessController.getContext


class RecyclerAdapter(private val dataSet: List<WeatherDay>) :
    RecyclerView.Adapter<RecyclerAdapter.ViewHolder>() {

    /**
     * Provide a reference to the type of views that you are using
     * (custom ViewHolder).
     */
    inner class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        var textViewTemp:TextView
        var textViewDate:TextView
        var textViewDescription:TextView
        init {
            textViewDate = view.findViewById(R.id.textViewDate)
            textViewTemp = view.findViewById(R.id.textViewTemp)
            textViewDescription = view.findViewById(R.id.textViewDescription)
        }
    }

    // Create new views (invoked by the layout manager)
    override fun onCreateViewHolder(viewGroup: ViewGroup, viewType: Int): ViewHolder {
        // Create a new view, which defines the UI of the list item
        val view = LayoutInflater.from(viewGroup.context)
            .inflate(R.layout.recycler_item_card_layout, viewGroup, false)

        val lp = view.layoutParams
        lp.height = 256
        view.layoutParams = lp

        return ViewHolder(view)
    }

    // Replace the contents of a view (invoked by the layout manager)
    override fun onBindViewHolder(viewHolder: ViewHolder, position: Int) {
        viewHolder.textViewDate.text = dataSet[position].datetime
        viewHolder.textViewTemp.text = dataSet[position].temp.toString()
        viewHolder.textViewDescription.text = dataSet[position].description
    }

    // Return the size of your dataset (invoked by the layout manager)
    override fun getItemCount():Int {
        return dataSet.size
    }

}