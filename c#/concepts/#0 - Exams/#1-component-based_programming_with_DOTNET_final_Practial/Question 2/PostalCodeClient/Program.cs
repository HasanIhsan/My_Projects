/*
 * Program:         PostalCodeClient.exe
 * Module:          Program.cs
 * Author:          T. Haworth
 * Date:            Feb 16, 2023
 * Description:     A console client for a simple component application that validates 
 *                  and formats Canadian postal codes.
 */

using PostalCodeLibrary;  // PostalCode class

namespace PostalCodeClient
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Postal Code Validator and Formatting Utility");

            // Create an instance of the PostalCode class
            PostalCode postalCode = new ();

            string codeInput;
            do
            {

                // Ask the user to input the ISBN-13 value
                Console.Write("\nEnter a postal code or press ENTER to quit: ");
                codeInput = Console.ReadLine()?.Trim() ?? "";

                if (codeInput.Length > 0)
                {
                    // Initialize the ISBN13 object
                    postalCode.SetCode(codeInput);

                    // Redisplay the number
                    Console.WriteLine("\n\tThe postal code you entered is: " + postalCode.GetOriginalCode());

                    // Validate the number
                    Console.WriteLine("\tThis is a" + (postalCode.IsValid() ? " " : "n in") + "valid code.");

                    // Display reformatted code
                    if (postalCode.IsValid())
                    {
                        Console.WriteLine("\tThe properly formatted postal code is: {0}", postalCode.GetFormattedCode());
                    }
                }
            } while (codeInput.Length > 0);

            Console.WriteLine("All done. Press a key to exit.");
            Console.ReadKey();

            postalCode.Dispose();
        } // end Main()
    }
}