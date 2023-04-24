/*
* Program Name: simple student databse management system
* Purpose: This is a simple student database management system developed in C++ (also uses a but of C concepts). It utilizes file 
		   handling and shows effective implementation of class and object of the programming language. 
		   This project has add, list, modify and delete records functions.
* Programmer: Hassan Ihsan
* Date ----/--/--
*/

//diablse fopen thing
#define _CRT_SECURE_NO_DEPRECATE

//imports
#include <iostream>
#include <cstdio>
#include <cstring>
#include <cstdlib>
#include <conio.h> //header file used mostly by MS-DOS compilers to provide console input/output
#include <iomanip>
#include <fstream>


//main 
int main()
{
	//variables
	
	FILE* p_file, * p_fileT;
	char another, choice = '.'; //reaclly bad programming....

	//student struct.... could do class but this is simple in this context and works
	struct student
	{
		char first_name[50], last_name[50];
		char course[100];
		int section;
	};

	//delecrations 
	struct student aStudent;
	//place holders to search
	char modlast_name[50];
	long int rec_size;

	//fopen:  opens the file specified by filename and associates a stream with it
	//"rb+":  rb+ Open a binary file for both reading and writing
	p_file = fopen("students.txt", "rb+");

	//if file is null create a file
	if (p_file == NULL)
	{
		 
		p_file = fopen("students.txt", "wb+");

		if (p_file == NULL)
		{
			std::cout << "cannot open file" << std::endl;
			return 0;
		}
	}

	//set rec_size to te size of a student recod
	//sizeof:  compile-time operator that determines the size, in bytes, of a variable or data type
	rec_size = sizeof(aStudent);

	while (choice != '5')
	{
		//uses the system console command "cls" to clear the console
		system("cls");  

		std::cout << "\t\t  database management system " << std::endl;
		
		std::cout << std::endl;
		std::cout << std::endl;

		std::cout << "\t\t\t 1.ADD " << std::endl;
		std::cout << "\t\t\t 2.LIST " << std::endl;
		std::cout << "\t\t\t 3.MODIFY " << std::endl;
		std::cout << "\t\t\t 4.DELETE " << std::endl;
		std::cout << "\t\t\t 5.EXIT " << std::endl;

		std::cout << std::endl;
		std::cout << std::endl;

		std::cout << "\t\t\t Select your choice (1 - 5): =>";

		//fflush: flushes any buffered data to the respective device
		fflush(stdin);

		//getche: a C function to read a single character from the keyboard which displays immediately on screen without waiting for the enter key
		choice = _getche();

		switch (choice)
		{
			//add a student record
			case '1':
				//fseek: used to move file pointer associated with a given file to a specific position
				//SEEK_END: It denotes end of the file
				fseek(p_file, 0, SEEK_END);
				another = 'Y';

				while (another == 'Y' || another == 'y')
				{
					system("cls");

					std::cout << "Enter the First Name: ";
					std::cin >> aStudent.first_name;

					std::cout << "\nEnter the Last Name: ";
					std::cin >> aStudent.last_name;

					std::cout << "\nEnter the Course: ";
					std::cin >> aStudent.course;

					std::cout << "\nEnter the Section: ";
					std::cin >> aStudent.section;

					//fwrite:  writes count number of objects, each of size size bytes to the given output stream
					fwrite(&aStudent, rec_size, 1, p_file);
					std::cout << "\nAdd another record (Y/N): ";

					fflush(stdin);

					another = getchar();
				}
			break;

			//view all student records
			case '2': 
				system("cls");

				std::cout << "**** view all records in databse ****" << std::endl;
				
				//fread():  reads the block of data from the stream
				while (fread(&aStudent, rec_size, 1, p_file) == 1)
				{
					std::cout << std::endl;
					
					//setw: C++ manipulator which stands for set width.
					std::cout << aStudent.first_name << std::setw(10) << aStudent.last_name << std::endl;
					std::cout << aStudent.course << std::setw(8) << aStudent.section << std::endl;
				}
				std::cout << std::endl;
				
				//Windows-specific command, which tells the OS to run the pause program.
				system("pause");
			break;

			//modify the student record
			case '3':
				system("cls");

				another = 'Y';

				while (another == 'Y' || another == 'y')
				{
					std::cout << "\n Enter the last name of the student : ";
					std::cin >> modlast_name; //search holder

					rewind(p_file);

					//this does not modify certian values 
					//simply put it updates all values 
					//so you would have to enter all data again
					while (fread(&aStudent, rec_size, 1, p_file) == 1)
					{
						//looks to student with same name as one you enterd
						if (strcmp(aStudent.last_name, modlast_name) == 0)
						{
							std::cout << "Enter new the Firt Name: ";
							std::cin >> aStudent.first_name;

							std::cout << "\nEnter new the Last Name: ";
							std::cin >> aStudent.last_name;

							std::cout << "\nEnter new the Course: ";
							std::cin >> aStudent.course;

							std::cout << "\nEnter new the Section: ";
							std::cin >> aStudent.section;

							//SEEK_CUR: It denotes file pointer's current position
							fseek(p_file, -rec_size, SEEK_CUR);
							fwrite(&aStudent, rec_size, 1, p_file);
							break;
						}
						else
						{
							std::cout << "record not found" << std::endl;
						}
							 
					}

					std::cout << "\n Modify Another Record (Y/N) ";

					fflush(stdin);
					another = getchar();
				}
			break;

			//DELETE a record
			case '4':
				system("cls");

				another = 'Y';

				while (another == 'Y' || another == 'y')
				{
					std::cout << " Enter the last name of the student to delete: " << std::endl;
					std::cin >> modlast_name;// place holder to search

					p_fileT = fopen("temp.dat", "wb"); //opens a temp

					//rewind:  sets the file position indicator to the beginning of the given file stream.
					rewind(p_file);
					while (fread(&aStudent, rec_size, 1, p_file) == 1)

						//looks to student with same name as one you enterd
						if (strcmp(aStudent.last_name, modlast_name) != 0)
						{
							fwrite(&aStudent, rec_size, 1, p_fileT);
						}

					fclose(p_file);
					fclose(p_fileT);

					//remove old record
					remove("students.txt"); 

					//rename temp to students and use as new record
					(void)rename("temp.dat", "students.txt");

					p_file = fopen("students.txt", "rb+");

					std::cout << "\n Delete Another Record (Y/N) ";

					fflush(stdin);
					another = getchar();
				}

			break;
			
			//exit the program
			case '5':
				fclose(p_file);
				std::cout << std::endl;
				std::cout << "\t\tbye bye" << std::endl;
			 
				
			break;

			default:
				std::cout << "WRONG CHOICE" << std::endl;
			break;
		}

	}


	system("pause");
	return 0;
}