package com.hassanihsan.takeimageprogram

data class OCRSpaceResponse(
    val ParsedResults: List<ParsedResult>,
    val OCRExitCode: Int,
    val IsErroredOnProcessing: Boolean,
    val ProcessingTimeInMilliseconds: Double,
    val SearchablePDFURL: String
)

data class ParsedResult(
    val Overlay: Overlay,
    val FileParseExitCode: Int,
    val TextOrientation: String,
    val ParsedText: String,
    val ErrorMessage: String,
    val ErrorDetails: String
)

data class Overlay(
    val Lines: List<Line>,
    val HasOverlay: Boolean,
    val Message: String
)

data class Line(
    val LineText: String,
    val Words: List<Word>,
    val MaxHeight: Int,
    val MinTop: Int
)

data class Word(
    val WordText: String,
    val Left: Int,
    val Top: Int,
    val Height: Int,
    val Width: Int
)
