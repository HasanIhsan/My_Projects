
#define ARRAY_SORTED_DESC
#include "array_common.h"

void selection_sort(int* arr, const int n, int* comparisons, int* swap_count)
{
	for(int i=0; i< n-1; i++)
	{
		//find the next minimum element
		int min_index = i;
		std::cout << min_index << std::endl;
		for(int j= i+1; j < n; j++)
		{
			++(*comparisons);
			if(arr[j] < arr[min_index])
			{
				min_index = j;
			}
		}

		++(*swap_count);
		swap(&arr[min_index], &arr[i]);
	}	
}

void process(int* arr, const int size)
{
	std::cout << "Array Input:\n\t";
	print_array(arr, size);

	int comparisons = 0;
	int swap_count = 0;
	selection_sort(arr, size, &comparisons, &swap_count);

	std::cout << "Number of comparisons: " << comparisons << std::endl;
	std::cout << "Number of swaps: " << swap_count << std::endl;

	std::cout << "Array Output:\n\t";
	print_array(arr, size);

	std::cout << std::endl << std::endl;
}

int main(int argc, char* argv[])
{
	process(arr_5, ARR_5_SIZE);
    //process(arr_10, ARR_10_SIZE);
}
