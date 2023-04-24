#pragma once

#include <iostream>

template <typename T>
class BinaryTree
{
	struct Node
	{
		Node* left_child;
		Node* right_child;
		T data;

		Node(const T& value) : left_child(nullptr), right_child(nullptr)
		{
			this->data = value;
		}
	};

	Node* root_node_; //this it the first node in our tree

	//find the node we are going to attach our child node to
	Node* find_parent_node(Node* starting_node, const T& value); 
	
	//depth first traversals
	void print_in_order_traversal(Node* current_node);
	void print_pre_order_traversal(Node* current_node);
	void print_post_order_traversal(Node* current_node);

	//breadth first traversal
	void print_level(Node* current_node, const int level);
	int height(Node* node);
	void print_breadth_first(Node* current_node);

public:
	enum class traversal_type
	{
		in_order,
		pre_order,
		post_order,
		breadth_first
	};

	BinaryTree() : root_node_(nullptr) {}
	void insert(const T& value);
	void print(const traversal_type type);
};

template <typename T>
typename BinaryTree<T>::Node* BinaryTree<T>::find_parent_node(Node* starting_node, const T& value)
{
	Node* result = starting_node;
	if (value < starting_node->data)
	{
		if (starting_node->left_child != nullptr)
		{
			return find_parent_node(starting_node->left_child, value);
		}
	}
	else if (starting_node->right_child != nullptr)
	{
		return find_parent_node(starting_node->right_child, value);
	}

	return result;
}

template <typename T>
void BinaryTree<T>::print_in_order_traversal(Node* current_node)
{
	//if the node doesn't exist nothing to print
	if (current_node == nullptr)
	{
		return;
	}

	//print left nodes first
	print_in_order_traversal(current_node->left_child);

	//print current node
	std::cout << current_node->data << ", ";

	//print right nodes
	print_in_order_traversal(current_node->right_child);
}

template <typename T>
void BinaryTree<T>::print_pre_order_traversal(Node* current_node)
{
	//if the node doesn't exist nothing to print
	if (current_node == nullptr)
	{
		return;
	}

	//print current node
	std::cout << current_node->data << ", ";

	//print left nodes first
	print_pre_order_traversal(current_node->left_child);

	//print right nodes
	print_pre_order_traversal(current_node->right_child);
}

template <typename T>
void BinaryTree<T>::print_post_order_traversal(Node* current_node)
{
	//if the node doesn't exist nothing to print
	if (current_node == nullptr)
	{
		return;
	}

	//print left nodes first
	print_post_order_traversal(current_node->left_child);

	//print right nodes
	print_post_order_traversal(current_node->right_child);

	//print current node
	std::cout << current_node->data << ", ";
}

template <typename T>
void BinaryTree<T>::print_level(Node* current_node, const int level)
{
	if (current_node == nullptr)
	{
		return;
	}

	if (level == 1)
	{
		std::cout << current_node->data << ", ";
	}
	else if (level > 1)
	{
		print_level(current_node->left_child, level - 1);
		print_level(current_node->right_child, level - 1);
	}
}

template <typename T>
int BinaryTree<T>::height(Node* node)
{
	if (node == nullptr)
	{
		return 0;
	}

	//compute the height of each subtree
	const int l_height = height(node->left_child);
	const int r_height = height(node->right_child);

	//use the larger value of the two
	if (l_height > r_height)
	{
		return l_height + 1;
	}

	return r_height + 1;
}

template <typename T>
void BinaryTree<T>::print_breadth_first(Node* current_node)
{
	const int h = height(current_node);

	for (int i = 1; i <= h; i++)
		print_level(current_node, i);
}

template <typename T>
void BinaryTree<T>::insert(const T& value)
{
	Node* new_node = new Node(value);

	if (root_node_ == nullptr)
	{
		root_node_ = new_node;
		return;
	}

	//walk the tree to find the insertion point
	Node* current_node = root_node_;

	Node* parent_node = find_parent_node(root_node_, value);

	if (value < parent_node->data)
	{
		parent_node->left_child = new_node;
	}
	else
	{
		parent_node->right_child = new_node;
	}
}

template <typename T>
void BinaryTree<T>::print(const traversal_type type)
{
	switch (type)
	{
	case traversal_type::in_order:
		print_in_order_traversal(root_node_);
		break;

	case traversal_type::pre_order:
		print_pre_order_traversal(root_node_);
		break;

	case traversal_type::post_order:
		print_post_order_traversal(root_node_);
		break;


	case traversal_type::breadth_first:
		print_breadth_first(root_node_);
		break;
	}
}
