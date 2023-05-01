using CsQuery.ExtensionMethods;
using CsQuery.Utility;
using GUI;
namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To exit program, enter 'exit' at any prompt.");
            Console.WriteLine("To start program from the beginning, enter 'restart' at any prompt.");
            Console.WriteLine("You will be presented with a numbered list of options. Please enter a value, when prompted, to a corresponding file name, file type or data querying routine.");
            Console.WriteLine("Fetching list of available file names to be processed and queried.\n");
            Console.WriteLine("1) Canadacities-CSV");
            Console.WriteLine("2) Canadacities-JSON");
            Console.WriteLine("3) Canadacities-XML");

            Console.Write("\nSelect an option from the list above (e.g. 1, 2): ");

            string? fileName = Console.ReadLine();
            string fileType = "";

            switch (fileName)
            {
                case "1":
                    fileName = "Canadacities";
                    fileType = "CSV";
                    break;
                case "2":
                    fileName = "Canadacities";
                    fileType = "JSON";
                    break;
                case "3":
                    fileName = "Canadacities";
                    fileType = "XML";
                    break;
                default:
                    Console.WriteLine("Invalid input. Exiting program...");
                    return;
            }

            Console.WriteLine("\nA city catalogue has now been populated from the " + fileName + "." + fileType + " file.");
            Console.WriteLine("Fetching list of available data querying routines that can be run on the " + fileName + "." + fileType + " file.");

            while (true)
            {
                try {
                    Statistics stats = new Statistics(fileName, fileType);
                    Console.WriteLine("\n1) Display City Information");
                    Console.WriteLine("2) Display Province Cities");
                    Console.WriteLine("3) Calculate Province Population");
                    Console.WriteLine("4) Match Cities Population");
                    Console.WriteLine("5) Distance Between Cities");
                    Console.WriteLine("6) Restart Program And Choose Another File Or File Type To Query");
                    Console.WriteLine("7) Change the population of a city.");
                    Console.WriteLine("8) Exit the program.");
                    Console.Write("\nSelect a data query routine from the list above for the " + fileName + "." + fileType + " file (e.g. 1, 2): ");

                    int querySelection = int.Parse(Console.ReadLine()!);
                    switch (querySelection)
                    {
                        case 1:
                            Console.Write("\nSelect city to display information for: ");
                            string? city = Console.ReadLine();
                            Console.WriteLine("\nDisplaying information for " + city + "...");
                            List<CityInfo> cityInformation = stats.DisplayCityInformation(city!)!;
                            foreach (CityInfo info in cityInformation)
                            {
                                Console.WriteLine(info.ToString());
                            }
                            break;

                        case 2:
                            Console.Write("\nSelect province to display cities for: ");
                            string? province = Console.ReadLine();
                            Console.WriteLine("\nDisplaying cities in province " + province + "...");
                            List<CityInfo> provinceCities = stats.DisplayProvinceCities(province!);
                            foreach (CityInfo info in provinceCities)
                            {
                                Console.WriteLine(info.ToString());
                            }
                            break;

                        case 3:
                            Console.Write("\nEnter province name to calculate population for: ");
                            string? populationProvince = Console.ReadLine();
                            Console.WriteLine("\nCalculating population for province " + populationProvince + "...");
                            int provincePopulation = stats.DisplayProvincePopulation(populationProvince!);
                            Console.WriteLine("The population of the province " + populationProvince + " is: " + provincePopulation);
                            break;

                        case 4:
                            Console.Write("\nEnter first city name: ");
                            string? firstCityName = Console.ReadLine();
                            CityInfo? firstCityInfo = stats.CityCatelogue[firstCityName].Count > 1 ? 
                                PickACity(stats.CityCatelogue[firstCityName]) : stats.CityCatelogue[firstCityName][0];
                            Console.Write("Enter second city name: ");
                            string? secondCityName = Console.ReadLine();

                            CityInfo? secondCityInfo = stats.CityCatelogue[secondCityName].Count > 1 ?
                                PickACity(stats.CityCatelogue[secondCityName]) : stats.CityCatelogue[secondCityName][0];

                            Console.WriteLine("\nComparing population of " + firstCityName + " and " + secondCityName + "...");
                            if (firstCityInfo!.Population > secondCityInfo!.Population)
                            {
                                Console.WriteLine(firstCityName + " has a larger population than " + secondCityName + " with a population of " + firstCityInfo!.Population + " people.");
                            }
                            else if (secondCityInfo!.Population > firstCityInfo!.Population)
                            {
                                Console.WriteLine(secondCityName + " has a larger population than " + firstCityName + " with a population of " + secondCityInfo!.Population + " people.");
                            }
                            else
                            {
                                Console.WriteLine(firstCityName + " and " + secondCityName + " have the same population of " + firstCityInfo!.Population + " people.");
                            }

                            break;

                        case 5:
                            Console.Write("\nEnter first city name: ");
                            string? city1Name = Console.ReadLine();
                            CityInfo? city1Info = stats.CityCatelogue[city1Name].Count > 1 ? PickACity(stats.CityCatelogue[city1Name]) : stats.CityCatelogue[city1Name][0];

                            Console.Write("Enter second city name: ");
                            string? city2Name = Console.ReadLine();
                            Console.Write("Enter second city province: ");
                            CityInfo? city2Info = stats.CityCatelogue[city2Name].Count > 1 ? PickACity(stats.CityCatelogue[city2Name]) : stats.CityCatelogue[city2Name][0];

                            Console.WriteLine("\nCalculating distance between " + city1Name + " and " + city2Name + "...");
                            int? distance = stats.CalculateDistanceBetweenCities(city1Info!, city2Info!) / 1000;
                            Console.WriteLine("The distance between " + city1Name + " and " + city2Name + " is " + distance + " km");
                            break;

                        case 6:
                            Console.WriteLine();
                            Main(args);
                            break;

                        case 7:
                            Console.Write("\nEnter city name: ");
                            string? name = Console.ReadLine();
                            List<CityInfo>? cities = stats.CityCatelogue[name];
                            CityInfo change = cities.Count > 1 ? PickACity(cities) : cities[0];
                            string popNum = "";
                            int newPop = 0;
                            while (newPop < 1) {
                                Console.Write("\nEnter the new population: ");
                                popNum = Console.ReadLine();
                                if(!int.TryParse(popNum, out newPop))
                                {
                                    Console.WriteLine("\nEnter a number please.");
                                    newPop = 0;
                                }
                            }
                            string? choice = "";
                            int select = 0;
                            while (select < 1)
                            {
                                Console.WriteLine("\nWhat file would you like to export as?\n1) XML\n2) JSON\n3) CSV)");
                                Console.Write("Choice: ");
                                choice = Console.ReadLine();
                                if(!int.TryParse(choice, out select))
                                {
                                    Console.WriteLine("\nEnter a number between 1 and 3 please.");
                                    select = 0;
                                }
                            }
                            string newType = select < 2 ? "xml" : select < 3 ? "json" : "csv";
                            Statistics.OnCityPopulationChange(new CityPopulationChangeEvent(ref change, newPop),stats.CityCatelogue, fileName, newType);
                            break;
                        case 8:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid input. Exiting program...");
                            return;
                    }
                } catch (Exception ex)
                {
                    GUI.GUI.printError(ex.Message);
                }
            }
        }
        //Allows the user to pick a city from a list of cities with the same key.
        public static CityInfo PickACity(List<CityInfo> list)
        {
            int choice = 0;
            while (choice < 1 || choice > list.Count)
            {
                GUI.GUI.DisplayAll(list);
                Console.Write("Please select a city by number: ");
                string? entry = Console.ReadLine();
                if (!int.TryParse(entry, out choice))
                {
                    Console.WriteLine("try again.");
                    choice = 0;
                }
            }
            return list[choice - 1];
        }
    }
}
