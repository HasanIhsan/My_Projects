package com.example.helloworld

import com.google.gson.annotations.SerializedName

data class AlbumItem(

    @SerializedName("id")
    val id: Int,

    @SerializedName("title")
    val title: String,

    @SerializedName("UserId")
    val userId: Int
)
