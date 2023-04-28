/*
 * Program:         CourseMarkClient.exe
 * Module:          Program.cs
 * Date:            Feb 16, 2023
 * Student Name:    <Type your name here>
 * Description:     Console client to test CourseMarkLibrary.dll.
 * 
 *                  This client is incomplete. 
 *                  -   You must reference your own CourseMarkLibrary 
 *                      and create a Course object where directed in the 
 *                      source code below. 
 *                  -   No other changes should be required!
 */

using CourseMarkLibrary;
using System.Text;

namespace CourseMarkClient
{
    internal class Program
    {
        static void Main()
        {
            // Display a title
            string title = "                 Course Mark Calculation                 ";
            PrintLine(title.Length);
            Console.WriteLine(title);
            PrintLine(title.Length);

            /** 
              * TO DO: Create a CourseMarkLibrary.Course object called 'course'
              */

           
          
            ICourse course = new Course();
            // Obtain data for each course and display a summary
            Console.WriteLine("\nEnter evaluations data...");
            bool done;
            StringBuilder report = new ();
            do
            {
                // Inputs
                string descrip = GetUserTextData("\nDescription", null);
                double basis = GetUserRealData("Out Of Mark", 0, null);
                double earned = GetUserRealData("Marks Earned", 0, basis);
                double weight = GetUserRealData("Course Weight (%)", 0, 100);

                try
                {
                    
                    // Add course 
                    IEvaluation eval = course.AddEvaluation(descrip, basis, earned, weight);

                    // Append evaluation data to a report for the entire course
                    report.Append(String.Format("{0,-20} {1,8:N1} {2,8:0.0} {3,8:N1} {4,8:N1}\n",
                        TruncateToLength(eval.Description, 20), eval.EarnedMarks, eval.BasisMarks, 
                        eval.Weight, eval.CalcPercent()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine();
                done = (GetUserTextData("Add another evaluation? (y/n)", new List<string>() { "Y", "N" }) == "N");

            } while (!done);

            // Report for the semester
            Console.WriteLine("\nHere is your course evaluations report...\n");
            PrintLabels();
            PrintLine(56);
            Console.Write(report.ToString());
            PrintLine(56);
            Console.WriteLine("{0,-20} {1,8:N1} {2,8:N1} {3,8:N1} {4,8:N1}", "Course Totals",
                    course.CalcTotalEarnedMarks(), 100, course.CalcTotalWeight(), course.CalcPercent());

        } // end Main()

        #region helper_code

        //***** DO NO MODIFY ANY CODE BEYOND THIS POINT! *****

        // Obtains string input from the user that must match one of the validValues
        private static string GetUserTextData(string prompt, List<string>? validValues)
        {
            string input;
            bool validInput;
            do
            {
                Console.Write(prompt + ": ");
                input = Console.ReadLine()?.ToUpper() ?? "";
                if (!(validInput = (validValues == null ? input.Length > 0 : validValues.Contains(input))))
                    Console.WriteLine("ERROR: Input provided isn't an expected value.");
            } while (!validInput);
            return input;
        } // end getUserTextData()

        // Obtains a real number (between min and max inclusive, when provided) from the user 
        private static double GetUserRealData(string prompt, double? min, double? max)
        {
            string input;
            double value;
            bool validInput;
            do
            {
                Console.Write(prompt + ": ");
                input = Console.ReadLine() ?? "";
                if (!(validInput = double.TryParse(input, out value)))
                    Console.WriteLine($"ERROR: Input must be a number.");
                else if (!(validInput = min == null || value >= min))
                    Console.WriteLine($"ERROR: Input must not be greater than {max}.");
                else if (!(validInput = max == null || value <= max))
                    Console.WriteLine($"ERROR: Input must not be less than {min}.");
            } while (!validInput);
            return value;
        } // end getUserRealData()

        // Prints column labels for the report table
        private static void PrintLabels()
        {
            Console.WriteLine("{0,-20} {1,8} {2,8} {3,8} {4,8}",
                "Description", "Mark", "Out Of", "Weight", "Percent");
        } // end printLabels()

        // Prints a horizontal line of "length" hyphens
        private static void PrintLine(int length)
        {
            string line = new ('-', length);
            Console.WriteLine(line);
        } // end printLine()

        // Returns a condtionally right-truncated string no longer than 'length'
        private static string TruncateToLength(string text, int length)
        {
            return text.Length > length ? text[..length] : text;
        } // end TruncateToLength()

        #endregion

    } // end Program class
}