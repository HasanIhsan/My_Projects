/*
 * FIleName: Program.cs
 * Purpose: this is the client part of the project that implements scarabble lib
 * NOTE:
 * Programmer: Hassan Ihsan
 * DATE: ....
 */

using ScrabbleLibrary;

namespace ScrabbleClient
{
    internal class Program
    {
        //main
        static void Main(string[] args)
        {

            //vars
            Bag newbag = new();
            int numOfPayers = 0;
            string inputW = "";
            string word = "";

            
            //initilizing a list of IRack for the player racks
            List<IRack> numRacks = new();

            Console.WriteLine($"Testing ScrabbleLibrary [${newbag.author}]");
             
            Console.WriteLine();

            Console.WriteLine($"Bag Initializaed with the following {newbag.tileCount} tiles");  
            Console.WriteLine(newbag.ToString());
            
            

        
            //choose the number of palyers
            Console.Write("Enter the number of players (1 - 8): ");
            numOfPayers = Int32.Parse(Console.ReadLine());

            Console.WriteLine();

            //  newbag.GenerateRack();
            Console.WriteLine($"racks for {numOfPayers} were populated");

            //generate the amount of rack as there are player
            for (int i = 0; i < numOfPayers; i++)
            {
                numRacks.Add(newbag.GenerateRack());
                
            }

            //tile count in bag (not prop implmented to show the decline in the bag count)
            Console.WriteLine($"Bag now contains the following {newbag.tileCount} tiles...."); //not working prop
            Console.WriteLine(newbag.ToString());

            //main loop to ask for user input 
            do
            {

                //for the number of players (aka racks)
                for (int i = 0; i < numRacks.Count; i++)
                {
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine($"\t\t Player {i+1}");
                    Console.WriteLine("----------------------------------------------");

                    Console.WriteLine($"your Rack contains: {numRacks[i].ToString()}");

                    //ask user to first test a word
                    Console.Write("Test a word for its point value? (y/n): ");
                    inputW = Console.ReadLine();

                    //if user yes
                    if (inputW == "y")
                    {
                        //do a loop for testing word as long as word points is not 0
                        do
                        {

                            //enter a word with the number of letters shown in the rack
                            Console.Write($"Enter a word using the letter {numRacks[i].ToString()}: ");
                            word = Console.ReadLine();

                            //gets the points from the test word
                            Console.WriteLine($"The Word [{word}] is worth {numRacks[i].testWord(word)}");
                            
                            //only ask if word point is zero 
                            if(numRacks[i].testWord(word) == 0)
                            {
                                Console.Write("Test a word for its point value? (y/n): ");
                                inputW = Console.ReadLine();

                                //just to break loop (not prop but works)
                                if (inputW == "n")
                                {
                                    //breaks loop but there are prob better ways of doing this
                                    break;
                                }
                            }
                           
                            
                            
                        } while (numRacks[i].testWord(word) == 0);
                    }
                    //if users says not (not to test a word)
                    else
                    {
                        //make word empty 
                        word = "";
                    }

                        //if the word is empty which if the 
                        if(word == "")
                        {
                            Console.Write($"Enter a word to play using the letter {numRacks[i].ToString()}: ");
                            word = Console.ReadLine();
                        }

                        Console.Write($"Do you want to play the word [{word}]? (y/n): ");
                        inputW = Console.ReadLine().ToLower();

                        if (inputW == "y")
                        {
                            //plays the word
                            numRacks[i].playWord(word);

                            //prints word and total poitns and updated rack
                            Console.WriteLine();
                            Console.WriteLine("\t\t---------------------------------");
                            Console.WriteLine($"\t\tWord Player: \t{word}");
                            Console.WriteLine($"\t\tTotalPoints: \t{numRacks[i].totalPoints}");
                            Console.WriteLine($"\t\tRack now contains: \t{numRacks[i].ToString()}");
                            Console.WriteLine("\t\t---------------------------------");
                            Console.WriteLine();
                        }
                        else
                        {
                            //if a player does not want to play a word then just reste word to null and 
                            //the loop will move to the next player
                            word = "";
                        }
                    

                         

                }

                //once all players have played...
                Console.Write("Would you like each player to take another turn? (y/n)");
                inputW = Console.ReadLine().ToLower();

            } while (inputW != "n");

            Console.WriteLine();
            Console.WriteLine("retiring from the game");

            Console.WriteLine();
            Console.WriteLine("the final scores are: ");
            Console.WriteLine("-----------------------------");
            for (int i = 0; i < numRacks.Count; i++)
            {
            
                Console.WriteLine($"Player {i+1}: {numRacks[i].totalPoints} points");
            }
            Console.WriteLine("-----------------------------");

           
        }
    }
}