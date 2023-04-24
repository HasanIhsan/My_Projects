#pragma once
/*
* FileName: Binary_DesisionTree
* purpose: this is where the data is processed and the result either a true for benign or false for malignint is outputted
*		   this code looks prob simular to the simple_decisiontree we did in class(node based?)
* Programmer: Hassan Ihsan
* Data: ///
*/

//the parameters class
class Params
{
public:
	//all the prameters
	int Clump_thickness;
	int Uniformity_of_cell_size;
	int Uniformity_of_cell_shape;
	int Marginal_Adhesion;
	int Single_Epithelial_cell_size;
	int Bare_nuclei;
	int Bland_chromatin;
	int Normal_nucleoli;
	int Mitoses;
	
	//default constuctor
	Params() : Clump_thickness(0), Uniformity_of_cell_size(0), Uniformity_of_cell_shape(0), Marginal_Adhesion(0), Single_Epithelial_cell_size(0),
		Bare_nuclei(0), Bland_chromatin(0), Normal_nucleoli(0), Mitoses(0){}
};

//dcision tree based on true or false
class Node
{
public:
	using processing_function_type = bool(*)(Node* node, const Params& parms);

	//true and false branch
	processing_function_type branch_selector;
	Node* true_branch_node;
	Node* false_branch_node;

	//default constructor
	Node(const processing_function_type function, Node* true_node = nullptr, Node* false_node = nullptr)
		: branch_selector(function), true_branch_node(true_node), false_branch_node(false_node) {}

	//process function for prameters
	bool process(const Params& params)
	{
		return branch_selector(this, params);
	}


};

//return true for benign
bool Benign_true(Node* node, const Params& params)
{
	return true;
}

//return false for malignant 
bool Malignant_false(Node* node, const Params& params)
{
	return false;
}

//test the data for wether it is benign or maligant
bool benign_or_maligant(Node* node, const Params& params)
{
	//this was given to us in the worksheet i simply put it into code using ifelse statements
	//again benign is true and malignt is false...

	if (params.Uniformity_of_cell_size <= 2)
	{
		if (params.Bare_nuclei <= 3)
		{
			return node->true_branch_node->process(params);
		}
		else  
		{
			if (params.Clump_thickness <= 3)
			{
				return node->true_branch_node->process(params);
			}
			else  
			{
				if (params.Bland_chromatin <= 2)
				{
					if (params.Marginal_Adhesion <= 3)
					{
						return node->false_branch_node->process(params);
					}
					else  
					{
						return node->true_branch_node->process(params);
					}
				}
				else  
				{
					return node->false_branch_node->process(params);
				}
			}
		}
	}
	else  
	{
		if (params.Uniformity_of_cell_shape <= 2)
		{
			if (params.Clump_thickness <= 5)
			{
				return node->true_branch_node->process(params);
			}
			else 
			{
				return node->false_branch_node->process(params);
			}
		}
		else 
		{
			if (params.Uniformity_of_cell_size <= 4)
			{
				if (params.Bare_nuclei <= 2)
				{
					if (params.Marginal_Adhesion <= 3)
					{
						return node->true_branch_node->process(params);
					}
					else  
					{
						return node->false_branch_node->process(params);
					}
				}
				else  
				{
					if (params.Clump_thickness <= 6)
					{
						if (params.Uniformity_of_cell_size <= 3)
						{
							return node->false_branch_node->process(params);
						}
						else 
						{
							if (params.Marginal_Adhesion <= 5)
							{
								return node->true_branch_node->process(params);
							}
							else  
							{
								return node->false_branch_node->process(params);
							}
						}
					}
					else  
					{
						return node->false_branch_node->process(params);
					}
				}
			}
			else 
			{
				return node->false_branch_node->process(params);
			}
		}
	}
}
