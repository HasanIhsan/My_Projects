/*
File: stats.c
Author: hassan ihsan
Purpose: takes an array of doubles from keyboard or a file, outputs various info about the dataset.
*/

#define _CRT_SECURE_NO_WARNINGS
#include "dynamic_array.h"
#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <assert.h>
#include <math.h>
#include <crtdbg.h>
#include <string.h>
#include <ctype.h>

#define MAXINPUT 1000u

//quick Sort
//note: was planning on using heap sort, but my code would not go past 1900 elements after 1900 it would give a read access violation.
//      and the million file does not work quick sort gives soome other error (again without the sorting every file works)
//      quick/merge/heap are worth 10% (this is quick sort)
void quick_Sort(double number[], int first, int last)
{
	int i, j, pivot, temp;

	if (first < last) {
		pivot = first;
		i = first;
		j = last;

		while (i < j) {
			while (number[i] <= number[pivot] && i < last)
				i++;
			while (number[j] > number[pivot])
				j--;
			if (i < j) {
				temp = number[i];
				number[i] = number[j];
				number[j] = temp;
			}
		}

		temp = number[pivot];
		number[pivot] = number[j];
		number[j] = temp;
		quick_Sort(number, first, j - 1);
		quick_Sort(number, j + 1, last);

	}
}

 
//calcuate the mean (Mean correctly reported in all cases)
// worth 5%
double calculate_Mean(array_uintmax_t* Arr)
{
	double Mean = 0;
	for (size_t i = 0; i < Arr->size; ++i)
	{
		Mean += Arr->data[i];
	}

	return Mean / Arr->size;
}

//calculate the median (Median correctly reported in all cases)
// worth 5%
double  calculate_Median(array_uintmax_t* Arr)
{
	double Median = 0;

	if (Arr->size % 2 == 0) {
		//if number of elemetns are even
		Median = (Arr->data[(Arr->size - 1) / 2] + Arr->data[Arr->size / 2]) / 2.0;
	}
	else
	{
		// if number of elements are odd
		Median = Arr->data[Arr->size / 2];
	}

	return Median;
}

//number of elemtns (Number of values reported)
// worth 2%
int number_Of_Elements(array_uintmax_t* Arr)
{
	return Arr->size;
}

//calcute the MIN number (Minimum value correctly reported in all cases)
// worth 2%
double calculate_Min(array_uintmax_t* Arr)
{
	double Min = Arr->data[0];

	for (size_t i = 0; i < Arr->size; i++)
	{
		if (Arr->data[i] < Min)
		{
			Min = Arr->data[i];
		}
	}
	return Min;
}

// calculate the MAX number (Maximum value correctly reported in all cases)
// worth 3%
double calculate_Max(array_uintmax_t* Arr)
{
	double Max = Arr->data[0];

	for (size_t i = 0; i < Arr->size; i++)
	{
		if (Arr->data[i] > Max)
		{
			Max = Arr->data[i];
		}
	}
	return Max;
}

//calculate the Range (Range value correctly reported in all cases)
//  worth 3%
double calculate_Range(double Min, double Max)
{
	double range = 0;
	range = Max - Min;

	return range;
}

//calcuate the varience (Population variance correctly reported in all cases)
// worth 5%
double calculate_Varience(array_uintmax_t* Arr)
{
	double Mean = calculate_Mean(Arr);
	double sum_Dev = 0; // sum devation
	for (size_t i = 0; i < Arr->size; i++)
	{
		sum_Dev += pow((Arr->data[i] - Mean), 2);
	}

	return sum_Dev / Arr->size;
}

//calcualte devation (Population standard deviation correctly reported in all cases)
// worth 5%
double calculate_Deviation(array_uintmax_t* Arr)
{
	return sqrt(calculate_Varience(Arr));
}

 
////hitogram 
//some parts do not work... and some are not implemented...

void outputHistogram(double PerceA, double PerceB, double PerceC, double PerceD, double PerceE, double PerceF, double PerceG, double PerceH, double PerceI, double PerceJ )
{
	//finding largest value (so we can create the top numbers)
	double largestValue = PerceA;
	if (PerceB > largestValue) {
		largestValue = PerceB;
	}
	else if (PerceC > largestValue) {
		largestValue = PerceC;
	}
	else if (PerceD > largestValue) {
		largestValue = PerceD;
	}
	else if (PerceE > largestValue) {
		largestValue = PerceE;
	}
	else if (PerceF > largestValue) {
		largestValue = PerceF;
	}
	else if (PerceG > largestValue) {
		largestValue = PerceG;
	}
	else if (PerceH > largestValue) {
		largestValue = PerceH;
	}
	else if (PerceI > largestValue) {
		largestValue = PerceI;
	}
	else if (PerceJ > largestValue) {
		largestValue = PerceJ;
	}
	//printf("largestvalue = %lf\n", largestValue);
	 
	double startValue = 0;
	 
	printf("Grp     %% %.1lf     0     0     0     0     0     0     0     0     %.1lf     0\n", startValue, largestValue);
	//printf("───────── ┌─────┬─────┬─────┬─────┬─────┬─────┬─────┬─────┬─────┬─────┬\n");
	printf("--------- |------|-----|-----|-----|-----|-----|-----|-----|-----|-----|\n");
	printf("A %.2lf%% |\n", PerceA);
	printf("B %.2lf%% |\n", PerceB);
	printf("C %.2lf%% |\n", PerceC);
	printf("D %.2lf%% |\n", PerceD);
	printf("E %.2lf%% |\n", PerceE);
	printf("F %.2lf%% |\n", PerceF);
	printf("G %.2lf%% |\n", PerceG);
	printf("H %.2lf%% |\n", PerceH);
	printf("I %.2lf%% |\n", PerceI);
	printf("J %.2lf%% |\n", PerceJ);
	printf("--------- |------|-----|-----|-----|-----|-----|-----|-----|-----|-----|\n");

}

//frequect table
//worth 2% and 5% others are not properly implemented.
void freuencyTable(array_uintmax_t* Arr) 
{
	double minimumValue = calculate_Min(Arr);
	double maximumValue = calculate_Max(Arr);
	double rangevalue = calculate_Range(minimumValue, maximumValue);

 
	double StartValues = minimumValue;
	double addedValue = rangevalue * 0.1;
	double dataset_size = 0;
	
	//vars used for frequence table (this may not  be the most effiecint but it gets the job done)
	double newValueA = 0.0, newValueB = 0.0, newValueC = 0.0, newValueD = 0.0, newValueE = 0.0, newValueF = 0.0, newValueG = 0.0, newValueH = 0.0, newValueI = 0.0, newValueJ = 0.0;
	double oldValueB = 0.0, oldValueC = 0.0, oldValueD = 0.0, oldValueE = 0.0, oldValueF = 0.0, oldValueG = 0.0, oldValueH = 0.0, oldValueI = 0.0, oldValueJ = 0.0;
	double countA = 0, countB = 0, countC = 0 , countD = 0 , countE = 0, countF = 0, countG = 0, countH = 0, countI = 0, countJ = 0;
	double percentageA = 0.0, percentageB = 0.0, percentageC = 0.0, percentageD = 0.0, percentageE = 0.0, percentageF = 0.0, percentageG = 0.0, percentageH = 0.0, percentageI = 0.0, percentageJ = 0.0;
	 

 
	 
	printf("\n");


	StartValues += addedValue;
	newValueA = StartValues;
	 
	 
	for (int i = 0; i < Arr->size; i++) {
		if (Arr->data[i] <= newValueA) {
			countA++;

		}
	}

	oldValueB = newValueA;
	newValueB = newValueA;
	newValueB += addedValue;

	for (int i = 0; i < Arr->size; i++) {

		if (Arr->data[i] >= oldValueB && Arr->data[i] <= newValueB) {

			countB++;

		}
	}

	oldValueC = newValueB;
	newValueC = newValueB;
	newValueC += addedValue;

	for (int i = 0; i < Arr->size; i++) {
		if (Arr->data[i] >= oldValueC && Arr->data[i] <= newValueC) {
			countC++;

		}
	}
	 
	oldValueD = newValueC;
	newValueD = newValueC;
	newValueD += addedValue;

	for (int i = 0; i < Arr->size; i++) {
		if (Arr->data[i] >= oldValueD && Arr->data[i] <= newValueD ) {
			countD++;

		}
	}
	
	oldValueE = newValueD;
	newValueE = newValueD;
	newValueE += addedValue;

	for (int i = 0; i < Arr->size; i++) {
		if (Arr->data[i] >= oldValueE && Arr->data[i] <= newValueE) {
			countE++;

		}
	}
	 
	oldValueF = newValueE;
	newValueF = newValueE;
	newValueF += addedValue;

	for (int i = 0; i < Arr->size; i++) {
		if (Arr->data[i] >= oldValueF && Arr->data[i] <= newValueF) {
			countF++;

		}
	}
	 
	oldValueG = newValueF;
	newValueG = newValueF;
	newValueG += addedValue;

	for (int i = 0; i < Arr->size; i++) {
		if (Arr->data[i] >= oldValueG && Arr->data[i] <= newValueG) {
			countG++;

		}
	}
	 
	oldValueH = newValueG;
	newValueH = newValueG;
	newValueH += addedValue;

	for (int i = 0; i < Arr->size; i++) {
		if (Arr->data[i] >= oldValueH && Arr->data[i] <= newValueH) {
			countH++;

		}
	}
	 
	oldValueI = newValueH;
	newValueI = newValueH;
	newValueI += addedValue;

	for (int i = 0; i < Arr->size; i++) {
		if (Arr->data[i] >= oldValueI && Arr->data[i] <= newValueI) {
			countI++;

		}
	}
	 
	oldValueJ = newValueI;
	newValueJ = newValueI;
	newValueJ += addedValue;

	for (int i = 0; i < Arr->size; i++) {
		if (Arr->data[i] >= oldValueJ && Arr->data[i] <= maximumValue) {
			countJ++;

		}
	}
	 
	dataset_size = countA + countB + countC + countD + countE + countF + countG + countH + countI + countJ;
	//printf("datasetsize = %d\n", dataset_size);

	percentageA = countA / dataset_size * 100;
	 
	printf("A[%.1lf .. %.1lf] = %.0lf : %.2lf%%\n", minimumValue, newValueA, countA, percentageA);

 
	percentageB = countB / dataset_size * 100;
	printf("B[%.1lf .. %.1lf] = %.0lf : %.2lf%%\n", oldValueB, newValueB, countB, percentageB);

	 
	percentageC = countC / dataset_size * 100;
	printf("C[%.1lf .. %.1lf] = %.0lf : %.2lf%%\n", oldValueC, newValueC, countC, percentageC);

	 
	percentageD = countD / dataset_size * 100;
	printf("D[%.1lf .. %.1lf] = %.0lf : %.2lf%%\n", oldValueD, newValueD, countD, percentageD);
	
	 
	percentageE = countE / dataset_size * 100;
	printf("E[%.1lf .. %.1lf] = %.0lf : %.2lf%%\n", oldValueE, newValueE, countE, percentageE);
	
	 
	percentageF = countF / dataset_size * 100;
	printf("F[%.1lf .. %.1lf] = %.0lf : %.2lf%%\n", oldValueF, newValueF, countF,percentageF);
	
	 
	percentageG = countG / dataset_size * 100;
	printf("G[%.1lf .. %.1lf] = %.0lf : %.2lf%%\n", oldValueG, newValueG, countG, percentageG);
	
	 
	percentageH = countH / dataset_size * 100;
	printf("H[%.1lf .. %.1lf] = %.0lf : %.2lf%%\n", oldValueH, newValueH, countH, percentageH);
	
	 
	percentageI = countI / dataset_size * 100;
	printf("I[%.1lf .. %.1lf] = %.0lf : %.2lf%%\n", oldValueI, newValueI, countI, percentageI);
	
	 
	percentageJ = countJ / dataset_size * 100;
	printf("J[%.1lf .. %.1lf] = %.0lf : %.2lf%%\n", oldValueJ, maximumValue, countJ, percentageJ);

 
	//directly leading to the output hitogram function 
	//since we need percentages i'm directly going to the function
	printf("===============================================================================\n");
	printf("Histogram\n");
	outputHistogram(percentageA, percentageB, percentageC, percentageD, percentageE, percentageF, percentageG, percentageH, percentageI, percentageJ);
}

//lograithmic transform
// worth 5%
void calculate_logTransform(double Arr[], size_t size) {
	//creating new array for log values
	array_uintmax_t uintmax_t_Arr2 = make_Array();

	for (int i = 0; i < size; i++)
	{
		array_uintmax_t_pushback(&uintmax_t_Arr2, log(Arr[i]));
	}
	freuencyTable(&uintmax_t_Arr2);
}



int main(int argc, char* argv[])
{
	//read form terminal  worth 5%
	FILE* stream = stdin;
	 

	double Input_Numbers = 0;
	 
	/*
	* quote: 
	* You can absolutely use fixed-length arrays for anything in your project,
	* other than to store the data that needs to be analyzed. If you find that you need
	* to create temporary fixed-length arrays and then push that onto your dynamic array, that's fine.
	*/
	char Numstr[MAXINPUT] = "\0";
	char* Input;
	char* pointer = "end";

	array_uintmax_t uintmax_t_Arr = make_Array();
	array_wchar_t uwchar_t_Arr = make_Array_w();
	 

	 //reports bad file names  worth 4%
	if (argc > 2)
	{
		printf("stats (S 2021.0.0), © 2021 Hassan Ihsan");
		printf("Error:invalid command line.\n");
		printf("Usage: stats [filename]\n");
		return EXIT_FAILURE;
	}
	else if (argc == 2) {
		if ((stream = fopen(argv[1], "r")) == NULL)
		{
			printf("stats (S 2021.0.0), © 2021 Hassan Ihsan\n");
			printf("Error <%s> ", argv[1]);
			perror(" ");
			return EXIT_FAILURE;
		}
	}

	printf("Enter a list of whitespace-separated real numbers terminated by EOF or 'end'.\n");
 
	 
	//input from keyboard  worth 1%
	//reads double persion real numbers  worth 1%
	//skips bad input  worth 5% (may not be properly implemented)
	while (fscanf(stream, "%s", &Input) != EOF) {

		//printf("%s", &Numstr);
		if (strcmp(pointer, &Input) == 0) break;
	 

		//did not know if i was allowed to have a static array for input so i created 2 dynamic arrays
		//again i emailed you for this question, you said i would be fine to have a static array, but i 
		//still had doughts so i made 2 dynamic arrays.
		array_wchar_t_pushback(&uwchar_t_Arr, Input);
	 
		Input_Numbers = atof(&Input);
 
		 array_uintmax_t_pushback(&uintmax_t_Arr, Input_Numbers);
		  
	}
 

	if (uintmax_t_Arr.data == NULL)
	{

		printf("\nempty data set!\n");
		printf("quitting...\n");
		return EXIT_FAILURE;
	}
	else
	{

		quick_Sort(uintmax_t_Arr.data, 0, uintmax_t_Arr.size - 1);
		uint32_t number_of_elemts = number_Of_Elements(&uintmax_t_Arr);
		double calc_Min = calculate_Min(&uintmax_t_Arr);
		double calc_Max = calculate_Max(&uintmax_t_Arr);
		double calc_Range = calculate_Range(calc_Min, calc_Max);
		double calc_Mean = calculate_Mean(&uintmax_t_Arr);
		double calc_Median = calculate_Median(&uintmax_t_Arr);
		double calc_Varience = calculate_Varience(&uintmax_t_Arr);
		double calc_Deviation = calculate_Deviation(&uintmax_t_Arr);
		
		printf("===============================================================================\n");
		printf("# elements\t%d\n", number_of_elemts);
		printf("minimum\t\t%.3lf\n", calc_Min);
		printf("maximum\t\t%.3lf\n", calc_Max);
		printf("range\t\t%.3lf\n", calc_Range);
		printf("mean\t\t%.3lf\n", calc_Mean);
		printf("median\t\t%.3lf\n", calc_Median);
		printf("variance\t%.3lf\n", calc_Varience);
		printf("std.dev.\t%.3lf\n", calc_Deviation);
		printf("===============================================================================\n");
		printf("Frequency Table\n");
		freuencyTable(&uintmax_t_Arr);
		printf("===============================================================================\n");
		printf("Log Frequency Table\n");
		 
		calculate_logTransform(uintmax_t_Arr.data, uintmax_t_Arr.size);
		 
	  
		 
	}
	 

 
	array_uintmax_free(&uintmax_t_Arr);
	fclose(stream);
	return EXIT_SUCCESS;

}