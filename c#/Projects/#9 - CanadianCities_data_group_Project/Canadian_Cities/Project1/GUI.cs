/*
 * 
 */

using Project1;
using System.Text;
using System.Xml;

namespace GUI
{
    public static class GUI
    {
        const Int16 WIDTH = 110;
        const Int16 PADDING = 6;
        const string TITLE = "Canadian Cities Program";
        enum alignment { UP = 0, DOWN, MIDDLE }

        public static void MakeTitle()
        {
            MakeHeader();
            drawLine(alignment.DOWN);
        }

        public static void MakeHeader(string? title = null)
        {
            title = title ?? TITLE;
            drawLine(alignment.UP);
            int left = (WIDTH / 2) + (PADDING / 2) - (title.Length / 2);
            int right = (WIDTH / 2) + (PADDING/2) - (title.Length - (title.Length / 2));
            StringBuilder sb = new StringBuilder("\u2502");
            sb.Append(' ', left);
            sb.Append(title);
            sb.Append(' ', right);
            sb.Append('\u2502');
            Console.WriteLine(sb.ToString());
        }
        private static void drawLine(alignment align)
        {
            StringBuilder sb = new StringBuilder();
            char lCorner = align == alignment.UP ? '\u250C' : align == alignment.DOWN ? '\u2514' : '\u251C'; //Either specify or have middle format provided
            char rCorner = align == alignment.UP ? '\u2510' : align == alignment.DOWN ? '\u2518' : '\u2524'; //Either specify or have middle format provided
            sb.Append(lCorner);
            sb.Append('\u02C9', WIDTH + PADDING);
            sb.Append(rCorner);
            Console.WriteLine(sb);
        }

        public static void Menu(string startingYear, string endingYear)
        {
            string[] properties = { "'Y' to adjust the range of years (currently " + startingYear + " to " + endingYear + ")",
                "'R' to print a regional summary", "'M' to print a specific metric for all regions", "'C' to clean the console",
                "'X' to exit the program" };

            drawLine(alignment.MIDDLE);

            StringBuilder menuItems = new StringBuilder();
            foreach (string prop in properties)
            {
                menuItems.Append("\u2502   " + prop);
                menuItems.Append(' ', WIDTH + (PADDING/2) - (prop.Length));
                menuItems.Append("\u2502\n");
            }
            Console.Write(menuItems.ToString());
            drawLine(alignment.DOWN);
        }

        public static void printError(string msg)
        {
            drawLine(alignment.UP);
            newLine(msg, true);                         //Used to catch all exceptions... well generally all of them.
            drawLine(alignment.DOWN);                   //I don't know the length and I don't want to throw an exception from the thing catching them.
        }

        private static void newLine(string str, bool formattingRequired)
        {
            StringBuilder lineOutput = new StringBuilder();
            str = formattingRequired ? lenFormat(str) : str; 
            
            string[] strings = str.Split('\n');
            foreach(string s in strings) 
            {
                lineOutput.Append('\u2502');
                lineOutput.Append(' ', PADDING/2); 
                lineOutput.Append(s);
                lineOutput.Append(' ', WIDTH - s.Length + PADDING/2);
                lineOutput.Append("\u2502\n");
            }
            lineOutput.Remove(lineOutput.Length - 1, 1);
            Console.WriteLine(lineOutput);
            
        }

        //display all the countries 
        public static void DisplayAll(List<CityInfo> cityList)
        {
            //MakeHeader("Country List");
            drawLine(alignment.MIDDLE);
            for (int i = 1; i <= cityList.Count; i++)
            {
                string output = $"{i} : {cityList[i - 1]}";
                newLine(output, false);
            }
            drawLine(alignment.DOWN);
        }

        public static void DisplayAll(string[] strings, string title)
        {
            MakeHeader(title);
            drawLine(alignment.MIDDLE);
            for(int i = 1; i <= strings.Length; i++)
            {
                string output = $"{i} - {strings[i - 1]}";
                newLine(output, false);
            }
            drawLine(alignment.DOWN);
        }

        private static string lenFormat(string str)
        {
            Int16 character_spacing = WIDTH;
            if(str.Length > character_spacing)
            { 
                int strLength = str.Length;
                int i = 2;

                str = str.Insert(character_spacing, "\n");
                
                while(str.Substring(str.LastIndexOf('\n')+1, strLength - str.LastIndexOf('\n')).Length > character_spacing)
                {
                    str = str.Insert(character_spacing * i++, "\n");
                }
            }
            return str;
        }

        //public static void PrintRegionalData(List<Region> regionRange)
        //{
        //    string toAppend;
        //    string head;
        //    bool attributes;
        //    string? regionBanner = null;
        //    if(regionRange.Count > 1)//Region greater than 1 means they're all attributes for many regions.
        //    {
        //        toAppend = regionRange[0].GetOnlyAttributeName();
        //        head = toAppend + " by Region";
        //        attributes = true;
        //        regionBanner = "                                              Region";

        //        for(int i = Int16.Parse(EconomicsManager.getInstance().fromYear); i <= Int16.Parse(EconomicsManager.getInstance().toYear);i++)
        //        {
        //            StringBuilder sb = new StringBuilder("", 9);
        //            sb.Append(' ', 6);
        //            sb.Append(i);
        //            regionBanner += sb.ToString();
        //        }
        //        regionBanner += "\n\n";
        //    }
        //    else
        //    {
        //        toAppend = regionRange[0].getName();
        //        head = "Economic information for " + toAppend;
        //        attributes = false;
        //    }
        //    MakeHeader(head);
        //    drawLine(alignment.MIDDLE);
        //    if(regionBanner != null) newLine(regionBanner, false);
        //    foreach(Region region in regionRange)
        //    {
        //        newLine(region.ToString(attributes), false);
        //    }
        //    drawLine(alignment.DOWN);
        //}
    }
}

