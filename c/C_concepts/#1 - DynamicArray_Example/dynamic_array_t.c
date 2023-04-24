/*
File: dynamic_array_t.c
Author: hassan ihsan
Purpose: for dynamic array
*/
#include "dynamic_array.h"
#include <assert.h>
#include <ctype.h>
#include <stdio.h>
#include <stdlib.h>

array_uintmax_t make_Array() {
	array_uintmax_t arr = {0};
	arr.data = NULL;
	arr.capacity = 0;
	arr.size = 0;
	return arr;
}
array_wchar_t make_Array_w() {
	array_wchar_t arr = {0};
	arr.data = NULL;
	arr.capacity = 0;
	arr.size = 0;
	return arr;
}



bool array_uintmax_t_pushback(array_uintmax_t* dArray, TYPE_OF_ARRAY value) {

	if (dArray->capacity == dArray->size)
	{
		size_t newCapacity = dArray->capacity * 2;
		if (newCapacity == 0) {++newCapacity;}
		TYPE_OF_ARRAY* newArrBlock = realloc(dArray->data, newCapacity * sizeof(TYPE_OF_ARRAY));
		
		if (newArrBlock == NULL){
			return false;
		}
		dArray->data = newArrBlock;
		dArray->capacity = newCapacity;
	}
	dArray->data[dArray->size++] = value;
	return true;
}


bool array_wchar_t_pushback(array_wchar_t* dArray, char value) {


	if ((*dArray).size == dArray->capacity) {
		if (dArray->capacity == 0) ++(dArray->capacity);
		uintmax_t* pszDouble = (char*)realloc(dArray->data, (dArray->capacity *= 2) * sizeof(uintmax_t));
		if (pszDouble == NULL) {
			return false;
		}
		dArray->data = pszDouble;
	}

	// store the value
	dArray->data[dArray->size++] = value;
	return true;
}



void array_uintmax_free(array_uintmax_t* a)
{
	free(a->data);
	a->capacity = 0;
	a->size = 0;
	a->data = NULL;
}

void array_wchar_free(array_wchar_t* a)
{
	free(a->data);
	a->capacity = 0;
	a->size = 0;
	a->data = NULL;
}