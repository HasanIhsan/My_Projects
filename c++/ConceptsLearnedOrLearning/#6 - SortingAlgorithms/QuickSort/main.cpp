//#define ARRAY_SORTED_ASC
//#define ARRAY_SORTED_DESC
#define ARRAY_MIXED

#include "array_common.h"

int partition(int* arr, const int low, const int high)
{
	const int pivot_value = arr[high];
	int i = (low - 1); //index for smaller elements

	for(int j=low; j < high; j++)
	{
		//check if we need to swap elements
		if(arr[j] <= pivot_value)
		{
			i++;
			swap(&arr[i], &arr[j]);
		}
	}

	swap(&arr[i+1], &arr[high]);

	return (i + 1);
}

void quick_sort(int* arr, const int low, const int high)
{
	if (low < high)
	{
		const int partition_index = partition(arr, low, high);

		quick_sort(arr, low, partition_index - 1);
		quick_sort(arr, partition_index + 1, high);
	}
}

void process(int* arr, const int size)
{
	std::cout << "Array Input:\n\t";
	print_array(arr, size);

	quick_sort(arr, 0, size - 1);

	std::cout << "Array Output:\n\t";
	print_array(arr, size);

	std::cout << std::endl << std::endl;
}

int main(int argc, char* argv[])
{
	process(arr_5, ARR_5_SIZE);
	//process(arr_10, ARR_10_SIZE);
}
