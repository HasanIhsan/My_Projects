#include <iostream>
#include <string>

struct Node
{
	using process_function_type = void(*)(const Node*);

	process_function_type function;
	Node* true_node;
	Node* false_node;

	Node(const process_function_type func, Node* t_node = nullptr, Node* f_node = nullptr)
		: function(func), true_node(t_node), false_node(f_node) {}

	void Process()
	{
		function(this);
	}
};

bool prompt(const std::string& message)
{
	std::cout << message << " ( 1 = YES 2 = NO): ";
	int input;
	std::cin >> input;

	return input == 1;
}

void apple_maybe(const Node*)
{
	std::cout << "maybe you want an apple?" << std::endl;
}

void sinful(const Node*)
{
	std::cout << "wait til better donut" << std::endl;
}

void get_it_now(const Node*)
{
	std::cout << "get it" << std::endl;
}

void jumping_jacks(const  Node*)
{
	std::cout << "do jumping jacks" << std::endl;
}
void what_are_you_waiting_for(const Node*)
{
	std::cout << "what are you waiting for?" << std::endl;
}

void are_you_sure(const Node* node)
{
	prompt("are you sure?") ? node->true_node->Process() : node->false_node->Process();
}

void good_dounut(const Node* node)
{
	prompt("is it a good dounut?") ? node->true_node->Process() : node->false_node->Process();
}
void do_i_deserve(const Node* node)
{
	prompt("do i deserve it?") ? node->true_node->Process() : node->false_node->Process();
}

void want_dounut(const Node* node)
{
	prompt("do i want donut?") ? node->true_node->Process() : node->false_node->Process();
}


int main(int argc, char* argv[])
{
	Node* apple_node = new Node(apple_maybe);
	Node* sinful_node = new Node(sinful);
	Node* waiting_for_node = new Node(what_are_you_waiting_for);
	Node* jumping_node = new Node(jumping_jacks);
	Node* get_it_node = new Node(get_it_now);

	Node* are_you_sure_node = new Node(are_you_sure, get_it_node, jumping_node);
	Node* is_it_a_good_donut_node = new Node(good_dounut, waiting_for_node, sinful_node);

	Node* do_i_deserve_it_node = new Node(do_i_deserve, are_you_sure_node, is_it_a_good_donut_node);

	Node* do_i_want_node = new Node(want_dounut, do_i_deserve_it_node, apple_node);

	do_i_want_node->Process();
	return 0;
}