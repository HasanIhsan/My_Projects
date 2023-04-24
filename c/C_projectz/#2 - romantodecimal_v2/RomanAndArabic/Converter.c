//Program Name: Converter.c
//Purpose: this is a program to convert roman numberals to decimal and vice versa
//Programmer: Hassan Ihsan
//Date: - - - 
#define _CRT_SECURE_NO_WARNINGS
#define MAX_LIMIT 100

#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int indexOf(char);
void decimalToroman(int);
void romanTodecimal();

//Decimal to Roman Converter:
void decimalToroman(int input)
{
	//13 roman symbols 
	//in decimal
	char roman[] = { 'I', 'V', 'X', 'L', 'C', 'D', 'M', '_V', '_X', '_L', '_C', '_D', '_M' };
	int decimal[] = { 1, 5, 10, 50, 100, 500, 1000, 5000, 10000, 50000, 100000, 500000, 1000000 };

	int beg, end, d;

	 

	 
		while (input > 0)
		{
			//find the limit
			for (beg = 6; beg > 0; --beg)
			{
				if (input > decimal[beg])
				{
					break;
				}
			}

			for (end = 0; end < 7; ++end)
			{
				if (input <= decimal[end])
				{
					break;
				}
			}

			//get left most digit in n
			d = input;
			while (d != 0)
			{
				d /= 10;
				if (d < 10)
				{
					break;
				}
			}

			//output
			if (input < 10 && input == 4)
			{
				printf("%c%c", roman[beg], roman[end]);
				input = 0;
			}
			else if (input > 10 && d == 4)
			{
				printf("%c%c", roman[beg], roman[end]);
				input -= (decimal[end] - decimal[beg]);
			}
			else if (input < 10 && input == 9)
			{
				printf("%c%c", roman[beg - 1], roman[end]);
				input = 0;
			}
			else if (input > 10 && d == 9)
			{
				printf("%c%c", roman[beg - 1], roman[end]);
				input -= (decimal[end] - decimal[beg - 1]);
			}
			else
			{
				printf("%c", roman[beg]);
				input -= decimal[beg];
			}
		}  
}

//roman to decimal
//7 roman symbols
char roman[] = "IVXLCDM";
int decimal[] = { 1, 5, 10, 50, 100, 500, 1000 };
void romanTodecimal(char input[MAX_LIMIT])
{
	 

	int n = 0, i, j;
	  
	i = strlen(input) - 1; // finds the length of input minus 1
	n += decimal[indexOf(input[i])];
	j = i;
	--i;

	while (i >= 0)
	{
		if (indexOf(input[i]) >= indexOf(input[j]))
		{
			n += decimal[indexOf(input[i])];
		}
		else
		{
			n -= decimal[indexOf(input[i])];
		}
		--i;
		--j;
	}

	//ouput
	printf("Number = %d\n", n);
	 
}

int indexOf(char c)
{
	int i;
	for (i = 0; i < 7; ++i)
	{
		if (roman[i] == c)
		{
			return i;
		}
	}
	return -1; //NOT FOUND
}

int main(int argc, char argv[])
{
	 
	//user input
	char str[MAX_LIMIT];
	printf("Enter a Roman Numeral or a Decimal Number: ");
	(void) scanf("%[^\n]s", str);
	 

	//decide if input is a number or letter
	if (isdigit(str[0]) == 0)
	{ 
		romanTodecimal(str); 
	}
	else
	{
		//simple conversion form string to int
		int n = atoi(str); 
		if (n < 0)
		{
			printf("you enterd a negative number!!\n");
		}
		else if (n == 0)
		{
			printf("you entered zero or null!");
		}
		else
		{
			decimalToroman(n);
		}
	}
	return 0;
}