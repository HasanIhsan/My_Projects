/*
* FileName: Simple_BankRecordSystem.cpp
* Purpose: this is a simple console based bank recording system
*		   it is more of a database project in C++, and is built using the language’s file handling mechanism.
* Programmer: Hassan Ihsan
* Date: ----/--/--
*/


//imports
#include <iostream>
#include <fstream>
#include <cstdlib>
#include <string>

//class for banking information, makes it eaiser to keep track of things we will add or change
class account_query {
private:
	char account_number[20];
	char firstname[10];
	char lastname[10];
	double total_balance;
public:
	void read_data();
	void show_data();
	void write_rec();
	void read_rec();
	void search_rec();
	void edit_rec();
	void delete_rec();
};


/*
* MethodName: read_data();
* purpose: to read in the user data.
*/
void account_query::read_data()
{
	std::cout << "\nEnter The Account Number: ";
	std::cin >> account_number;

	std::cout << "\nEnter your First Name: ";
	std::cin >> firstname;

	std::cout << "\nEnter your Last Name: ";
	std::cin >> lastname;

	std::cout << "\nEnter account Balance: ";
	std::cin >> total_balance;

	std::cout << std::endl;
}

/*
* MethodName: show_data();
* purpose: to this shows the account data.
*/
void account_query::show_data()
{
	std::cout << "Account Number: " << account_number << std::endl;
	std::cout << "First Name: " << firstname << std::endl;
	std::cout << "Last Name: " << lastname << std::endl;
	std::cout << "Current Balance: " << total_balance << std::endl;
	std::cout << "-----------------------------------" << std::endl;
}

/*
* MethodName: write_rec();
* purpose: to write the user info to a text file if needed.
*/
void account_query::write_rec()
{
	std::ofstream bankFileOut;

	//std::ios::binary: Open in binary mode.
	//std::ios::app: All output operations are performed at the end of the file, appending the content to the current content of the file.
	bankFileOut.open("record.bank", std::ios::binary | std::ios::app);
	read_data();

	//reinterpret_cast: It is used to convert a pointer of some data type into a pointer of another data type,
	//					even if the data types before and after conversion are different
	bankFileOut.write(reinterpret_cast<char*>(this), sizeof(*this));

	bankFileOut.close();
}

/*
* MethodName: read_rec();
* purpose: to read the user info from a file called record.bank
*/
void account_query::read_rec()
{
	std::ifstream bankFileIn;
	bankFileIn.open("record.bank", std::ios::binary);

	//if file not found
	if (!bankFileIn)
	{
		std::cout << "Error: File Not Found!" << std::endl;
		return;
	}

	std::cout << "\n*****Data from the file*****" << std::endl;
	//while file is not at the "end of file"
	while (!bankFileIn.eof())
	{
		if (bankFileIn.read(reinterpret_cast<char*>(this), sizeof(*this)))
		{
			show_data();
		}
	}

	bankFileIn.close();
}

/*
* MethodName: search_rec();
* purpose: to search the data stored in the file
*/
void account_query::search_rec()
{
	int RecNum;
	
	std::ifstream bankRecordIn;
	bankRecordIn.open("record.bank", std::ios::binary);

	//file not found
	if (!bankRecordIn)
	{
		std::cout << "Error: File NOT Found!" << std::endl;
		return;
	}

	//seekg: is used to move the position to the end of the file, and then back to the beginning
	//ios::end: logical position used for the relative offset, not an absolute position.
	bankRecordIn.seekg(0, std::ios::end);

	//tellg:  returns the current “get” position of the pointer in the stream
	int count = bankRecordIn.tellg() / sizeof(*this);

	std::cout << "\n There are " << count << " record in the file";
	std::cout << "\n Enter record Number to Search: ";
	std::cin >> RecNum;

	bankRecordIn.seekg((RecNum - 1) * sizeof(*this));
	bankRecordIn.read(reinterpret_cast<char*>(this), sizeof(*this));
	
	show_data();
}

/*
* MethodName: edit_rec();
* purpose: to edit the data of a record stored in the file
*/
void account_query::edit_rec()
{
	int RecNum;
	
	std::fstream bankRecordIo;

	//ios::in: Open for input operations
	bankRecordIo.open("record.bank", std::ios::in | std::ios::binary);

	//file not found
	if (!bankRecordIo)
	{
		std::cout << "Error: File NOT Found!" << std::endl;
		return;
	}

	bankRecordIo.seekg(0, std::ios::end);

	int count = bankRecordIo.tellg() / sizeof(*this);

	std::cout << "\n There are " << count << " records in the file";
	std::cout << "\n Enter the Record Number you would like to edit: ";
	std::cin >> RecNum;

	bankRecordIo.seekg((RecNum - 1) * sizeof(*this));
	bankRecordIo.read(reinterpret_cast<char*>(this), sizeof(*this));

	std::cout << "Recotd " << RecNum << " has the following data: " << std::endl;
	show_data();

	bankRecordIo.close();

	bankRecordIo.open("record.bank", std::ios::out | std::ios::in | std::ios::binary);
	
	//seekp: used to set the position of the pointer in the output sequence with the specified position
	bankRecordIo.seekp((RecNum - 1) * sizeof(*this));

	std::cout << "\n Enter data to modify: " << std::endl;
	read_data();
	
	bankRecordIo.write(reinterpret_cast<char*>(this), sizeof(*this));
}

/*
* MethodName: delete_rec();
* purpose: to delete a record from the save file
*/
void account_query::delete_rec()
{
	int RecNum;

	std::ifstream bankRecordIn;
	bankRecordIn.open("record.bank", std::ios::binary);

	//file not found
	if (!bankRecordIn)
	{
		std::cout << "Error: FILE NOT FOUND!" << std::endl;
		return;
	}

	bankRecordIn.seekg(0, std::ios::end);

	int count = bankRecordIn.tellg() / sizeof(*this);

	std::cout << "\n There are " << count << " record in the file";
	std::cout << "\n Enter the Record Number to Delete: ";
	std::cin >> RecNum;

	std::fstream temPfile;
	temPfile.open("tempfile.bank", std::ios::out | std::ios::binary);

	bankRecordIn.seekg(0);

	for (int i = 0; i < count; i++)
	{
		bankRecordIn.read(reinterpret_cast<char*>(this), sizeof(*this));
		if (i == (RecNum - 1))
		{
			//continue: breaks one iteration (in the loop), if a specified condition occurs, and continues with the next iteration in the loop
			continue;
		}
		temPfile.write(reinterpret_cast<char*>(this), sizeof(*this));
	}

	bankRecordIn.close();
	temPfile.close();


	//remove: deletes a specified file. It is defined in the <cstdio> header file.
	//rename: renames the file represented by the string pointed to by oldname to the string pointed to by newname .
	//        It is defined in <cstdio> header file.
	remove("record.bank");
	(void)rename("tempfile.bank", "record.bank");

}

/*
* MethodName: check_num
* purpose: checks if choice is a number (extra/ eaiser way to do this but wanted to add this:)
*/

//bool check(std::string str)
//{
//	for (int i = 0; i < str.length(); i++)
//	{
//		//if str is a digit
//		if (isdigit(str[i]) == true)
//		{
//			return true;
//		}
//		return false;
//	}
//	 
//}

/*
* MethodName: main
* purpose: is the main
*/
int main()
{
	account_query Accnt;
	//std::string userInput;
	int choiceNum = 1;

	std::cout << "*****Bank Record System*****" << std::endl;
	do
	{
		std::cout << "Select one option:";
		std::cout << "\n\t1--> Add record to file";
		std::cout << "\n\t2--> Show record from file";
		std::cout << "\n\t3--> Search Record from file";
		std::cout << "\n\t4--> Update Record";
		std::cout << "\n\t5--> Delete Record";
		std::cout << "\n\t6--> Quit";
		std::cout << "\nEnter your choice: ";
		std::cin >> choiceNum;

		/*if (!check(userInput))
		{
		 
			choiceNum = std::stoi(userInput);
		}*/


		switch (choiceNum)
		{
		case 1:
				Accnt.write_rec();
			break;
		case 2:
				Accnt.read_rec();
			break;
		case 3:
				Accnt.search_rec();
			break;
		case 4:
				Accnt.edit_rec();
			break;
		case 5:
				Accnt.delete_rec();
			break;
		case 6:
			exit(0);
			break;
		default:
			std::cout << "\nchoice entered is not corrent" << std::endl;
			 
		}
	} while (true); // infinte loop: works in this case but not always the best will change later on

	//system("pause"): Windows-specific command, which tells the OS to run the pause program.
	system("pause");
	return 0;
}