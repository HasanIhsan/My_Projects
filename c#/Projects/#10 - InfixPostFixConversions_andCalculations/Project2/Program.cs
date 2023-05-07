/*
 * Program Name: inFix,preFix 
 * Programmer: Hassan Ihsan
 */

using System.Xml;

namespace Project2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var csv = new CSVFile("Project 2_INFO_5101.csv");
            List<Infix> infixList = csv.InFix; 

            List<string> toPreFixList = csv.PreFix;
            List<string> toPostFixList = csv.PostFix;

            CompareExpressions comparer = new CompareExpressions();


            //output in the debug folder
            StreamWriter writer = new StreamWriter("output.xml"); 



            Console.WriteLine("===============================================================================================================");
            Console.WriteLine("| sno |          Infix      |           postFix   |           PreFix    | Prefix Res  | PostFile Res | Match |"); 
            Console.WriteLine("===============================================================================================================");
            writer.WriteStartDocument();
            writer.WriteStartRootElement();
            
            for (int i = 1; i < infixList.Count; i++)
            {
                writer.WriteStartElement();
                double postFixResults = toPostFixList[i].postfixEvaluate();
                double preFixResults = toPreFixList[i].PrefixEvaluate();

                bool isEqual = comparer.Compare(postFixResults, preFixResults) == 0;

                Console.WriteLine(
                    "|{0,4} |{1,20} |{2,20} |{3,20} |{4,12} |{5,14} |{6,6} |",
                    i,
                    infixList[i].InfixExpr,
                    toPostFixList[i],
                    toPreFixList[i],
                    preFixResults,
                    postFixResults,
                    isEqual ? "True" : "False"
                );

               
                writer.WriteAttribute("sno", i.ToString());
                writer.WriteAttribute("infix", infixList[i].InfixExpr);
                writer.WriteAttribute("prefix", toPreFixList[i]);
                writer.WriteAttribute("postfix", toPostFixList[i]);
                writer.WriteAttribute("evaluation", postFixResults.ToString());
                writer.WriteAttribute("comparision", isEqual ? "True" : "False");
                writer.WriteEndElement();

            }
            writer.WriteEndRootElement();
          
            writer.Close();
            Console.WriteLine("===============================================================================================================");
            Console.WriteLine();
 

            

 

        }
    }
}