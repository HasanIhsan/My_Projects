
#include <iostream>
#include <string>

using hash_type = int;

hash_type hash_bad(const std::string& message)
{
	hash_type hash = 0;
	for(const auto& ch : message)
	{
		hash += static_cast<hash_type>(ch);
	}
	
	return hash;
}

hash_type hash_better(const std::string& message)
{
	hash_type hash = 0;
	int i = 0;
	for(const auto& ch : message)
	{
		hash += static_cast<hash_type>(ch) * ++i;
	}
	
	return hash;
}

hash_type hash_djb2(const std::string& message)
{
	hash_type hash = 5381;
	int i = 0;
	for(const auto& ch : message)
	{
		hash = ((hash << 5) + hash) + ch;
	}
	
	return hash;
}

using func_type = hash_type(*)(const std::string&);

void process(const std::string& message, const func_type hash_function)
{
	const std::string dog = "dog";
	const std::string god = "god";

	std::cout << message << " == " << static_cast<unsigned>(hash_function(message)) << std::endl;
}

int main(int argc, char* argv[])
{
	/*for(int i=0; i<26;++i)
	{
		std::string str = {static_cast<char>(i + 62)};
		std::cout
			<< static_cast<char>(i + 62)
			<< " == "
			<< static_cast<unsigned>(hash_bad(str))
			<< std::endl;
	}*/

	//return 0;

	std::cout << "Bad Hash:" << std::endl;
	process("dog", hash_bad);
	process("god", hash_bad);
	std::cout << std::endl;
	
	std::cout << "Better Hash:" << std::endl;
	process("dog", hash_better);
	process("god", hash_better);
	std::cout << std::endl;
	
	std::cout << "DJB2 Hash:" << std::endl;
	process("dog", hash_djb2);
	process("god", hash_djb2);
	std::cout << std::endl;
	
}
