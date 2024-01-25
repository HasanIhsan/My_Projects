package com.example.helloworld

import retrofit2.Response
import retrofit2.http.GET
interface AlbumsInterface {

    @GET("/posts")
    suspend fun getAlbums(): Response<Albums>

}