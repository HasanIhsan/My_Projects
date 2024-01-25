package com.lwong.thenewyorktimes

data class APIFormat (
    var copyright:String,
    var results: Results
)

data class Results (
    var books:List<Book>
)

data class Book(
    var rank:Int,
    var author:String,
    var title:String,
    var book_image:String
)