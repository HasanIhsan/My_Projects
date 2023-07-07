using System.Resources;
using System;
using static Exercise4.Program;

namespace Exercise4
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
         
            //new list

            List<Employee> listEmployess = new();

            //variable 
            string userInput, name;
            int id = 0;
            double salary, bonus;
            
            //do while which gets the user input for entering employee info
            do
            {
                //update id (aka add 1 every time)
                id++;

                //get user name
                Console.Write("Please enter a employee Name: ");
                name = Console.ReadLine();

                //get user salary
                Console.Write("Please enter Employee Salary: ");
                salary = double.Parse(Console.ReadLine());

                //get empoyee bonus
                Console.Write("Please enter Empoyee Bonus: ");
                bonus= double.Parse(Console.ReadLine());

                //add new employee to list
                listEmployess.Add(new Employee(id, name, salary, bonus));


                //ask if user wants to enter another employee
                Console.Write("would you like to enter another empoyee? (y/n)");
                userInput = Console.ReadLine().ToLower();

                Console.WriteLine();

            } while (userInput != "n");


            
           
            for(int i = 0; i < listEmployess.Count; i++)
            {
                //get the arrays from the calculate tax method
                foreach (var val in CalculateTax(listEmployess))
                {
                    //just uses the last calc values (not each there own seprate values)
                    listEmployess[i].UpdatePayroll(val[0], val[1], (int)val[2]);
                }

               
            }

           
 

            //display all employees with a salary greater the 10,000
            Console.WriteLine("Employees with the net income larger than $10,000");
            Console.WriteLine("--------------------------------------------------");
            listEmployess.FindAll(e => e.Salary > 10000).ForEach(e => Console.WriteLine(e));  
            Console.WriteLine("--------------------------------------------------");


            //sort employees by tax
            listEmployess.Sort((e1, e2) => e1.Tax.CompareTo(e2.Tax));
            listEmployess.ForEach(e => Console.WriteLine(e));

         

        }

        //The accountant uses this method to calculate and return the required tax,
        //net income, and tax year properties to the company.All tax variables and
        //calculations must be declared and implemented within this method only. 
        public static IEnumerable<double[]> CalculateTax(List<Employee> employees)
        {
            double[] calcs = { 0, 0, 0};
            //All associated resources must be disposed of from memory using the tryfinally block
            try
            {  
                //get current tax year
                int currentYear = DateTime.Now.Year - 1;
 
                double grossIncome = 0.0;
                double tax = 0.0;
  
                //calculate the gross income and tax of each employee
                foreach (Employee emp in employees)
                {
                    grossIncome = emp.Salary + emp.Bonus;
                    if (grossIncome <= 50000)
                    {
                        tax = 0.20 * emp.Salary;
                    }
                    else
                    {
                        tax = 0.30 * emp.Salary;
                    }
                    //return the calculated items in a double array
                    //double[] calcs = { tax, grossIncome, currentYear };
                    calcs[0] = tax;
                    calcs[1] = grossIncome;
                    calcs[2] = currentYear;
                    yield return calcs;
                }


 
            }
            finally
            {
                //clean up?
                Array.Clear(calcs, 0, 2);
            }

          
        }

         
    }
} 