package com.hassanihsan.translationapp.mvviewmodel


data class APIFormat(
    val data: Data
)

data class Data(
    val translations: List<Translation>
)

data class Translation(
    val translatedText: String
)