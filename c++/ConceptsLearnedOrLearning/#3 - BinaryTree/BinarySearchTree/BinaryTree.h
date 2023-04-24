#pragma once

#include <iostream>
#include <vector>

template <typename T>
class BinaryTree
{
public:
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

protected:
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

	//internal recursive node search
	Node* recursive_search_internal(Node* node, const T& value, int* recursive_calls);

	//rebalance
	unsigned int internal_count_nodes(const Node* node);
	void store_in_order_array(std::vector<T>& in_order_array, Node* node);
	Node* reconstruct(const std::vector<T>& in_order_array, const int low, const int high);
	
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

	Node* search_iteratively(const T& value);
	Node* search_recursively(const T& value);

	void rebalance();
	unsigned int size();

	bool is_balanced();
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
typename BinaryTree<T>::Node* BinaryTree<T>::recursive_search_internal(Node* node, const T& value, int* recursive_calls)
{
	++* recursive_calls;
	//node is nullptr or is a match return (base case)
	if (!node || node->data == value)
	{
		return node;
	}

	if (value < node->data)
	{
		return recursive_search_internal(node->left_child, value, recursive_calls);
	}

	return recursive_search_internal(node->right_child, value, recursive_calls);
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

	if(!is_balanced())
	{
		//rebalance();
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

template <typename T>
typename BinaryTree<T>::Node* BinaryTree<T>::search_iteratively(const T& value)
{
	int iterations = 1;
	auto* node = root_node_;
	while (node && node->data != value)
	{
		if (value < node->data)
		{
			node = node->left_child;
		}
		else
		{
			node = node->right_child;
		}

		++iterations;
	}

	std::cout << "Search Loop Iterations: " << iterations << std::endl;

	return node;
}

template <typename T>
typename BinaryTree<T>::Node* BinaryTree<T>::search_recursively(const T& value)
{
	int recursive_calls = 0;
	Node* node = recursive_search_internal(root_node_, value, &recursive_calls);

	std::cout << "Search Recursive Calls: " << recursive_calls << std::endl;
	return node;
}

template <typename T>
typename BinaryTree<T>::Node* BinaryTree<T>::reconstruct(const std::vector<T>& in_order_array, const int low,
	const int high)
{
	if (low > high) return nullptr;

	int mid = low + (high - low) / 2;

	Node* root = new Node(in_order_array[mid]);

	root->left_child = reconstruct(in_order_array, low, mid - 1);
	root->right_child = reconstruct(in_order_array, mid + 1, high);

	return root;
}

template <typename T>
void BinaryTree<T>::rebalance()
{
	//store in-order values into an array or vector
	std::vector<T> in_order_nodes;
	store_in_order_array(in_order_nodes, root_node_);

	root_node_ = reconstruct(in_order_nodes, 0, in_order_nodes.size() - 1);
}

template <typename T>
unsigned BinaryTree<T>::internal_count_nodes(const Node* node)
{
	unsigned int count = 1;
	if (node->left_child != NULL)
	{
		count += internal_count_nodes(node->left_child);
	}
	if (node->right_child != NULL)
	{
		count += internal_count_nodes(node->right_child);
	}
	return count;
}

template <typename T>
void BinaryTree<T>::store_in_order_array(std::vector<T>& in_order_array, Node* node)
{
	if (!node) return;

	store_in_order_array(in_order_array, node->left_child);
	in_order_array.push_back(node->data);
	store_in_order_array(in_order_array, node->right_child);

	delete node;
}

template <typename T>
unsigned BinaryTree<T>::size()
{
	if (!root_node_) { return 0; }

	return internal_count_nodes(root_node_);
}

template <typename T>
bool BinaryTree<T>::is_balanced()
{
	if (root_node_ == nullptr)
	{
		return true;
	}

	//naive approach (as all subtrees are not checked if they are balanced)
	//this just compares the max heights of the left/right subtrees
	//we could change this function to make this an AVL (height balanced tree) if needed
	int left_subtree_height = 0;
	int right_subtree_height = 0;

	if (root_node_->left_child)
	{
		left_subtree_height = height(root_node_->left_child);
	}

	if (root_node_->right_child)
	{
		right_subtree_height = height(root_node_->right_child);
	}

	return abs(left_subtree_height - right_subtree_height) <= 1;
}

