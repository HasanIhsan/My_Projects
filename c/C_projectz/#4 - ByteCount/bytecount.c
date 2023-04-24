// Programmer: Hassan Ihsan
// Program name: ByteCount
// Date: *
// Note: Chanages made form checkpoint
//			- removed muliplication method (replaced with simple uint64_t * uint64_t (simple large num muliplication))
//			- added another comma method (this takes doubles converts them to string before adding in the comma) 
//										 (this is very ineficinet and there proberly is a better way of doing it but thats all i could figure out)
//										 (still have normal int comma method)
//
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdint.h>
#include <string.h>
#include <stdlib.h>
#include <ctype.h>
#define MAX_Capacity 1000u
#define MAX_INT 9223372036854775808 // max num allowed by the program


void convertToByte(long double sum_num, uint64_t conversion_num, char unit_Type[MAX_Capacity]);
void addCommasToInts(uint64_t converted_num);
void addCommasToDoubles(char* in, char* out);

//conversion method (N * 1000 ^(e)) or in this case n * n with the conversion number hard coded
void convertToByte(long double source_num, uint64_t conversion_num, char unit_Type[MAX_Capacity]) {

	uint64_t converted_Value = 0;
	const uint64_t MAXVALUE = 11000000000000000000;
	long double diviionnum_METRIC, diviionnum_IEC, sum = 0, sum2 = 0;
	char sum_num[MAX_Capacity] = { 0 }, output_num[MAX_Capacity] = { 0 }, sum_num2[MAX_Capacity] = { 0 }, output_num2[MAX_Capacity] = { 0 };

	converted_Value = source_num * conversion_num;
	if (converted_Value > MAXVALUE) {
		converted_Value = MAX_INT;
	}

	printf(" \"%.1lf %s\" is ", source_num, unit_Type);
	addCommasToInts(converted_Value);
	printf(" bytes");
	//ConvertToByte(converted_Value);


	//print other conversions
	// snprintf (printed if format was used, instead to printing the contect is stored as c stinrg in buffer)
	printf("\n\n\n\t\tMetric\t\t\tIEC");
	printf("\n\t\t======\t\t\t======\n");
	// KB AND KIB--------------------------------------------------
	diviionnum_METRIC = 1000;
	sum = converted_Value / diviionnum_METRIC;
	diviionnum_IEC = 1024;
	sum2 = converted_Value / diviionnum_IEC;

	snprintf(sum_num, MAX_Capacity, "%.3f", sum);
	snprintf(sum_num2, MAX_Capacity, "%.3f", sum2);

	addCommasToDoubles(sum_num2, output_num2);
	addCommasToDoubles(sum_num, output_num);
	printf("%25s KB\t%25s KiB\n", output_num, output_num2);

	////MB AND MIB----------------------------------------------------
	diviionnum_METRIC = 1000000;
	sum = converted_Value / diviionnum_METRIC;
	diviionnum_IEC = 1048576;
	sum2 = converted_Value / diviionnum_IEC;

	snprintf(sum_num, MAX_Capacity, "%.3f", sum);
	snprintf(sum_num2, MAX_Capacity, "%.3f", sum2);

	addCommasToDoubles(sum_num2, output_num2);
	addCommasToDoubles(sum_num, output_num);
	printf("%25s MB\t%25s MiB\n", output_num, output_num2);


	//gB AND tIB-------------------------------------------------------
	diviionnum_METRIC = 1000000000;
	sum = converted_Value / diviionnum_METRIC;
	diviionnum_IEC = 1073741824;
	sum2 = converted_Value / diviionnum_IEC;

	snprintf(sum_num, MAX_Capacity, "%.3f", sum);
	snprintf(sum_num2, MAX_Capacity, "%.3f", sum2);

	addCommasToDoubles(sum_num2, output_num2);
	addCommasToDoubles(sum_num, output_num);
	printf("%25s GB\t%25s GiB\n", output_num, output_num2);


	//TB AND TIB---------------------------------------------------
	diviionnum_METRIC = 1000000000000;
	sum = converted_Value / diviionnum_METRIC;
	diviionnum_IEC = 1099511627776;
	sum2 = converted_Value / diviionnum_IEC;

	snprintf(sum_num, MAX_Capacity, "%.3f", sum);
	snprintf(sum_num2, MAX_Capacity, "%.3f", sum2);

	addCommasToDoubles(sum_num2, output_num2);
	addCommasToDoubles(sum_num, output_num);
	printf("%25s TB\t%25s TiB\n", output_num, output_num2);


	//PB AND PIB------------------------------------------------
	diviionnum_METRIC = 1000000000000000;
	sum = converted_Value / diviionnum_METRIC;
	diviionnum_IEC = 1125899906842624;
	sum2 = converted_Value / diviionnum_IEC;

	snprintf(sum_num, MAX_Capacity, "%.3f", sum);
	snprintf(sum_num2, MAX_Capacity, "%.3f", sum2);

	addCommasToDoubles(sum_num2, output_num2);
	addCommasToDoubles(sum_num, output_num);
	printf("%25s PB\t%25s PiB\n", output_num, output_num2);


	//EB AND EIB-----------------------------------------------
	diviionnum_METRIC = 1000000000000000000;
	sum = converted_Value / diviionnum_METRIC;
	diviionnum_IEC = 1152921504606846976;
	sum2 = converted_Value / diviionnum_IEC;

	snprintf(sum_num, MAX_Capacity, "%.3f", sum);
	snprintf(sum_num2, MAX_Capacity, "%.3f", sum2);

	addCommasToDoubles(sum_num2, output_num2);
	addCommasToDoubles(sum_num, output_num);
	printf("%25s EB\t%25s EiB\n", output_num, output_num2);

}

//add comma to (doubles)
void addCommasToDoubles(char* in, char* out) {
	int len_in = strlen(in), len_int = -1, pos = 0; // len_int(123.4) = 3 

	for (int i = 0; i < len_in; ++i) {
		if (in[i] == '.') {
			len_int = i;
		}
	}

	for (int i = 0; i < len_in; ++i) {
		if (i > 0 && i < len_int && (len_int - i) % 3 == 0) {
			out[pos++] = ',';
		}
		out[pos++] = in[i];
	}
	out[pos] = 0;                                  // Append the '\0' 
}

//print comma every 1000 number (whole numbers uint64_t)
void addCommasToInts(uint64_t converted_num) {
	if (converted_num < 1000) {
		printf("%llu", converted_num);
		return;
	}
	addCommasToInts(converted_num / 1000);
	printf(",%03llu", converted_num % 1000);
}

int main()
{
	long double sum_number = 0;
	uint64_t  conversion_num = 0, converted_value = 0;
	char unit_Type[MAX_Capacity] = "\0", Unit_typeupper[MAX_Capacity] = "\0", c;
	int32_t i = 0;

	printf("Enter # unit: ");
	(void)scanf(" %lf %[^\n]%*c", &sum_number, unit_Type);


	/* if (!isspace(sum_number)) {
		 printf("Error: you did not enter a recognizable number.\n");
		 printf("Usage: dddd.ddd unittype");
		 return EXIT_FAILURE;
	 }*/

	 //convert userinput to lowecase and uppercase
	while (unit_Type[i]) {
		c = unit_Type[i];
		unit_Type[i] = tolower(c);
		Unit_typeupper[i] = toupper(c);
		i++;
	}

	//negative value
	if (sum_number < 0) {
		printf("ERROR:input value must be a non-negative value\n");
		printf("usage: dddd.ddd unittype");
		return EXIT_FAILURE;
	}
	else if (strcmp("b", unit_Type) == 0 || strcmp("char", unit_Type) == 0 || strcmp("unsigned char", unit_Type) == 0) {
		conversion_num = 1;
		convertToByte(sum_number, conversion_num, Unit_typeupper);
	}
	else if (strcmp("short", unit_Type) == 0 || strcmp("unsigned short", unit_Type) == 0) {
		conversion_num = 2;
		convertToByte(sum_number, conversion_num, unit_Type);
	}
	else if (strcmp("int", unit_Type) == 0 || strcmp("unsigned int", unit_Type) == 0 || strcmp("long", unit_Type) == 0 || strcmp("unsigned long", unit_Type) == 0 || strcmp("float", unit_Type) == 0) {
		conversion_num = 4;
		convertToByte(sum_number, conversion_num, unit_Type);
	}
	else if (strcmp("long long", unit_Type) == 0 || strcmp("unsigned long long", unit_Type) == 0 || strcmp("double", unit_Type) == 0) {
		conversion_num = 8;
		convertToByte(sum_number, conversion_num, unit_Type);
	}
	else if (strcmp("kb", unit_Type) == 0) {
		conversion_num = 1000;
		convertToByte(sum_number, conversion_num, Unit_typeupper);
	}
	else if (strcmp(unit_Type, "mb") == 0) {
		conversion_num = 1000000;
		convertToByte(sum_number, conversion_num, Unit_typeupper);
	}
	else if (strcmp(unit_Type, "gb") == 0) {
		conversion_num = 1000000000;
		convertToByte(sum_number, conversion_num, Unit_typeupper);
	}
	else if (strcmp(unit_Type, "tb") == 0) {
		conversion_num = 1000000000000;
		convertToByte(sum_number, conversion_num, Unit_typeupper);
	}
	else if (strcmp(unit_Type, "pb") == 0) {
		conversion_num = 1000000000000000;
		convertToByte(sum_number, conversion_num, Unit_typeupper);
	}
	else if (strcmp(unit_Type, "eb") == 0) {
		conversion_num = 1000000000000000000;
		convertToByte(sum_number, conversion_num, Unit_typeupper);
	}
	else if (strcmp(unit_Type, "kib") == 0) {
		conversion_num = 1024;

		convertToByte(sum_number, conversion_num, "KiB");
	}
	else if (strcmp(unit_Type, "mib") == 0) {
		conversion_num = 1048576;
		convertToByte(sum_number, conversion_num, "MiB");
	}
	else if (strcmp(unit_Type, "gib") == 0) {
		conversion_num = 1073741824;
		convertToByte(sum_number, conversion_num, "GiB");
	}
	else if (strcmp(unit_Type, "tib") == 0) {
		conversion_num = 1099511627776;
		convertToByte(sum_number, conversion_num, "TiB");
	}
	else if (strcmp(unit_Type, "pib") == 0) {
		conversion_num = 1125899906842624;
		convertToByte(sum_number, conversion_num, "PiB");
	}
	else if (strcmp(unit_Type, "eib") == 0) {
		conversion_num = 1152921504606846976;
		convertToByte(sum_number, conversion_num, "EiB");
	}
	else {

		printf("ERROR: The unit type \"%s\" is not recognized\n", Unit_typeupper);
		printf("usage: dddd.ddd unittype");
	}

	return EXIT_SUCCESS;
}
