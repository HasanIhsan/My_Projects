/*
* FileName: main.cpp
* purpose: this is the main
* Programmer: Hassan Ihsan
* Data: ///
*/

#include "Binary_DesisionTree.hpp"

#include <iostream>
#include <fstream>
#include <string>
#include <sstream>

using namespace std;

int main(int argc, char* argv[])
{
	//input stream and output stream (it was not stated that we needed a user input for the file)
	ifstream unformatted_data("unformatted_data_v1.0.0.csv");
	ofstream resultcsv("result.csv");
 
	//calling the nodes for true and false
	//benign = true malignant = false
	Node* Benign_truth = new Node(Benign_true);
	Node* Malignant_falsey = new Node(Malignant_false); 
	Node* Benignt_or_malignant = new Node(benign_or_maligant, Benign_truth, Malignant_falsey);
	Params params;
	 
	cout << "Diagnosis of Breast Cancer using Decision Tree" << endl;

	//creating variables for the total patients, the total benign and malignant count
	int total_patient_count = 0;
	int total_bengin = 0;
	int total_melignant = 0;

	int patient_ids = 0; // patient id's

	//while loop runs until eof 
	string file_data;
	while (!unformatted_data.eof()) {
		++total_patient_count;

		//read data as rows from file to string stream
		getline(unformatted_data, file_data);
		stringstream astring_stream;
		astring_stream << file_data;
		
		//this is for the last where there is no inputted data
		// loop breaks if there is a ""
		if (file_data == "")
		{
			break;
		}

		//get patient id: is ignored in the decision making process, will be used later for the result.csv
		string patient_id;
		getline(astring_stream, patient_id, ','); 
		patient_ids = stol(patient_id);

		//get the clump thickness
		string clump_thickness;
		getline(astring_stream, clump_thickness, ','); 
		params.Clump_thickness = stol(clump_thickness);

		//get the uniformity of cell size
		string uniformity_of_cell_size;
		getline(astring_stream, uniformity_of_cell_size, ',');
		params.Uniformity_of_cell_size = stol(uniformity_of_cell_size);
			 
		//get the uniformity of cell shape	 
		string uniformity_of_cell_shape;
		getline(astring_stream, uniformity_of_cell_shape, ',');
		params.Uniformity_of_cell_shape = stol(uniformity_of_cell_shape);
			
		//get the marginal adhesion	 
		string marginal_adhesion;
		getline(astring_stream, marginal_adhesion, ',');
		params.Marginal_Adhesion = stol(marginal_adhesion);
			
		//get the single epithelial cell size 
		string single_epithelial_cell_size;
		getline(astring_stream, single_epithelial_cell_size, ',');
		params.Single_Epithelial_cell_size = stol(single_epithelial_cell_size);
			 
		//get the bare nuclei	 
		string bare_nuclei;
		getline(astring_stream, bare_nuclei, ',');
		if (bare_nuclei == "?")
		{
			//there are a few ? marks in the unformated file if there are the replace them with a 1
			params.Bare_nuclei = 1;
		}
		else
		{
			params.Bare_nuclei = stol(bare_nuclei);
		}
			 
		//get the bland_chromatin
		string bland_chromatin;
		getline(astring_stream, bland_chromatin, ',');
		params.Bland_chromatin = stol(bland_chromatin);
			
		//get the normal nucleoli	 
		string normal_nucleoli;
		getline(astring_stream, normal_nucleoli, ',');
		params.Normal_nucleoli = stol(normal_nucleoli);
			 
		//the the mitoses	 
		string mitoses;
		getline(astring_stream, mitoses, ',');
		params.Mitoses = stol(mitoses);
			
		//get the temp answer : this is ignored
		//in the unformated file the temp answer is a 0 we replace that with a 2 = benign or 4 = malignant
		string temp_answer;
		getline(astring_stream, temp_answer, ',');
			 
			 
			 
		
		 
		if (Benignt_or_malignant->process(params))
		{
			++total_bengin;
			/*std::cout << patient_ids << "," << params.Clump_thickness << "," << params.Uniformity_of_cell_size << "," << params.Uniformity_of_cell_shape << ","
				<< params.Marginal_Adhesion << "," << params.Single_Epithelial_cell_size << "," << params.Bare_nuclei << "," << params.Bland_chromatin
				<< "," << params.Normal_nucleoli << "," << params.Mitoses << "," << "benign" << std::endl;*/

			 
			resultcsv << patient_ids<<","<< params.Clump_thickness << "," << params.Uniformity_of_cell_size << "," << params.Uniformity_of_cell_shape << ","
				<< params.Marginal_Adhesion << "," << params.Single_Epithelial_cell_size << "," << params.Bare_nuclei << "," << params.Bland_chromatin
				<< "," << params.Normal_nucleoli << "," << params.Mitoses << "," << "2" << std::endl;
		}
		else
		{
			++total_melignant;
			/*std::cout << patient_ids << "," << params.Clump_thickness << "," << params.Uniformity_of_cell_size << "," << params.Uniformity_of_cell_shape << ","
				<< params.Marginal_Adhesion << "," << params.Single_Epithelial_cell_size << "," << params.Bare_nuclei << "," << params.Bland_chromatin
				<< "," << params.Normal_nucleoli << "," << params.Mitoses << "," << "malign" << std::endl;*/

			resultcsv <<patient_ids<<","<< params.Clump_thickness << "," << params.Uniformity_of_cell_size << "," << params.Uniformity_of_cell_shape << ","
				<< params.Marginal_Adhesion << "," << params.Single_Epithelial_cell_size << "," << params.Bare_nuclei << "," << params.Bland_chromatin
				<< "," << params.Normal_nucleoli << "," << params.Mitoses << "," << "4" << std::endl;
		}
		 

			 
	}

	//print the totals
	cout << "Total Patients Processed: " << total_patient_count << endl;
	cout << "Total Benign: " << total_bengin << endl;
	cout << "Total Malignant: " << total_melignant << endl;

	return 0;
}