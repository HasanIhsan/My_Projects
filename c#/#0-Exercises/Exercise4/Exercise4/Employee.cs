namespace Exercise4
{
    internal partial class Program
    {
        public class Employee
        {
            //properties 
            public int ID { get; set; }
            public string Name { get; set; }
            public double Salary { get; set; } = 1000;
            public double Bonus { get; set; } = 0;
            public double Tax { get; set; } = 0;
            public double NetIncome { get; set; }
            public int Year { get; set; }


            //default constructor 
            public Employee(int id, string name, double salary, double bonus)
            {
                ID = id;
                Name = name;
                Salary = salary;
                Bonus = bonus;
                Bonus = bonus;
            }

            //void method (will be used to update when method gets the calcuclated values)
            public void UpdatePayroll(double tax, double netincome, int year)
            {
                Tax = tax;
                NetIncome = netincome;
                Year = year;
            }


            //overriden tostring
            public override string ToString()
            {
                return $"The Calculated net income and tax of the Employee {Name} with ID {ID} is ({NetIncome},{Tax}) for the year {Year}";
            }
        }
    }
} 