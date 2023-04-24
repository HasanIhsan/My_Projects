using System.Collections; //arraylist

namespace generics
{
    internal partial class Program
    {

        static void Main(string[] args)
        {
            //reregular array
            int[] intArray = { 3, 2, 3, 4 };

            for(int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine("Items of array (for) = " + intArray[i]);
            }

            foreach(var item in intArray)
            {
                Console.WriteLine("item of array (foreach) = " + item);
            }

            //resizing the array
            Array.Resize(ref intArray, intArray.Length + 2);

            //initializing the new added size
            intArray[4] = 4;
            intArray[5] = 5;

            foreach (var item in intArray)
            {
                Console.WriteLine("item of array (foreach) = " + item);
            }


            //arraylist (can put in any type you want)
            ArrayList list = new();
            list.Add(1);
            list.Add("2");
            list.Add(DateTime.Now);

            foreach (var item in list)
            {
                Console.WriteLine("item of arraylist (foreach) = " + item);
            }

            //we can perform a explizt typecast so there are no erros
            int num = (int)list[0];
            Console.WriteLine("list[0] = " + num);

            //try unboxing the second valie the complier can due that 
            //even if we know that the second element is a string
            //int num2 = (int)list[1];


            Console.WriteLine();

            //GenList
            GenList<int> intList = new();
            intList.Add(1);
            //intList.Add("2"); now type safe
            intList.Add(5);

            foreach(var item in intList)
            {
                Console.WriteLine("item of GenList<int> (foreach) = " + item);
            }

            //genlist for strings
            GenList<string> strlist = new();

            strlist.Add("2");
            strlist.Add("hassan");



            //handel exception 
            try
            {
                //try indexer
                strlist[0] = "cat";

                strlist[3] = "no valid"; // trows exceptions
            }catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }


            foreach (var item in intList)
            {
                Console.WriteLine("item of GenList<string> (foreach) = " + item);
            }

            for(int i = 0; i < strlist.Length; i++)
            {
                Console.WriteLine("items of genlist<string> for = " + strlist[i]);
            }


        }
    }
}