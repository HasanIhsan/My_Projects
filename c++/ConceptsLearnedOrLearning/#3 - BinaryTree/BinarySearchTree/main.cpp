#include "BinaryTree.h"

/*	          unbalanced_tree
 *				  0
 *				   \
 *					1
 *					 \
 *					  2
 *                     \
 *                      3
 *						 \
 *						  4
 *						   \
 *						    5
 *						     \
 *						      6
 *						       \
 *						        7
 *						         \
 *						          8
 *					               \
 *							        9
 *				balanced_tree
 *						5
 *					   / \
 *					  /   \
 *					 2     7
 *                  / \   / \
 *				   1   3 6   8
 *				  /     \     \
 *				 0       4     9
 */

constexpr int VALUE_TO_SEARCH_FOR = 9;

int main(int argc, char* argv[])
{
	BinaryTree<int> unbalanced_tree;
	for (int i = 0; i < 10; ++i)
	{
		unbalanced_tree.insert(i);
	}
	unbalanced_tree.print(BinaryTree<int>::traversal_type::in_order);

	//we will just hack this for now (later this class we will make the tree self balancing) 
	BinaryTree<int> balanced_tree;
	balanced_tree.insert(5);

	balanced_tree.insert(2);
	balanced_tree.insert(1);
	balanced_tree.insert(0);
	balanced_tree.insert(3);
	balanced_tree.insert(4);

	balanced_tree.insert(7);
	balanced_tree.insert(6);
	balanced_tree.insert(8);
	balanced_tree.insert(9);

	balanced_tree.print(BinaryTree<int>::traversal_type::in_order);

	//lets search for a value in the tree
	BinaryTree<int>::Node* node = unbalanced_tree.search_iteratively(VALUE_TO_SEARCH_FOR);
	node = balanced_tree.search_iteratively(VALUE_TO_SEARCH_FOR);

	//now lets do the same binary search but recursively instead
	node = unbalanced_tree.search_recursively(VALUE_TO_SEARCH_FOR);
	node = balanced_tree.search_recursively(VALUE_TO_SEARCH_FOR);

	//lets find a simple way to check if the tree is balanced
	//we will check that the max path lengths (left/right) are within 1 level of each other
	// Note: we could still have an unbalanced tree if subtrees are unbalanced
	//       see if you can find an way to check if the tree is 'Complete' (see week 7 slides)
	std::cout << "unbalanced_tree is " << (unbalanced_tree.is_balanced() ? "balanced" : "not balanced") << std::endl;

	//lets create a function to rebuild our tree (balanced)
	unbalanced_tree.rebalance();

	//check if it meets our requirement
	std::cout << "unbalanced_tree is " << (unbalanced_tree.is_balanced() ? "balanced" : "not balanced") << std::endl;
	
	node = unbalanced_tree.search_recursively(VALUE_TO_SEARCH_FOR);
	node = balanced_tree.search_recursively(VALUE_TO_SEARCH_FOR);


}

