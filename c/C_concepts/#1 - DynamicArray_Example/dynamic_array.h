/*
File: dynamic_array.h
Author: hassan ihsan
Purpose: a header file for dynamic array
*/
#define _CRT_DEBUG_MAP_ALLOC
#include <crtdbg.h> // CRT = C-Runtine, DBG = debug
#include <stdlib.h> // contains heap memory management functions
#include <inttypes.h>
#include <stdbool.h>
#define TYPE_OF_ARRAY double
 

typedef struct array_tag {
	double* data;
	size_t capacity;
	size_t size;
} array_uintmax_t;
 
typedef struct array_char {
	char* data;
	size_t capacity;
	size_t size;
} array_wchar_t;



array_uintmax_t make_Array();
array_wchar_t make_Array_w();

bool array_uintmax_t_pushback(array_uintmax_t* pArray, TYPE_OF_ARRAY value);
bool array_wchar_t_pushback(array_wchar_t* pArray, char value);

//bool array_uintmax_t_resize(array_uintmax_t* pArray, size_t nSize);


void array_uintmax_free(array_uintmax_t* pArray);
void array_wchar_free(array_wchar_t* dArray);