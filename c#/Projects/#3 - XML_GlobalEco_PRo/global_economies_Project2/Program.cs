/*
 *  Project name: global_economies_project2
 *  Purpose: this file holds all the code to get project 2 working
 *  Programmer: Hassan Ihsan
 *  Date: ///
 */

using System;
using System.Xml;

namespace global_economies_Project2
{
    class Program
    {
        //the file to read in.
        // Location: bin/debug/net6.0
        const string XML_FILE = "global_economies.xml";

        //staring year variables
        public static int g_startingYear = 47;
        public static  int g_endingYear = 51;


        /*
         * Method Name: Main
         * Purpose: contains the main menu of the program
         *
         */ 
        static void Main(string[] args)
        {
            string userInput;

            Console.WriteLine("World Economic Data");
            Console.WriteLine("====================");

            Console.WriteLine();

            try
            {
                // Initialize the DOM object
                XmlDocument doc = new XmlDocument();
                doc.Load(XML_FILE);

                do
                {


                    //options
                    Console.WriteLine("'Y' to adjust the range of years (currently " + g_startingYear + " to " + g_endingYear + ")");
                    Console.WriteLine("'R' to print a regional summary");
                    Console.WriteLine("'S' to Select a metric for all regions");
                    Console.WriteLine("'X' to eixt the program");
                    Console.Write("Your Slection: ");
                    userInput = Console.ReadLine().ToUpper();


                    //if statement for user input
                    if (userInput == "R")
                    {
                        selectRegionalSummary(doc, g_startingYear, g_endingYear);

                    }
                    else if (userInput == "S")
                    {
                        SelectMetrucAllRegions(doc, g_startingYear, g_endingYear);

                    }
                    else if (userInput == "Y")
                    {
                        ChangeYear();

                    }
                } while (userInput != "X");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        /*
        * Method Name: selectRegionalSummary
        * Purpose: this is where depending of what years the user has seletected it will show the information 
        *          of whatever region user selets
        *
        */
        public static void selectRegionalSummary(XmlDocument doc,int startingYear,int endingYear)
        {
            Console.WriteLine();

            int userInput, i;

            Console.WriteLine(startingYear + " " + endingYear);

            Console.WriteLine("Select a region by number as shown below...");
             

            //if the document is not null
            if (doc.DocumentElement != null)
            { 
                //nodelist of all regions
                XmlNodeList allRegions = doc.GetElementsByTagName("region");

                for ( i = 0; i < allRegions.Count; i++)
                {
                     
                    //display all regions
                    XmlAttributeCollection? turnAttrs = allRegions.Item(i)?.Attributes;

                    if(turnAttrs != null)
                    {
                        string regionName = turnAttrs.GetNamedItem("rname").InnerText;

                        Console.WriteLine(" " + i + ". " + regionName);
                    }
                     
                }

                Console.WriteLine();

                bool isValid = false;

                do
                {
                    //selecting a region number
                    Console.Write("Enter a Region #: ");
                    userInput = Convert.ToInt32(Console.ReadLine());

                    //validation to make sure the user only pick the show regions
                    if ( userInput == i|| userInput < i) 
                    {
                        isValid = true;
                        DisplayRegionInfo(doc, userInput, startingYear, endingYear);
                        
                    }
                    else
                    {
                        Console.WriteLine("Ivalid Region... Please Choose from the given options");
                    }

                } while (!isValid);

            }




        }

        /*
        * Method Name: DisplayRegionInfo
        * Purpose: this conatins the code to display the info of the region that the user has selected
        */
        private static void DisplayRegionInfo(XmlDocument Doc, int SeledctedRegion, int startyear, int endyear)
        {
            Console.WriteLine();

            //setting up years 1 - 5
            //year22 = year2
            //year33 = year3 and so on
            int startingYear = startyear;
            int year22 = startingYear + 1;
            int year33 = year22 + 1;
            int year44 = year33 + 1;
            int endingYear = endyear; 

            if(Doc.DocumentElement != null)
            {
                //root node
                XmlNode rootNode = Doc.DocumentElement;

                //node list of all years/regions/labels
                XmlNodeList allyears = Doc.GetElementsByTagName("year");
                XmlNodeList allRegions = Doc.GetElementsByTagName("region");
                

                //added a plus 1 because in the xml file years go from 1 to 52
                //but in the nodeList they go from 0 to 51
                XmlAttributeCollection? turnAttrsYear1 = allyears.Item(startingYear + 1)?.Attributes;
                XmlAttributeCollection? turnAttrsYear2 = allyears.Item(year22 + 1)?.Attributes;
                XmlAttributeCollection? turnAttrsYear3 = allyears.Item(year33 + 1)?.Attributes;
                XmlAttributeCollection? turnAttrsYear4 = allyears.Item(year44 + 1)?.Attributes;
                XmlAttributeCollection? turnAttrsYear5 = allyears.Item(endingYear + 1)?.Attributes;

                XmlAttributeCollection? turnAttrs = allRegions.Item(SeledctedRegion)?.Attributes;

                if (turnAttrs != null && turnAttrsYear1 != null && turnAttrsYear2 != null && turnAttrsYear3 != null && turnAttrsYear4 != null && turnAttrsYear5 != null)
                {
                    string regionName = turnAttrs.GetNamedItem("rname").InnerText;

                    string year1 = turnAttrsYear1.GetNamedItem("yid").InnerText;
                    string year2 = turnAttrsYear2.GetNamedItem("yid").InnerText;
                    string year3 = turnAttrsYear3.GetNamedItem("yid").InnerText;
                    string year4 = turnAttrsYear4.GetNamedItem("yid").InnerText;
                    string year5 = turnAttrsYear5.GetNamedItem("yid").InnerText;


                     
                    //menu
                    Console.WriteLine("Economic information for " + regionName);
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine();


                    //display years
                    Console.WriteLine("Region ".PadLeft(60) + "".PadLeft(4) + year1 + " ".PadLeft(4) + year2 + " ".PadLeft(4) + year3 + " ".PadLeft(4) + year4 + " ".PadLeft(5) + year5);

                    Console.WriteLine();

                    XmlNodeList? regionChildNodes = allRegions.Item(SeledctedRegion)?.ChildNodes;
 

                    //nodelost of childnode item of year
                    XmlNodeList? childDataSelectedYear1 = regionChildNodes.Item(startingYear)?.ChildNodes;
                    XmlNodeList? childDataSelectedYear2 = regionChildNodes.Item(year22)?.ChildNodes;
                    XmlNodeList? childDataSelectedYear3 = regionChildNodes.Item(year33)?.ChildNodes;
                    XmlNodeList? childDataSelectedYear4 = regionChildNodes.Item(year44)?.ChildNodes;
                    XmlNodeList? childDataSelectedYear5 = regionChildNodes.Item(endingYear)?.ChildNodes;
 

                    //root element
                    XmlElement? rootElem = (XmlElement?)rootNode;



                    //node list of all infation attribute/ all intrest attrubutes/ all unemployment attributes
                    XmlNodeList? allInflationAttribute = rootElem?.GetElementsByTagName("inflation");
                    XmlNodeList? allintrestAttribute = rootElem?.GetElementsByTagName("interest");
                    XmlNodeList? allunemployemntAttribute = rootElem?.GetElementsByTagName("unemployment");


                    //dispaly the information that is needed:
                    //inflation cpi
                    if (childDataSelectedYear1[0]?.Attributes?.GetNamedItem("consumer_prices_percent") != null)
                    {
                        Console.Write(allInflationAttribute[0]?.Attributes?[0].InnerText.PadLeft(60) + "\t" + childDataSelectedYear1[0]?.Attributes?.GetNamedItem("consumer_prices_percent")?.InnerText);
                    }
                    else
                    {
                        Console.Write(allInflationAttribute[0]?.Attributes?[0].InnerText.PadLeft(60) + "\t -");
                    }

                    if (childDataSelectedYear2[0]?.Attributes?.GetNamedItem("consumer_prices_percent") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear2[0]?.Attributes?.GetNamedItem("consumer_prices_percent")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear3[0]?.Attributes?.GetNamedItem("consumer_prices_percent") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear3[0]?.Attributes?.GetNamedItem("consumer_prices_percent")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear4[0]?.Attributes?.GetNamedItem("consumer_prices_percent") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear4[0]?.Attributes?.GetNamedItem("consumer_prices_percent")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear5[0]?.Attributes?.GetNamedItem("consumer_prices_percent") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear5[0]?.Attributes?.GetNamedItem("consumer_prices_percent")?.InnerText);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\t -");
                    }

                    //inflation gdp
                    if (childDataSelectedYear1[0]?.Attributes?.GetNamedItem("gdp_deflator_percent") != null)
                    {
                        Console.Write(allInflationAttribute[0]?.Attributes?[1].InnerText.PadLeft(60) + "\t" + childDataSelectedYear1[0]?.Attributes?.GetNamedItem("gdp_deflator_percent")?.InnerText);
                    }
                    else
                    {
                        Console.Write(allInflationAttribute[0]?.Attributes?[1].InnerText.PadLeft(60) + "\t -");
                    }

                    if (childDataSelectedYear2[0]?.Attributes?.GetNamedItem("gdp_deflator_percent") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear2[0]?.Attributes?.GetNamedItem("gdp_deflator_percent")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear3[0]?.Attributes?.GetNamedItem("gdp_deflator_percent") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear3[0]?.Attributes?.GetNamedItem("gdp_deflator_percent")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear4[0]?.Attributes?.GetNamedItem("gdp_deflator_percent") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear4[0]?.Attributes?.GetNamedItem("gdp_deflator_percent")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear5[0]?.Attributes?.GetNamedItem("gdp_deflator_percent") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear5[0]?.Attributes?.GetNamedItem("gdp_deflator_percent")?.InnerText);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\t -");
                    }

                    //intrest real
                    if (childDataSelectedYear1[1]?.Attributes?.GetNamedItem("real") != null)
                    {
                        Console.Write(allintrestAttribute[0]?.Attributes?[0].InnerText.PadLeft(60) + "\t" + childDataSelectedYear1[1]?.Attributes?.GetNamedItem("real")?.InnerText);
                    }
                    else
                    {
                        Console.Write(allintrestAttribute[0]?.Attributes?[0].InnerText.PadLeft(60) + "\t -");
                    }

                    if (childDataSelectedYear2[1]?.Attributes?.GetNamedItem("real") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear2[1]?.Attributes?.GetNamedItem("real")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear3[1]?.Attributes?.GetNamedItem("real") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear3[1]?.Attributes?.GetNamedItem("real")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear4[1]?.Attributes?.GetNamedItem("real") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear4[1]?.Attributes?.GetNamedItem("real")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear5[1]?.Attributes?.GetNamedItem("real") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear5[1]?.Attributes?.GetNamedItem("real")?.InnerText);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\t -");
                    }
                    //intrest lending
                    if (childDataSelectedYear1[1]?.Attributes?.GetNamedItem("lending") != null)
                    {
                        Console.Write(allintrestAttribute[0]?.Attributes?[1].InnerText.PadLeft(60) + "\t" + childDataSelectedYear1[1]?.Attributes?.GetNamedItem("lending")?.InnerText);
                    }
                    else
                    {
                        Console.Write(allintrestAttribute[0]?.Attributes?[1].InnerText.PadLeft(60) + "\t -");
                    }

                    if (childDataSelectedYear2[1]?.Attributes?.GetNamedItem("lending") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear2[1]?.Attributes?.GetNamedItem("lending")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear3[1]?.Attributes?.GetNamedItem("lending") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear3[1]?.Attributes?.GetNamedItem("lending")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear4[1]?.Attributes?.GetNamedItem("lending") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear4[1]?.Attributes?.GetNamedItem("lending")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear5[1]?.Attributes?.GetNamedItem("lending") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear5[1]?.Attributes?.GetNamedItem("lending")?.InnerText);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\t -");
                    }
                    //intrest deposit
                    if (childDataSelectedYear1[1]?.Attributes?.GetNamedItem("deposit") != null)
                    {
                        Console.Write(allintrestAttribute[0]?.Attributes?[2].InnerText.PadLeft(60) + "\t" + childDataSelectedYear1[1]?.Attributes?.GetNamedItem("deposit")?.InnerText);
                    }
                    else
                    {
                        Console.Write(allintrestAttribute[0]?.Attributes?[2].InnerText.PadLeft(60) + "\t -");
                    }

                    if (childDataSelectedYear2[1]?.Attributes?.GetNamedItem("deposit") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear2[1]?.Attributes?.GetNamedItem("deposit")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear3[1]?.Attributes?.GetNamedItem("deposit") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear3[1]?.Attributes?.GetNamedItem("deposit")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear4[1]?.Attributes?.GetNamedItem("deposit") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear4[1]?.Attributes?.GetNamedItem("deposit")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear5[1]?.Attributes?.GetNamedItem("deposit") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear5[1]?.Attributes?.GetNamedItem("deposit")?.InnerText);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\t -");
                    }
                    //unemployment estimate
                    if (childDataSelectedYear1[2]?.Attributes?.GetNamedItem("national_estimate") != null)
                    {
                        Console.Write(allunemployemntAttribute[0]?.Attributes?[0].InnerText.PadLeft(60) + "\t" + childDataSelectedYear1[2]?.Attributes?.GetNamedItem("national_estimate")?.InnerText);
                    }
                    else
                    {
                        Console.Write(allunemployemntAttribute[0]?.Attributes?[0].InnerText.PadLeft(60) + "\t -");
                    }

                    if (childDataSelectedYear2[2]?.Attributes?.GetNamedItem("national_estimate") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear2[2]?.Attributes?.GetNamedItem("national_estimate")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear3[2]?.Attributes?.GetNamedItem("national_estimate") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear3[2]?.Attributes?.GetNamedItem("national_estimate")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear4[2]?.Attributes?.GetNamedItem("national_estimate") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear4[2]?.Attributes?.GetNamedItem("national_estimate")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear5[2]?.Attributes?.GetNamedItem("national_estimate") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear5[2]?.Attributes?.GetNamedItem("national_estimate")?.InnerText);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\t -");
                    }
                    //unemployment modeled ILO
                    if (childDataSelectedYear1[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate") != null)
                    {
                        Console.Write(allunemployemntAttribute[0]?.Attributes?[1].InnerText.PadLeft(60) + "\t" + childDataSelectedYear1[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate")?.InnerText);
                    }
                    else
                    {
                        Console.Write(allunemployemntAttribute[0]?.Attributes?[1].InnerText.PadLeft(60) + "\t -");
                    }

                    if (childDataSelectedYear2[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear2[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear3[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear3[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear4[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear4[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate")?.InnerText);
                    }
                    else
                    {
                        Console.Write("\t -");
                    }
                    if (childDataSelectedYear5[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate") != null)
                    {
                        Console.Write("\t" + childDataSelectedYear5[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate")?.InnerText);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\t -");
                    }


                }


            }



            Console.WriteLine();

            Console.Write("press any key to continue...\n");
            Console.ReadKey(true);
        }

        /*
        * Method Name: SelectMeturicAllRegions
        * Purpose: contains the information of metrics aka stuff like infation cpi or real loan etc
        *
        */
        public static void SelectMetrucAllRegions(XmlDocument Doc, int startYear, int endYear)
        {
            Console.WriteLine();
            int UserSelection;
            int SourceNumber = 0;

            //setting up years
            int startingYear = startYear;
            int year22 = startingYear + 1;
            int year33 = year22 + 1;
            int year44 = year33 + 1;
            int endingYear = endYear;

            Console.WriteLine("Select a metric by number as shown below...");

            if(Doc.DocumentElement != null)
            {
                //root node and root element
                XmlNode rootNode = Doc.DocumentElement;
                XmlElement? rootElem = (XmlElement?)rootNode;

                //node list of all regions and years
                XmlNodeList allRegions = Doc.GetElementsByTagName("region");
                XmlNodeList allyears = Doc.GetElementsByTagName("year");

                //nodelist of infation/intrest/unemployment attributes
                XmlNodeList? allInflationAttribute = rootElem?.GetElementsByTagName("inflation");
                XmlNodeList? allintrestAttribute = rootElem?.GetElementsByTagName("interest");
                XmlNodeList? allunemployemntAttribute = rootElem?.GetElementsByTagName("unemployment");
                 
                //xml attruvte collection of years
                XmlAttributeCollection? turnAttrsYear1 = allyears.Item(startingYear + 1)?.Attributes;
                XmlAttributeCollection? turnAttrsYear2 = allyears.Item(year22 + 1)?.Attributes;
                XmlAttributeCollection? turnAttrsYear3 = allyears.Item(year33 + 1)?.Attributes;
                XmlAttributeCollection? turnAttrsYear4 = allyears.Item(year44 + 1)?.Attributes;
                XmlAttributeCollection? turnAttrsYear5 = allyears.Item(endingYear + 1)?.Attributes;

                //if statement showing information
                if (allInflationAttribute != null && allintrestAttribute != null && allunemployemntAttribute != null)
                {

                    for (int i = 0; i < allInflationAttribute[0]?.Attributes?.Count; i++)
                    {
                        SourceNumber++;

                        Console.WriteLine(SourceNumber + ". " + allInflationAttribute[0]?.Attributes?[i].InnerText);
                    }

                    for (int i = 0; i < allintrestAttribute[0]?.Attributes?.Count; i++)
                    {
                        SourceNumber++;
                        Console.WriteLine(SourceNumber + ". " + allintrestAttribute[0]?.Attributes?[i].InnerText);
                    }

                    for (int i = 0; i < allunemployemntAttribute[0]?.Attributes?.Count; i++)
                    {
                        SourceNumber++;
                        Console.WriteLine(SourceNumber + ". " + allunemployemntAttribute[0]?.Attributes?[i].InnerText);
                    }

                    Console.Write("Enter a metric #: ");
                    UserSelection = Convert.ToInt32(Console.ReadLine());



                    //getting the years "1970"
                    string year1 = turnAttrsYear1.GetNamedItem("yid").InnerText;
                    string year2 = turnAttrsYear2.GetNamedItem("yid").InnerText;
                    string year3 = turnAttrsYear3.GetNamedItem("yid").InnerText;
                    string year4 = turnAttrsYear4.GetNamedItem("yid").InnerText;
                    string year5 = turnAttrsYear5.GetNamedItem("yid").InnerText;

                     
                    //user selected either infalation/intrest/unemplyment
                    if (UserSelection == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(allInflationAttribute[0]?.Attributes?[0].InnerText + " By Region");
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Region ".PadLeft(60) + "".PadLeft(4) + year1 + " ".PadLeft(4) + year2 + " ".PadLeft(4) + year3 + " ".PadLeft(4) + year4 + " ".PadLeft(5) + year5);

                    }
                    else if (UserSelection == 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(allInflationAttribute[0]?.Attributes?[1].InnerText + " By Region");
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Region ".PadLeft(60) + "".PadLeft(4) + year1 + " ".PadLeft(4) + year2 + " ".PadLeft(4) + year3 + " ".PadLeft(4) + year4 + " ".PadLeft(5) + year5);

                    }
                    else if (UserSelection == 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine(allintrestAttribute[0]?.Attributes?[0].InnerText + " By Region");
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Region ".PadLeft(60) + "".PadLeft(4) + year1 + " ".PadLeft(4) + year2 + " ".PadLeft(4) + year3 + " ".PadLeft(4) + year4 + " ".PadLeft(5) + year5);

                    }
                    else if (UserSelection == 4)
                    {
                        Console.WriteLine();
                        Console.WriteLine(allintrestAttribute[0]?.Attributes?[1].InnerText + " By Region");
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Region ".PadLeft(60) + "".PadLeft(4) + year1 + " ".PadLeft(4) + year2 + " ".PadLeft(4) + year3 + " ".PadLeft(4) + year4 + " ".PadLeft(5) + year5);

                    }
                    else if (UserSelection == 5)
                    {
                        Console.WriteLine();
                        Console.WriteLine(allintrestAttribute[0]?.Attributes?[2].InnerText + " By Region");
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Region ".PadLeft(60) + "".PadLeft(4) + year1 + " ".PadLeft(4) + year2 + " ".PadLeft(4) + year3 + " ".PadLeft(4) + year4 + " ".PadLeft(5) + year5);

                    }
                    else if (UserSelection == 6)
                    {
                        Console.WriteLine();
                        Console.WriteLine(allunemployemntAttribute[0]?.Attributes?[0].InnerText + " By Region");
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Region ".PadLeft(60) + "".PadLeft(4) + year1 + " ".PadLeft(4) + year2 + " ".PadLeft(4) + year3 + " ".PadLeft(4) + year4 + " ".PadLeft(5) + year5);

                    }
                    else if (UserSelection == 7)
                    {
                        Console.WriteLine();
                        Console.WriteLine(allunemployemntAttribute[0]?.Attributes?[1].InnerText + " By Region");
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Region ".PadLeft(60) + "".PadLeft(4) + year1 + " ".PadLeft(4) + year2 + " ".PadLeft(4) + year3 + " ".PadLeft(4) + year4 + " ".PadLeft(5) + year5);

                    }

                    //all information in regions
                    for (int i = 0; i < allRegions?.Count; i++)
                    {
                        XmlAttributeCollection? al = allRegions?.Item(i)?.Attributes;

                        string name = al.GetNamedItem("rname")?.InnerText;

                        XmlNodeList? al2 = allRegions?.Item(i)?.ChildNodes;

                        //node list of allyears
                        XmlNodeList? al3year1 = al2?.Item(startingYear)?.ChildNodes;
                        XmlNodeList? al3year2 = al2?.Item(year22)?.ChildNodes;
                        XmlNodeList? al3year3 = al2?.Item(year33)?.ChildNodes;
                        XmlNodeList? al3year4 = al2?.Item(year44)?.ChildNodes;
                        XmlNodeList? al3year5 = al2?.Item(endingYear)?.ChildNodes;

                        //if there is no information to show
                        if (al3year1[0]?.Attributes?.Count == 0 || al3year2[0]?.Attributes?.Count == 0 || al3year3[0]?.Attributes?.Count == 0 || al3year4[0]?.Attributes?.Count == 0 || al3year5[0]?.Attributes?.Count == 0)
                        {

                            Console.WriteLine(name.PadLeft(60) + " \t- " + "\t- " + "\t- " + "\t- " + "\t-");
                        }
                        else
                        {
                            //infation information
                            if (UserSelection == 1)
                            {


                                //consumer price percent
                                if (al3year1[0]?.Attributes?.GetNamedItem("consumer_prices_percent") != null)
                                {
                                    Console.Write(name.PadLeft(60) + "\t" + al3year1[0]?.Attributes?.GetNamedItem("consumer_prices_percent")?.InnerText);
                                }
                                else
                                {
                                    Console.Write(name.PadLeft(60) + "\t -");
                                }

                                if (al3year2[0]?.Attributes?.GetNamedItem("consumer_prices_percent") != null)
                                {
                                    Console.Write("\t" + al3year2[0]?.Attributes?.GetNamedItem("consumer_prices_percent")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year3[0]?.Attributes?.GetNamedItem("consumer_prices_percent") != null)
                                {
                                    Console.Write("\t" + al3year3[0]?.Attributes?.GetNamedItem("consumer_prices_percent")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year4[0]?.Attributes?.GetNamedItem("consumer_prices_percent") != null)
                                {
                                    Console.Write("\t" + al3year4[0]?.Attributes?.GetNamedItem("consumer_prices_percent")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year5[0]?.Attributes?.GetNamedItem("consumer_prices_percent") != null)
                                {
                                    Console.Write("\t" + al3year5[0]?.Attributes?.GetNamedItem("consumer_prices_percent")?.InnerText);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("\t -");
                                }

                            }
                            else if (UserSelection == 2)
                            {
                                //gdp delator precent
                                if (al3year1[0]?.Attributes?.GetNamedItem("gdp_deflator_percent") != null)
                                {
                                    Console.Write(name.PadLeft(60) + "\t" + al3year1[0]?.Attributes?.GetNamedItem("gdp_deflator_percent")?.InnerText);
                                }
                                else
                                {
                                    Console.Write(name.PadLeft(60) + "\t -");
                                }

                                if (al3year2[0]?.Attributes?.GetNamedItem("gdp_deflator_percent") != null)
                                {
                                    Console.Write("\t" + al3year2[0]?.Attributes?.GetNamedItem("gdp_deflator_percent")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year3[0]?.Attributes?.GetNamedItem("gdp_deflator_percent") != null)
                                {
                                    Console.Write("\t" + al3year3[0]?.Attributes?.GetNamedItem("gdp_deflator_percent")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year4[0]?.Attributes?.GetNamedItem("gdp_deflator_percent") != null)
                                {
                                    Console.Write("\t" + al3year4[0]?.Attributes?.GetNamedItem("gdp_deflator_percent")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year5[0]?.Attributes?.GetNamedItem("gdp_deflator_percent") != null)
                                {
                                    Console.Write("\t" + al3year5[0]?.Attributes?.GetNamedItem("gdp_deflator_percent")?.InnerText);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("\t -");
                                }

                            }
                            else if (UserSelection == 3)
                            {
                                //real value
                                if (al3year1[1]?.Attributes?.GetNamedItem("real") != null)
                                {
                                    Console.Write(name.PadLeft(60) + "\t" + al3year1[1]?.Attributes?.GetNamedItem("real")?.InnerText);
                                }
                                else
                                {
                                    Console.Write(name.PadLeft(60) + "\t -");
                                }

                                if (al3year2[1]?.Attributes?.GetNamedItem("real") != null)
                                {
                                    Console.Write("\t" + al3year2[1]?.Attributes?.GetNamedItem("real")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year3[1]?.Attributes?.GetNamedItem("real") != null)
                                {
                                    Console.Write("\t" + al3year3[1]?.Attributes?.GetNamedItem("real")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year4[1]?.Attributes?.GetNamedItem("real") != null)
                                {
                                    Console.Write("\t" + al3year4[1]?.Attributes?.GetNamedItem("real")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year5[1]?.Attributes?.GetNamedItem("real") != null)
                                {
                                    Console.Write("\t" + al3year5[1]?.Attributes?.GetNamedItem("real")?.InnerText);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("\t -");
                                }
                            }
                            else if (UserSelection == 4)
                            {
                                //lending value
                                if (al3year1[1]?.Attributes?.GetNamedItem("lending") != null)
                                {
                                    Console.Write(name.PadLeft(60) + "\t" + al3year1[1]?.Attributes?.GetNamedItem("lending")?.InnerText);
                                }
                                else
                                {
                                    Console.Write(name.PadLeft(60) + "\t -");
                                }

                                if (al3year2[1]?.Attributes?.GetNamedItem("lending") != null)
                                {
                                    Console.Write("\t" + al3year2[1]?.Attributes?.GetNamedItem("lending")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year3[1]?.Attributes?.GetNamedItem("real") != null)
                                {
                                    Console.Write("\t" + al3year3[1]?.Attributes?.GetNamedItem("lending")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year4[1]?.Attributes?.GetNamedItem("lending") != null)
                                {
                                    Console.Write("\t" + al3year4[1]?.Attributes?.GetNamedItem("lending")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year5[1]?.Attributes?.GetNamedItem("lending") != null)
                                {
                                    Console.Write("\t" + al3year5[1]?.Attributes?.GetNamedItem("lending")?.InnerText);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("\t -");
                                }
                            }
                            else if (UserSelection == 5)
                            {
                                //deposit value
                                if (al3year1[1]?.Attributes?.GetNamedItem("deposit") != null)
                                {
                                    Console.Write(name.PadLeft(60) + "\t" + al3year1[1]?.Attributes?.GetNamedItem("deposit")?.InnerText);
                                }
                                else
                                {
                                    Console.Write(name.PadLeft(60) + "\t -");
                                }

                                if (al3year2[1]?.Attributes?.GetNamedItem("deposit") != null)
                                {
                                    Console.Write("\t" + al3year2[1]?.Attributes?.GetNamedItem("deposit")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year3[1]?.Attributes?.GetNamedItem("deposit") != null)
                                {
                                    Console.Write("\t" + al3year3[1]?.Attributes?.GetNamedItem("deposit")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year4[1]?.Attributes?.GetNamedItem("deposit") != null)
                                {
                                    Console.Write("\t" + al3year4[1]?.Attributes?.GetNamedItem("deposit")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year5[1]?.Attributes?.GetNamedItem("deposit") != null)
                                {
                                    Console.Write("\t" + al3year5[1]?.Attributes?.GetNamedItem("deposit")?.InnerText);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("\t -");
                                }
                            }
                            if (UserSelection == 6)
                            {
                                //national estimate
                                if (al3year1[2]?.Attributes?.GetNamedItem("national_estimate") != null)
                                {
                                    Console.Write(name.PadLeft(60) + "\t" + al3year1[2]?.Attributes?.GetNamedItem("national_estimate")?.InnerText);
                                }
                                else
                                {
                                    Console.Write(name.PadLeft(60) + "\t -");
                                }

                                if (al3year2[2]?.Attributes?.GetNamedItem("national_estimate") != null)
                                {
                                    Console.Write("\t" + al3year2[2]?.Attributes?.GetNamedItem("national_estimate")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year3[2]?.Attributes?.GetNamedItem("national_estimate") != null)
                                {
                                    Console.Write("\t" + al3year3[2]?.Attributes?.GetNamedItem("national_estimate")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year4[2]?.Attributes?.GetNamedItem("national_estimate") != null)
                                {
                                    Console.Write("\t" + al3year4[2]?.Attributes?.GetNamedItem("national_estimate")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year5[2]?.Attributes?.GetNamedItem("national_estimate") != null)
                                {
                                    Console.Write("\t" + al3year5[2]?.Attributes?.GetNamedItem("national_estimate")?.InnerText);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("\t -");
                                }
                            }
                            else if (UserSelection == 7)
                            {
                                //modeled ILO estimate
                                if (al3year1[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate") != null)
                                {
                                    Console.Write(name.PadLeft(60) + "\t" + al3year1[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate")?.InnerText);
                                }
                                else
                                {
                                    Console.Write(name.PadLeft(60) + "\t -");
                                }

                                if (al3year2[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate") != null)
                                {
                                    Console.Write("\t" + al3year2[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year3[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate") != null)
                                {
                                    Console.Write("\t" + al3year3[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year4[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate") != null)
                                {
                                    Console.Write("\t" + al3year4[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate")?.InnerText);
                                }
                                else
                                {
                                    Console.Write("\t -");
                                }
                                if (al3year5[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate") != null)
                                {
                                    Console.Write("\t" + al3year5[2]?.Attributes?.GetNamedItem("modeled_ILO_estimate")?.InnerText);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("\t -");
                                }
                            }


                        }

                    }
                     

                }

            }



            Console.WriteLine("press any key to continue...\n");
            Console.ReadKey(true);
        }

        /*
        * Method Name: ChangeYear
        * Purpose: change the year the user would like to see
        *
        */
        public static void ChangeYear()
        {
            int startingyear = 0;
            int endingYear = 0;

            //create list to store all years  
            List<int> storedYears = new List<int>();
            Console.WriteLine();
            int YearSelection = 0;

            bool isValid1 = false;

            do
            {
                Console.WriteLine();

                Console.Write("Starting year(1970 to 2021): ");
                startingyear = Convert.ToInt32(Console.ReadLine());


                //validation to make sure user only chooses between 1970 and 2021 the starting year)
                if (startingyear > 2021 || startingyear < 1970)
                {
                    Console.WriteLine("Error: starting year must be aninteger between 1970  and 2021");
                }
                else
                {
                    YearSelection = startingyear + 4;
                    isValid1 = true;

                }

            } while (!isValid1);

            bool isValid = false;
            do
            {
                Console.WriteLine(); 
                Console.WriteLine("Ending year (1970 to 2021): ");
                endingYear = Convert.ToInt32(Console.ReadLine());


                //validation to make sure user only chooses between the starting year + 5 (the end year)
                if (endingYear > YearSelection || endingYear < startingyear)
                {
                    Console.WriteLine("Error: ending year must be aninteger between " + startingyear + " and " + YearSelection);
                }
                else
                {
                    isValid = true;
                }

            } while (!isValid);

            Console.WriteLine();

            //add possible years to list
            storedYears.Add(1970);
            storedYears.Add(1971);
            storedYears.Add(1972);
            storedYears.Add(1973);
            storedYears.Add(1974);
            storedYears.Add(1975);
            storedYears.Add(1976);
            storedYears.Add(1977);
            storedYears.Add(1978);
            storedYears.Add(1979);

            storedYears.Add(1980);
            storedYears.Add(1981);
            storedYears.Add(1982);
            storedYears.Add(1984);
            storedYears.Add(1984);
            storedYears.Add(1986);
            storedYears.Add(1986);
            storedYears.Add(1987);
            storedYears.Add(1988);
            storedYears.Add(1989);

            storedYears.Add(1990);
            storedYears.Add(1991);
            storedYears.Add(1992);
            storedYears.Add(1994);
            storedYears.Add(1994);
            storedYears.Add(1996);
            storedYears.Add(1996);
            storedYears.Add(1997);
            storedYears.Add(1998);
            storedYears.Add(1999);

            storedYears.Add(2000);
            storedYears.Add(2001);
            storedYears.Add(2002);
            storedYears.Add(2003);
            storedYears.Add(2004);
            storedYears.Add(2005);
            storedYears.Add(2006);
            storedYears.Add(2007);
            storedYears.Add(2008);
            storedYears.Add(2009);

            storedYears.Add(2010);
            storedYears.Add(2011);
            storedYears.Add(2012);
            storedYears.Add(2013);
            storedYears.Add(2014);
            storedYears.Add(2015);
            storedYears.Add(2016);
            storedYears.Add(2017);
            storedYears.Add(2018);
            storedYears.Add(2019);

            storedYears.Add(2020);
            storedYears.Add(2021);

            //change starting year and ending year number to what user inputed
            for (int i = 0; i < storedYears.Count; i++)
            {
                if(startingyear == storedYears[i])
                {
                    startingyear = i;
                }

                if(endingYear == storedYears[i])
                {
                    endingYear = i;
                }
            }

            

             
           
            //g meaning global
            g_startingYear = startingyear;
            g_endingYear = endingYear;


           
            Console.Write("press any key to continue...\n");
            Console.ReadKey(true);

        }
    }
}