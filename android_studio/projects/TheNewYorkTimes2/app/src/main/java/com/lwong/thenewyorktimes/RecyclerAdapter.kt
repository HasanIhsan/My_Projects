package com.lwong.thenewyorktimes

import android.content.Context
import android.content.res.Resources
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.squareup.picasso.Picasso
import java.security.AccessController.getContext


class RecyclerAdapter(private val dataSet: List<Book>) :
    RecyclerView.Adapter<RecyclerAdapter.ViewHolder>() {

    /**
     * Provide a reference to the type of views that you are using
     * (custom ViewHolder).
     */
    inner class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        var textViewRank:TextView
        var textViewAuthor:TextView
        var textViewTitle:TextView
        var bookImage:ImageView
        init {
            textViewRank = view.findViewById(R.id.textViewRank)
            textViewAuthor = view.findViewById(R.id.textViewAuthor)
            textViewTitle = view.findViewById(R.id.textViewTitle)
            bookImage = view.findViewById(R.id.imageView)
        }
    }

    // Create new views (invoked by the layout manager)
    override fun onCreateViewHolder(viewGroup: ViewGroup, viewType: Int): ViewHolder {
        // Create a new view, which defines the UI of the list item
        val view = LayoutInflater.from(viewGroup.context)
            .inflate(R.layout.recycler_item_card_layout, viewGroup, false)

        val lp = view.layoutParams
        lp.height = 512
        view.layoutParams = lp

        return ViewHolder(view)
    }

    // Replace the contents of a view (invoked by the layout manager)
    override fun onBindViewHolder(viewHolder: ViewHolder, position: Int) {
        viewHolder.textViewRank.text = dataSet[position].rank.toString()
        viewHolder.textViewAuthor.text = dataSet[position].author
        viewHolder.textViewTitle.text = dataSet[position].title
        Picasso.get().load(dataSet[position].book_image).into(viewHolder.bookImage)
    }

    // Return the size of your dataset (invoked by the layout manager)
    override fun getItemCount():Int {
        return dataSet.size
    }

}