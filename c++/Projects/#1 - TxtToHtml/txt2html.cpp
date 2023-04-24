/*
    Program Name: txt2html
    Programmer: Hassan Ihsan
    Date: ///
*/

#include <iostream>
#include <sstream>
#include <string>
#include <fstream>

using namespace std;


int creatHtml(char* argv[], int FileInput, int FirstSwitch,  int secondSwitch, string fileoutputname) {
    ifstream textFile; //input file
      
    ofstream htmlFile; //output file

    // -r -b or -rb
    if (strcmp(argv[FirstSwitch], "-r") == 0 && strcmp(argv[secondSwitch], "-b") == 0 || strcmp(argv[FirstSwitch], "-rb") == 0) 
    {
        textFile.open(argv[FileInput], std::ios::binary);
        htmlFile.open(fileoutputname + ".html");

        int lines = 0;

        if (!textFile) 
        {
            cout << "Error: could not open " << argv[FileInput] << " for input.";
            return EXIT_FAILURE;
        }
        if (htmlFile) 
        {
           
            htmlFile << "<html>" << '\n' << "<head>" << '\n' << "<title>" << fileoutputname << "</title>" << '\n' << "</head>" << '\n' <<
                "<body>" << '\n';
            
            char c;
             
            while (textFile.get(c)) 
            {
                htmlFile.put(c);
                
                if ('\r' == c || '\n' == c) 
                { 
                    lines++;
                }  
                if ('\n' == c) 
                {
                    htmlFile << "<br>";
                }   
            }
            htmlFile <<'\n' << "</body>" << '\n' << "</html>" << '\n';
        }
        
        cout << "Input lines processed, counting untranslated newline character: " << lines << endl;
       
        textFile.close();
        htmlFile.close();
        return EXIT_SUCCESS;
    }
     // -r -p or -rp
    else if (strcmp(argv[FirstSwitch], "-r") == 0 && strcmp(argv[secondSwitch], "-p") == 0 || strcmp(argv[FirstSwitch], "-rp") == 0)
    {
        textFile.open(argv[FileInput]);
        htmlFile.open(fileoutputname + ".html");

        int lines = 0;

        if (!textFile) 
        {
            cout << "Error: could not open " << argv[FileInput] << " for input.";
            return EXIT_FAILURE;
        }
        
        if (htmlFile) 
        {

            htmlFile << "<html>" << '\n' << "<head>" << '\n' << "<title>" << fileoutputname << "</title>" << '\n' << "</head>" << '\n' <<
                "<body>" << '\n';

            string line = "\n";
            while (getline(textFile, line)) 
            {

                htmlFile << "<p>"<< line << "</p>" << '\n';
                lines++;
            } 
            htmlFile << '\n' << "</body>" << '\n' << "</html>" << '\n';
        }
        
        cout << "Input lines processed, counting translated newline character: " << lines << endl;

        textFile.close();
        htmlFile.close();
        return EXIT_SUCCESS;
    }
    // just -r
    else if (strcmp(argv[FirstSwitch], "-r") == 0) 
    {
        
        textFile.open(argv[FileInput]);
        htmlFile.open(fileoutputname + ".html");

        int lines = 0;

        if (!textFile) 
        {
            cout << "Error: could not open " << argv[FileInput] << " for input.";
            return EXIT_FAILURE;
        }
       
        if (htmlFile) 
        {

            htmlFile << "<html>" << '\n' << "<head>" << '\n' << "<title>" << fileoutputname << "</title>" << '\n' << "</head>" << '\n' << '\n' <<
                "<body>" << '\n'; 
            
            char c;  

            while (textFile.get(c)) 
            {
                htmlFile.put(c);

                if ('\n' == c) 
                {
                    htmlFile << "<br>";
                    lines++; 
                } 
            }
            htmlFile << '\n' << "</body>" << '\n' << "</html>" << '\n'; 
        }

        cout << "Input lines processed, counting translated newline character: " << lines << endl;

        textFile.close();
        htmlFile.close();
        return EXIT_SUCCESS;
    }
    //if not switches are added
    else 
    {
        textFile.open(argv[FileInput]);
         htmlFile.open(fileoutputname + ".html");
        
        if (!textFile) 
        {
            cout << "Error: could not open " << argv[FileInput] << " for input.";
            return EXIT_FAILURE;
        }
        if (htmlFile) 
        {

            htmlFile << "<html>" << '\n' << "<head>" << '\n' << "<title>" << fileoutputname << "</title>" << '\n' << "</head>" << '\n' << '\n'<<
                "<body>" << '\n';

            string line = "";
            while (getline(textFile, line))
            {

                htmlFile << line << "<br>" << '\n';

            }

            htmlFile << '\n'<< "</body>" << '\n' << "</html>" << '\n';

        }

        textFile.close();
        htmlFile.close();
        return EXIT_SUCCESS;
    }
  


    return EXIT_SUCCESS;
}

int main(int argc, char* argv[])
{
    
    
    if (argc == 2) //if only 2 things entered into command line (txt2html.exe story.txt)
    {
        // .txt
        string userstatename = argv[1]; 
        userstatename.erase(userstatename.length() - 4); 
        creatHtml(argv, 1, NULL, NULL, userstatename);
        return EXIT_SUCCESS;
    }
    else if (argc == 3) // if there are 3 thing enterd into the command line (txt2html.exe story.txt story1.html) or  (txt2html.exe -r story.txt ) or (txt2html.exe -rp story.txt )
    {

    
        if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-r") == 0) 
        {
            // .txt -r
            string userstatename = argv[1]; 
            userstatename.erase(userstatename.length() - 4); 
            creatHtml(argv, 1, 2,   NULL, userstatename);
            return EXIT_SUCCESS;
        } 
        else if (strcmp(argv[2] + strlen(argv[2]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0) 
        {
            // -r .txt
            string userstatename = argv[2]; 
            userstatename.erase(userstatename.length() - 4); 
            creatHtml(argv, 2, 1,  NULL, userstatename);
            return EXIT_SUCCESS;
        }
        if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-rp") == 0)
        {
            // .txt -rp
            string userstatename = argv[1]; 
            userstatename.erase(userstatename.length() - 4); 
            creatHtml(argv, 1, 2,   NULL, userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[2] + strlen(argv[2]) - 4, ".txt") == 0 && strcmp(argv[1], "-rp") == 0) 
        {
            // -rp .txt
            string userstatename = argv[2]; 
            userstatename.erase(userstatename.length() - 4); 
            creatHtml(argv, 2, 1,   NULL,userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-rb") == 0)
        {
            // .txt -rb
            string userstatename = argv[1]; 
            userstatename.erase(userstatename.length() - 4);
            creatHtml(argv, 1, 2,   NULL,userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[2] + strlen(argv[2]) - 4, ".txt") == 0 && strcmp(argv[1], "-rb") == 0) 
        {
            // -rb .txt
            string userstatename = argv[2]; 
            userstatename.erase(userstatename.length() - 4); 
            creatHtml(argv, 2, 1,  NULL,userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2] + strlen(argv[2]) - 5, ".html") == 0)
        {
            //.txt .html
            string userstatename = argv[2];
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 1, NULL,   NULL, userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[2] + strlen(argv[2]) - 4, ".txt") == 0 && strcmp(argv[1] + strlen(argv[1]) - 5, ".html") == 0)
        {
            //.txt .html
            cerr << "Error: there must be a .txt file before a .html file.'" << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 &&  strcmp(argv[2] + strlen(argv[2]) - 5, ".html") != 0) 
        {
            // .txt not .html
            cerr << "Error: there must be a valid outfile name with a .html extension." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }
        else 
        {
            //if anything other then the commands listed is put into comamnd line
            cerr << "Error: there must be a .txt file before a .html file. \n";
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }

    }
    else if (argc == 4) //if there are 4 things entered into the command line (txt2html.exe -r story.txt story1.html) or (txt2html.exe -r -b story.txt)
    {
        
       
        
        if (strcmp(argv[2] + strlen(argv[2]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[3] + strlen(argv[3]) - 5, ".html") == 0)
        {
            //-r .txt .html
            string userstatename = argv[3]; 
            userstatename.erase(userstatename.length() - 5); 
            creatHtml(argv, 2, 1,   NULL, userstatename);
            return EXIT_SUCCESS; 
        } 
        else if (strcmp(argv[2] + strlen(argv[2]) - 4, ".txt") == 0 && strcmp(argv[1], "-rp") == 0 && strcmp(argv[3] + strlen(argv[3]) - 5, ".html") == 0)
        {
            //-rp .txt .html
            string userstatename = argv[3];
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 2, 1, NULL, userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[2] + strlen(argv[2]) - 4, ".txt") == 0 && strcmp(argv[1], "-rb") == 0 && strcmp(argv[3] + strlen(argv[3]) - 5, ".html") == 0)
        {
            //-rb .txt .html
            string userstatename = argv[3];
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 2, 1, NULL, userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-r") == 0 && strcmp(argv[3] + strlen(argv[3]) - 5, ".html") == 0)
        {
            // .txt -r .html
            string userstatename = argv[3]; 
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 1, 2,  NULL,userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-rb") == 0 && strcmp(argv[3] + strlen(argv[3]) - 5, ".html") == 0)
        {
            // .txt -rb .html
            string userstatename = argv[3];
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 1, 2, NULL, userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-rp") == 0 && strcmp(argv[3] + strlen(argv[3]) - 5, ".html") == 0)
        {
            // .txt -rp .html
            string userstatename = argv[3];
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 1, 2, NULL, userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[3] + strlen(argv[3]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[2], "-b") == 0) 
        {
            // -r -b .txt
            string userstatename = argv[3]; 
            userstatename.erase(userstatename.length() - 4);
            creatHtml(argv, 3, 1,  2,userstatename);
            return EXIT_SUCCESS; 
        }
        else if (strcmp(argv[3] + strlen(argv[3]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[2], "-p") == 0 )
        {
            // -r -p .txt 
            string userstatename = argv[3];
            userstatename.erase(userstatename.length() - 4);
            creatHtml(argv, 3, 1, 2,userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-r") == 0 && strcmp(argv[3], "-p") == 0) 
        {      // .txt -r -p
            string userstatename = argv[1];
            userstatename.erase(userstatename.length() - 4);
            creatHtml(argv, 1, 2,   3,userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-r") == 0 && strcmp(argv[3], "-b") == 0) 
        {
            //  .txt -r -b
            string userstatename = argv[1];
            userstatename.erase(userstatename.length() - 4);
            creatHtml(argv, 1, 2,  3,userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[3], "-rp") == 0   && strcmp(argv[2] + strlen(argv[2]) - 5, ".html") == 0)
        {
            //.txt .html -rp
            string userstatename = argv[2];
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 1, 3, NULL, userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[3], "-rb") == 0 && strcmp(argv[2] + strlen(argv[2]) - 5, ".html") == 0)
        {
            //.txt .html -rb
            string userstatename = argv[2];
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 1, 3, NULL, userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-r") == 0 && strcmp(argv[3], "-bp") == 0) 
        {
            //  .txt -r -bp
            cerr << "Error: cannot have binary and paragraph switches together." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }else  if (strcmp(argv[2] + strlen(argv[2]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[3] + strlen(argv[3]) - 5, ".html") != 0)
        {
            // -r .txt not .html (ex .hss)
            cerr << "Error: there must be a valid outfile name with a .html extension." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;

        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-r") == 0 && strcmp(argv[3] + strlen(argv[3]) - 5, ".html") != 0)
        {
            //.txt -r not .html (ex .hss)
            cerr << "Error: there must be a valid outfile name with a .html extension." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }
        else if (strcmp(argv[3] + strlen(argv[3]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[2], "-bp") == 0)
        {
            // -r -bp .txt
            cerr << "Error: cannot have binary and paragraph switches together." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }
        else
        {
            //anything other then what the commands specified 
            cerr << "Error: there must be a .txt file before a .html file.'" << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }
    }
    else if (argc == 5) //if there are five commands entered into the command line ( txt2html.exe -r -b story.txt story1.html)
    {
    
        
        if (strcmp(argv[3] + strlen(argv[3]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[2], "-b") == 0 && strcmp(argv[4] + strlen(argv[4]) - 5, ".html") == 0) 
        {
            //-r -b .txt .html
            string userstatename = argv[4];
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 3, 1,   2,userstatename);
            return EXIT_SUCCESS; 
        }
        else if (strcmp(argv[3] + strlen(argv[3]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[2], "-p") == 0 && strcmp(argv[4] + strlen(argv[4]) - 5, ".html") == 0) 
        {
            //  -r -p .txt .html
            string userstatename = argv[4];
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 3, 1,   2,userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-r") == 0 && strcmp(argv[3], "-b") == 0 && strcmp(argv[4] + strlen(argv[4]) - 5, ".html") == 0)
        {
            // .txt -r -b .html
            string userstatename = argv[4];
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 1, 2,   3,userstatename);
            return EXIT_SUCCESS;

        } 
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-r") == 0 && strcmp(argv[3], "-p") == 0 && strcmp(argv[4] + strlen(argv[4]) - 5, ".html") == 0)
        {
            // .txt -r -p .html
            string userstatename = argv[4];
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 1, 2,   3,userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[3], "-r") == 0 && strcmp(argv[4], "-b") == 0 && strcmp(argv[2] + strlen(argv[2]) - 5, ".html") == 0)
        {
            //.txt .html -r -b
            string userstatename = argv[2];
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 1, 3,   4,userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[3], "-r") == 0 && strcmp(argv[4], "-p") == 0 && strcmp(argv[2] + strlen(argv[2]) - 5, ".html") == 0)
        {
            //.txt .html -r -p
            string userstatename = argv[2];
            userstatename.erase(userstatename.length() - 5);
            creatHtml(argv, 1, 3,   4, userstatename);
            return EXIT_SUCCESS;
        }
        else if (strcmp(argv[3] + strlen(argv[3]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[2], "-bp") == 0 && strcmp(argv[4] + strlen(argv[4]) - 5, ".html") == 0)
        {
            //  -r -bp .txt .html
            cerr << "Error: cannot have binary and paragraph switches together." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }
        else if (strcmp(argv[4] + strlen(argv[4]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[2], "-b") == 0 && strcmp(argv[3] + strlen(argv[3]) - 5, ".html") == 0)
        {
            //-r -b .txt .html
            cerr << "Error: there must be a valid outfile name with a .html extension." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;

        }
        else if (strcmp(argv[4] + strlen(argv[4]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[2], "-p") == 0 && strcmp(argv[3] + strlen(argv[3]) - 5, ".html") == 0)
        {
            //  -r -p .txt .html
            cerr << "Error: there must be a valid outfile name with a .html extension." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-r") == 0 && strcmp(argv[3], "-p") == 0 && strcmp(argv[4], "-b") == 0)
        {
            //.txt -r -p -b
            cerr << "Error: cannot have binary and paragraph switches together." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        } 
        else if (strcmp(argv[1] + strlen(argv[1]) - 4, ".txt") == 0 && strcmp(argv[2], "-r") == 0 && strcmp(argv[3], "-b") == 0 && strcmp(argv[4], "-p") == 0)
        {
            //.txt -r -b -p
            cerr << "Error: cannot have binary and paragraph switches together." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }  
        else if (strcmp(argv[4] + strlen(argv[4]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[2], "-p") == 0 && strcmp(argv[3], "-b") == 0)
        {
            //-r -p -b .txt
            cerr << "Error: cannot have binary and paragraph switches together." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        } 
        else if (strcmp(argv[4] + strlen(argv[4]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[2], "-b") == 0 && strcmp(argv[3], "-p") == 0)
        {
            // -r -b -p .txt
            cerr << "Error: cannot have binary and paragraph switches together." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }
        else if (strcmp(argv[3] + strlen(argv[3]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[2], "-b") == 0 && strcmp(argv[4] + strlen(argv[4]) - 5, ".html") != 0)
        {
            //-r -b .txt  not   .html
            cerr << "Error: there must be a valid outfile name with a .html extension." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }
        else if (strcmp(argv[3] + strlen(argv[3]) - 4, ".txt") == 0 && strcmp(argv[1], "-r") == 0 && strcmp(argv[2], "-p") == 0 && strcmp(argv[4] + strlen(argv[4]) - 5, ".html") != 0)
        {
            //  -r -p .txt not   .html
            cerr << "Error: there must be a valid outfile name with a .html extension." << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }
        else 
        {
            //aything other then the commands specified
            cerr << "Error: there must be a .txt file before a .html file.'" << endl;
            cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
            cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
            return EXIT_FAILURE;
        }
       

    }
    else
    {
        //if user enters more then 5 comands into command line
        cerr << "Error: Error: Invalid input. Incorrect number of parameters '" << argc << "." << endl;
        cerr << "txt2html, (c) 2021, Hassan Ihsan\n";
        cerr << "Usage: txt2html [-r(-b|-p)] sourcefile destinationfile\n";
        return EXIT_FAILURE;
    }

    return EXIT_SUCCESS;
}
