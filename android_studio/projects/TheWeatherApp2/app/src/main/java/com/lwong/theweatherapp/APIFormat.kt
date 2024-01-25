package com.lwong.theweatherapp

data class APIFormat (
    var address:String,
    var days:List<WeatherDay>,
    var currentConditions: CurrentConditions
)

data class WeatherDay (
    var datetime:String,
    var temp:Double,
    var description:String,
)

data class CurrentConditions (
    var temp:Double,
)