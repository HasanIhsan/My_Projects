using System.Xml.Linq;

namespace Exercise6
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
           
     
            string[] words = { "Hi", "Canada", "Please", "Stay", "Safe" };

            //testing the linqOrLambdaMethods

            //linqfirstchar and lamdafirstchar
            string linqFirstChar = words.LinqFirstCharacter();
            Console.WriteLine($"showing The first character in the words array using QEN Are {linqFirstChar}");

            string lambdaFirstChar = words.LambdaFirstCharacter();
            Console.WriteLine($"Showing the first chracter of every word uwing DN are {lambdaFirstChar}");

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            //linqlongestword and lambda longest worod 
            string linqLongestWord = words.LinqLongestWord();
            Console.WriteLine($"The longest word in array using QEN is {linqLongestWord}");

            string lambdaLongestWord = words.LambdaLongestWord();
            Console.WriteLine($"The longest word in array using DN is {lambdaLongestWord}");

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            //linqShortestWord and lambdaSHortestword
            string linqShortestWord = words.LinqShortestWord();
            Console.WriteLine($"The shortest word in array using QEN is {linqShortestWord}");

            string lambdaShortestWord = words.LambdaShortestWord();
            Console.WriteLine($"The Shortest word in array using DN is {lambdaShortestWord}");

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            //linqwordCount and lambdawordcount
            string linqWordsCount = words.LinqWordsCount();
            Console.WriteLine($"The number of words in array using QEN is {linqWordsCount}");

            string lambdaWordsCount = words.LambdaWordsCount();
            Console.WriteLine($"The number of words in array using DN is {lambdaWordsCount}");


            List<City> cityList = new List<City>()
            {
                new City("London","ON",330000),
                new City("Toronto","ON",5213000),
                new City("Vancouver","BC",2313328),
                new City("Nelson","BC",11779),
                new City("Montreal","QB",3678000),
                new City("Québec","QB",624177)
            };


            //testing the city methods
            //sorted citys
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Sorted List of all cities: ");

            var sortedCities = cityList.SortedCities(); 
            foreach(City city in sortedCities)
            {
                Console.WriteLine(city);
            }


            //citybyprovince
            Console.WriteLine(); 
            Console.WriteLine("--------------------------------------------------------------------------");
            var IGoupCityByProvince = cityList.CitiesByProvince(); 

            foreach (var province in IGoupCityByProvince)
            {
                Console.WriteLine($"city in Province {province.Key}");
                Console.WriteLine("***************************");
                foreach (var city in province)
                {
                    Console.WriteLine( city.cityName);
                }
            }


            //province and population
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Provinces with population: ");
            var proviPopulation = cityList.ProvincesPopulation();
            foreach(var item in proviPopulation)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}