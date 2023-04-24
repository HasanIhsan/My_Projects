
#include <iostream>

//int add(const int a, const int b)
//{
//	return a + b;
//}
//
std::string add(const std::string& a, const std::string& b)
{
	return a + b;
}

template <typename T>
T add(const T& a, const T& b)
{
	return a + b;
}

template<>
std::string add<std::string>(const std::string& a, const std::string& b)
{
	return "Something else";
}

int main(int argc, char* argv[])
{
	const int a = 1;
	const int b = 2;
	const std::string c = "Hello";
	const std::string d = "World";

	std::cout << a << " + " << b << " == " << add(a, b) << std::endl;
	std::cout << c << " + " << d << " == " << add(c, d) << std::endl;
}

