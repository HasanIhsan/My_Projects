//Program Name: Program.cs
//Purpose: the client side of project
//Programmer: Hassan Ihsan
//Date: ..../../..

using DocumentBuilderLibrary;

namespace Project2
{
    class Program
    {
        private static ConsoleDirector _director;

        static void Main(string[] args)
        {
            Console.WriteLine("DocumentBuilder Console");
            PrintUsage(new string[1]);

            bool isRunning = true;

            //do while for commands/input
            do
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                var inputList = input.Split(':');
                if (inputList.Length == 0)
                {
                    PrintInvalidInput();
                }
                var command = inputList[0].ToLower();

                switch (command)
                {
                    case "help":
                        PrintUsage(inputList);
                        break;
                    case "mode":
                        SetMode(inputList);
                        break;
                    case "branch":
                        CreateBranch(inputList);
                        break;
                    case "leaf":
                        CreateLeaf(inputList);
                        break;
                    case "close":
                        CloseBranch(inputList);
                        break;
                    case "print":
                        PrintDocument(inputList);
                        break;
                    case "exit":
                        isRunning = false;
                        break;
                    default:
                         PrintInvalidInput();
                        break;
                }
            } while (isRunning);

        }


        //command to print the document
        private static void PrintDocument(string[] inputList)
        {
            if(inputList.Length != 1)
            {
                PrintInvalidInput();
                return;
            }
            if(_director == null)
            {
                PrintModeNotSet();
                return;
            }
            Console.WriteLine(_director.GetDocument().Print(0));
        }

        //command to close the branch root
        private static void CloseBranch(string[] inputList)
        {
            if (inputList.Length != 1)
            {
                PrintInvalidInput();
                return;
            }
            if (_director == null)
            {
                PrintModeNotSet();
                return;
            }
            _director.CloseBranch();
        }

        //command to create a new leaf
        private static void CreateLeaf(string[] inputList)
        {
            if (inputList.Length != 3)
            {
                PrintInvalidInput();
                return;
            }
            if (_director == null)
            {
                PrintModeNotSet();
                return;
            }

            _director.Name = inputList[1];
            _director.Content = inputList[2];
            _director.BuildLeaf();
            _director.Name = "";
            _director.Content = "";
        }

        //command to create a new branch
        private static void CreateBranch(string[] inputList)
        {
            if(inputList.Length != 2)
            {
                PrintInvalidInput();
                return;
            }
            if(_director == null)
            {
                PrintModeNotSet();
                return;
            }

            _director.Name = inputList[1];
            _director.BuildBranch();
            _director.Name = "";
        }

        //command to set mode either json or xml
        private static void SetMode(string[] inputList)
        {
            if (inputList.Length != 2)
            {
                PrintInvalidInput();
                return ;
            }
            var mode = inputList[1].ToLower();

           // Console.WriteLine(mode);
            switch(mode)
            {
                case "json":
                    _director = new ConsoleDirector(new DocumentBuilderLibrary.JSON.Builder());
                    break;
                case "xml":
                    _director = new ConsoleDirector(new DocumentBuilderLibrary.XML.Builder());
                    break;
                default:
                    PrintInvalidInput();
                    break;
            }
        }

        //command for help
       private static void PrintUsage(string[] inputList)
       {
            Console.WriteLine();

            Console.WriteLine("Usage:");

            Console.WriteLine("\thelp                   -Prints Usage (this page).");
            Console.WriteLine("\tmode:<JSON|XML>        -Sets mode to JSON or XML. Must be set before creating or closing.");
            Console.WriteLine("\tbranch:<name>          -Creates a new branch, assigning it the passed name.");
            Console.WriteLine("\tleaf:<name>:<content>  -Creates a new leaf, assigning the passed name and content.");
            Console.WriteLine("\tclose                  -Closes the current branch, as long as it is not the root.");
            Console.WriteLine("\tprint                  -Prints the document in its current state to the console.");
            Console.WriteLine("\texit                   -Exits the application.");

            Console.WriteLine();
            
       }

        //if user enters invalid input
        private static void PrintInvalidInput()
        {
            Console.WriteLine();
            Console.WriteLine("Invalid input. For Usage, type 'Help'");
            Console.WriteLine();
            
        }

        //if user has not set the mode
        private static void PrintModeNotSet()
        {
            Console.WriteLine(); 
            Console.WriteLine("Error. Mode has not been set. For usage, type 'Help'");
            Console.WriteLine();
        }
    }
}
