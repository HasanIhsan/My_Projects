
#define ARRAY_MIXED
#include "array_common.h"

void bubble_sort(int* arr, const int n, int* comparisons, int* swap_count)
{
	//outer loop
	//moves one element to the correct position
	//then checks the next element
	bool swap_flag = false;
	for(int i=0; i < n -1; i++)
	{
		//inner loop
		//check to see if the element we are on needs to be swapped...
		for(int j=0; j < n-i-1; j++)
		{
			++(*comparisons);
			//check if swap needed?
			if(arr[j] > arr[j+1])
			{
				swap_flag = true;
				++(*swap_count);
				swap(&arr[j], &arr[j+1]);
			}
		}

		if(!swap_flag)
		{
			break;
		}
	}
}

void process(int* arr, const int size)
{
	std::cout << "Array Input:\n\t";
	print_array(arr, size);

	int comparisons = 0;
	int swap_count = 0;
	bubble_sort(arr, size, &comparisons, &swap_count);

	std::cout << "Number of comparisons: " << comparisons << std::endl;
	std::cout << "Number of swaps: " << swap_count << std::endl;

	std::cout << "Array Output:\n\t";
	print_array(arr, size);

	std::cout << std::endl << std::endl;
}

int main(int argc, char* argv[])
{
	process(arr_5, ARR_5_SIZE);
	// process(arr_10, ARR_10_SIZE);
}
