/*
 * Program:         PasswordManager.exe
 * Module:          PasswordManager.cs
 * Date:            00-00-0000
 * Author:          Hassan Ihsan
 * Description:     password manager program to save your  passwords
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;            // File class
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

namespace PasswordManager
{
    class Program
    {
        private static readonly string JSON_FILE = "account-data.json"; // Directory:  ../passwordmanager/bin/debug (output location)

        //a version of the schema is located in this directory:        // Directory:  ../passwordmanager/bin/debug 
        private static string SCHEMA_FILE = "account-schema.json";

        public static List<Accounts> accountList = new List<Accounts>();

        //Method Name : Main Method
        //Purpose: the starter method. this is where the program gets started
        //Date: 0000/00/00
        static void Main(string[] args)
        {
             
            Console.WriteLine("PASSWORD MANAGEMENT SYSTEM ");
             

            //simple check for json files exits or not.....
            if(File.Exists(JSON_FILE))
            {
                MainMenu();
            }
            else
            {
                MainMenu();
            }
        }

        //Method Name : MainMenu()
        //Purpose: this is where the main menu is. this is the begenning of the program
        //         where all the options for the user to select are listed
        //Date: 0000/00/00
        public static void MainMenu()
        {
            Console.WriteLine();

            string userinput;
            int accountid = 0;

            do
            {
                Console.WriteLine("──────────────────────────────────────────");
                Console.WriteLine("│\t\t Account Entries\t│");
                Console.WriteLine("──────────────────────────────────────────");

                //checks if file exists
                //if files exitst then loads the file and displays the id and description
                if (File.Exists(JSON_FILE))
                {
                    //load items to list 
                    LoadJson();   
                    //foreach account object in List
                    foreach(Accounts accnt in accountList)
                    {
                        Console.WriteLine("│ " + accnt.accountId + ". " + accnt.Description);
                        accountid = accnt.accountId;
                    }
                }
                else
                { 
                    Console.WriteLine("There are No Entrys");
                }



                Console.WriteLine("──────────────────────────────────────────");
                Console.WriteLine("│ Press # from the above to select an entry");
                Console.WriteLine("│ Press A to add a new entry\t\t\t");
                Console.WriteLine("│ Press x to quit\t\t");
                Console.WriteLine("──────────────────────────────────────────");
                Console.WriteLine();

                Console.Write("Enter A Command: ");
                userinput = Console.ReadLine().ToUpper();

                //if user enters a number (change string input to int)
                bool isNumber = int.TryParse(userinput, out int numbervalue);  

                //checks if the the numbervalue given by user exits as an account id (...)
                foreach(Accounts accnt in accountList.ToList())
                {
                    //checks if the entered user is in json file
                    if(isNumber && numbervalue == accnt.accountId)
                    {
                        EditAccount(accnt);
                    }
                }
                if (userinput == "A")
                {
                    //goes to adding new account
                    addNewEntry(accountList, accountid);
                     
                }
                  

            } while (!userinput.Equals("X"));
        }

        //Method Name : EditAccount()
        //Purpose:  is there are already account created this is where the user can access them 
        //          meaning the user can look at the account information and edit the password if needed
        //Date: 0000/00/00
        public static void EditAccount(Accounts accnt)
        {
            string userinput;
             
            //foreach password in account (for editing the password)
            foreach (password pass in accnt.password)
            {

                Console.WriteLine("──────────────────────────────────────────");
                Console.WriteLine("│ " + accnt.accountId + ". " + accnt.Description);
                Console.WriteLine("──────────────────────────────────────────");

                Console.WriteLine("│ User ID:\t\t" + accnt.userId);
                Console.WriteLine("│ Password:\t\t" + pass.value);
                Console.WriteLine("│ Password Strength:\t" + pass.strentext + " (" + pass.strennum + "%)");
                Console.WriteLine("│ login URL:\t\t" + accnt.loginURL);
                Console.WriteLine("│ Account #:\t\t" + accnt.accountnum);
                Console.WriteLine("──────────────────────────────────────────");

                Console.WriteLine("│ Press P to change Password");
                Console.WriteLine("│ Press D to delete this entry");
                Console.WriteLine("│ Press M to return to main menu");
                Console.WriteLine("──────────────────────────────────────────");
                Console.WriteLine();

                Console.Write("Enter a command: ");
                userinput = Console.ReadLine().ToUpper();

                if (userinput == "P")
                {
                    //enter a new password
                    Console.Write("New Password: ");
                    pass.value = Console.ReadLine();
                    WriteToJsonFIle(accountList);
                }
                else if (userinput == "D")
                {
                    //if you want to delete the given account
                    Console.Write("Delete? (Y/N):");
                    userinput = Console.ReadLine().ToUpper();
                    if (userinput == "Y")
                    {
                        accountList.Remove(accnt);
                        WriteToJsonFIle(accountList);
                    }
                }
                else if (userinput == "M")
                {
                    MainMenu();
                }
            }
            
        }

        //Method Name : addNewEntry()
        //Purpose:  this is where the user can create a new account object(instance)
        //          and load that obect to an array then print out the array to a json file
        //Date: 0000/00/00
        public static void addNewEntry(List<Accounts> alist, int accountid)
        {
            //for datetime
            DateTime dateNow = DateTime.Now;

            Console.WriteLine("please key-in values for the following fields...\n");

            //creating new account/password objects
            Accounts accnt = new Accounts();
            password pass = new password();

            //for json schema
            string json_schema;

            //reading json file and puting it to string
            if (ReadFile(SCHEMA_FILE, out json_schema))
            {

                //do while input values
                bool valid;
                do
                {
                    //asign values to the given items
                    accountid++;

                    accnt.accountId = accountid;
                    Console.Write("Description: ");
                    accnt.Description = Console.ReadLine();
                    Console.Write("User ID: ");
                    accnt.userId = Console.ReadLine();

                    Console.Write("Password: ");
                    pass.value = Console.ReadLine();
                    PasswordTester pw = new PasswordTester(pass.value);

                    pass.strennum = pw.StrengthPercent;
                    pass.strentext = pw.StrengthLabel;
                    pass.lastreset = dateNow.ToShortDateString();
                    accnt.AddItem(pass);


                    Console.Write("Login url: ");
                    accnt.loginURL = Console.ReadLine();



                    //validation
                    valid = ValidateItem(accnt, json_schema);

                    //if not valid show error retry and break loop (this is confusing and odd...)
                    //eaiser ways to do this
                    if (!valid)
                    {
                        Console.WriteLine("ERROR: Invalid account information entered. please try again.");
                        addNewEntry(alist, accountid);
                        break;

                    }


                    Console.Write("Account #: ");
                    accnt.accountnum = Console.ReadLine();

                    //add account to list
                    alist.Add(accnt);
                } while (!valid);
            }
            else
            {
                Console.WriteLine("Error:\t unable to read the schema file");
            }
            
            //write list to json file
            WriteToJsonFIle(alist);
             
        }

        //Method Name :  WriteToJsonFIle()
        //Purpose:   the purpose of this method is to write list to json file
        //Date: 0000/00/00
        public static void WriteToJsonFIle(List<Accounts> aList)
        {
            //converts list to string and write to file
            string json = JsonConvert.SerializeObject(aList);
            File.WriteAllText(JSON_FILE, json);
        }

        //Method Name : LoadJson()
        //Purpose:   the purpose of this is to load the json file and put it into list
        //Date: 0000/00/00
        public static void LoadJson()
        {
            //reads data from .json file 
            using (StreamReader r = new StreamReader(JSON_FILE))
            {
                //puts data into string
                string json = r.ReadToEnd();
                //deserializes the object and put it into array
                accountList = JsonConvert.DeserializeObject<List<Accounts>>(json);
                 
            }
        }

        //Method Name : LoadJson()
        //Purpose:   the purpose of this is to Validates an item object against a schema (incomplete)
        //Date: 0000/00/00 
        private static bool ValidateItem(Accounts item, string json_schema)
        {
            // Convert item object to a JSON string 
            string json_data = JsonConvert.SerializeObject(item);

 
            // return statement to return 'true' if item is valid, or 'false', if invalid.
            JSchema schema = JSchema.Parse(json_schema);
            JObject itemObj = JObject.Parse(json_data);
            return itemObj.IsValid(schema);

        } // end ValidateItem()

        //Method Name : LoadJson()
        //Purpose:   the purpose of this is to Attempt to read the json file specified
        //           by 'path' into the string 'json', Returns 'true' if successful or 'false' if it fails
        //Date: 0000/00/00 
        private static bool ReadFile(string path, out string json)
        {
            try
            {
                // Read JSON file data 
                json = File.ReadAllText(path);
                return true;
            }
            catch
            {
                json = null;
                return false;
            }
        } // end ReadFile()
    } // end class


    
}
