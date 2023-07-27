namespace Exercise7
{
    public class Program
    {
         

        static async Task Main(string[] args)
        {
            //vars
            string choice = "", url = "", longestword = "", word = "", longestUrl = "";
            string[] urls;
            int length;
            bool found;

            Dictionary<string, int> wordCount;


           


            do 
            {

                //this the user can do
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Get page length");
                Console.WriteLine("2. Get largest page");
                Console.WriteLine("3. Does Word Exits");
                Console.WriteLine("4. Get word count in multiple pages");
                Console.WriteLine("5. Exit");

                choice = Console.ReadLine();
                Console.WriteLine();

                //if user wasnt to get the page length
                if (choice == "1")
                {
                    //ask for url
                    Console.WriteLine("Please enter a URL:");
                    url = Console.ReadLine();

                    //do a try catch
                    try
                    {
                        //use the getpagelength method to get the page lengh
                        length = await WebAsyncMethods.GetPageLength(url);
                        Console.WriteLine($"The length of the page at {url} is {length} characters.");
                    }
                    catch (Exception ex)
                    {
                        //throw error if any
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                //if user wants to get the largest page between 2 different pages
                else if (choice == "2")
                {
                    ///asking user to enter urls comma seprated
                    Console.WriteLine("Please enter URLs separated by commas:");
                    urls = ParseUrls(Console.ReadLine());
                    try
                    {
                        //use the getlargestpage method 
                        longestUrl = await WebAsyncMethods.GetLargestPage(urls);
                        Console.WriteLine($"The longest page is at {longestUrl}.");
                    }
                    catch (Exception ex)
                    {
                        //throw error if any
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                //if user wants to see if there is a word in a page
                else if (choice == "3")
                {
                    Console.WriteLine("Please enter a word:");
                    word = Console.ReadLine();
                    Console.WriteLine("Please enter a URL:");
                    url = Console.ReadLine();
                    try
                    {
                        //use the method iswordfound
                        found = await WebAsyncMethods.IsWordFound(word, url);
                        if (found)
                        {
                            //the word is found
                            Console.WriteLine($"The word '{word}' was found in the page at {url}.");
                        }
                        else
                        {
                            //no it was not found
                            Console.WriteLine($"The word '{word}' was not found in the page at {url}.");
                        }
                    }
                    catch (Exception ex)
                    {
                        //throw error if any
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                //ge the word count of a certian word from many differnt urls
                else if (choice == "4")
                {
                    //ask user for a word, amd urls
                    Console.WriteLine("Please enter a word:");
                    word = Console.ReadLine();
                    Console.WriteLine("Please enter URLs separated by commas:");
                    urls = ParseUrls(Console.ReadLine());
                    try
                    {
                        //get the wordcount
                        wordCount = await WebAsyncMethods.GetWordCount(word, urls);
                        Console.WriteLine("Word counts:");
                        foreach (var item in wordCount)
                        {

                            Console.WriteLine($"{item.Key}: {item.Value}");
                        }


                    }
                    catch (Exception ex)
                    {
                        //throw Error if any
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                //quit the progam
                else if (choice == "5")
                {
                    //break the loop
                    break;
                }
                else
                {
                    //the user choice is wrong
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                }

                Console.WriteLine();


            } while (choice != "5");
        }


        // Helper method
        static string[] ParseUrls(string input)
        {
            return input?.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim().ToLowerInvariant())
                .ToArray() ?? Array.Empty<string>();
        }
    }
}