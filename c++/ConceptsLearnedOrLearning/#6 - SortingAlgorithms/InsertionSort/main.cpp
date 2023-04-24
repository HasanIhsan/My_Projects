
#define ARRAY_MIXED
#include "array_common.h"

void insertion_sort(int* arr, const int n, int* comparisons, int* swap_count)
{
	for (int i = 1; i < n; i++)
	{
		const int key = arr[i];
		int j = i - 1;

		//move all the values that are greater than
		//key one position ahead of their current position
		while(j>=0 && arr[j] > key)
		{
			++(*swap_count);
			arr[j+1] = arr[j];
			--j;
		}

		arr[j+1] = key;
	}
}

void process(int* arr, const int size)
{
	std::cout << "Array Input:\n\t";
	print_array(arr, size);

	int comparisons = 0;
	int swap_count = 0;
	insertion_sort(arr, size, &comparisons, &swap_count);

	//std::cout << "Number of comparisons: " << comparisons << std::endl;
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
