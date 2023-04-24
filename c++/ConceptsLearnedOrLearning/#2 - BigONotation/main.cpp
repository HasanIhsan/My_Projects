#include <cassert>
#include <iostream>
#include <vector>

/*
 * Time complexity: O(1)
 *
 * O(1) is also called "constant time"
 * this means the function requires
 * exactly one step to complete
 *
 */
template<typename T>
void print_element(const std::vector<T>& items, typename std::vector<T>::size_type index)
{
	assert(index < items.size() && "index out of bounds");

	//we directly access the data here
	//this always takes exactly one step
	std::cout << items[index];   //constant time (direct access via random access operator[])
}

/*
 * Time complexity: O(1)
 *
 * directly access two elements each time
 * still constant time
 *
 */
template<typename T>
void print_element_pair(const std::vector<T>& items, typename std::vector<T>::size_type index1, typename std::vector<T>::size_type index2)
{
	assert((index1 < 0 || index1 < items.size()) && "index1 out of bounds");
	assert((index2 < 0 || index2 < items.size()) && "index2 out of bounds");

	print_element(items, index1);  // +1 (direct access)
	std::cout << " , ";
	print_element(items, index2);  // +1 (direct access)
	std::cout << std::endl;
}

/*
 * Time complexity: O(n)
 *
 * O(n) is also called "linear time"
 * this means the function requires exactly
 * one step for each element in our container
 *
 */
template<typename T>
void print_elements(const std::vector<T>& items)
{
	//the size of the vector determines how long this algorithm runs
	//every element makes the loop run 1 more iterations (n-times)
	for (typename std::vector<T>::size_type i = 0; i < items.size(); ++i)
	{
		//remember that print_element has a
		//time complexity of O(1) 
		print_element(items, i);
		std::cout << ", ";
	}
	std::cout << std::endl;
}

/*
 * Time complexity: O(n^2)
 *
 * O(n^2) is also called "quadratic time" (O(n) * O(n))
 * here we have a nested loop on our data
 *
 */
template<typename T>
void print_possible_pairs(const std::vector<T>& items)
{
	//this outer loop is the same as going over the vector once O(n)
	for (typename std::vector<T>::size_type i = 0; i < items.size(); ++i)
	{
		//the extra complexity comes from this inner loop also O(n) itself
		for (typename std::vector<T>::size_type j = 0; j < items.size(); ++j)
		{
			print_element_pair(items, i, j);
		}
	}
}

/*
 * Time complexity: O(n^n)
 *
 * O(n^n) is also called "exponential time"
 *
 * with this recursive implementation the algorithm growth
 * doubles with each element added to the data set
 *
 */
int fibonacci(const int number)
{
	if (number <= 1) return number;
	return fibonacci(number - 2) + fibonacci(number - 1);
}

int main(int argc, char* argv[])
{
	//pre-load a vector with integers
	const int num_elements = 3;
	std::vector<int> vector;
	vector.reserve(num_elements);
	for (int i = 0; i < num_elements; ++i)
	{
		vector.push_back(i);
	}

	//lets print individual elements from the vector a few different ways
	//O(1) constant time access to any element
	print_element(vector, 0);
	std::cout << std::endl;
	
	print_element(vector, num_elements / 2);
	std::cout << std::endl;
	
	print_element(vector, num_elements - 1);
	std::cout << std::endl;

	//let print a pair of elements
	//still O(1) constant time
	print_element_pair(vector, 0, num_elements - 1);
	std::cout << std::endl << std::endl;
	
	//now lets print all the values
	//O(n)
	//n=number of elements in the container
	print_elements(vector);
	std::cout << std::endl << std::endl;

	//lets print all the permutations of
	//all the values in the array/vector
	//O(n^2)
	print_possible_pairs(vector);
	std::cout << std::endl << std::endl;

	//calculate the n-th value in the
	//fibonacci sequence recursively
	//O(n^n)
	std::cout << fibonacci(10) << std::endl;
}
