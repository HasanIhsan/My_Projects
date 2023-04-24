
#include "BinaryTree.h"

using tree_type = BinaryTree<int>;

int main(int argc, char* argv[])
{
	tree_type tree;

	tree.insert(5);
	tree.insert(1);
	tree.insert(4);
	tree.insert(8);
	tree.insert(0);
	
	/* this is the node structure after the insertions above
	 *              5
	 *             / \
	 *			  /   \
	 *           1     8
	 *		    / \   
	 *		   0   4 
	 */

	std::cout << "Depth First Traversals:\n\n";
	std::cout << "In-order:\n";
	tree.print(tree_type::traversal_type::in_order);

	std::cout << "\n\nPre-order:\n";
	tree.print(tree_type::traversal_type::pre_order);

	std::cout << "\n\nPost-order:\n";
	tree.print(tree_type::traversal_type::post_order);
	std::cout << "\n";

	std::cout << "\n\nBreadth First traversal:\n";
	tree.print(tree_type::traversal_type::breadth_first);
	std::cout << "\n\n";
}
