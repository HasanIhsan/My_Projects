namespace Exercise5
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            //. Same two string lists in a different order. 
            Console.WriteLine("same two list diffrent order");
            List<string> list1 = new () { "a", "b", "c" };
            List<string> list2 = new() { "c", "b", "a" }; 
            Console.WriteLine($"Does list1 contain the same elements are list2?:  {list1.CompareTo(list2)}");
            Console.WriteLine();

            //Different two string lists with the same length. 
            Console.WriteLine("Different two string lists with the same length");
            List<string> list3 = new() { "f", "s", "d" };
            List<string> list4 = new() { "c", "x", "z" };
            Console.WriteLine($"Does list1 have the same values as list2?:  {list3.CompareTo(list4)}");
            Console.WriteLine();

            //Two int lists having different lengths. For example, the first List has
           // three elements, while the second has four. 
            Console.WriteLine("Two int lists having different lengths.");
            List<int> list5 = new() { 1, 2, 3 };
            List<int> list6 = new() { 1, 2, 3, 4 }; 
            Console.WriteLine($"Does list1 have the same length as list2?:  {list5.CompareTo(list6)}");
            Console.WriteLine();

            //Two null lists. 
            Console.WriteLine(". Two null lists");
            List<int> list7 = new() { };
            List<int> list8 = new() { };
            Console.WriteLine($"Are both lists null:  {list7.CompareTo(list8)}");
            Console.WriteLine();

            //Two identical double lists
            Console.WriteLine("Two identical double lists ");
            List<double> list9 = new() { 1.5, 2.5, 3.5 };
            List<double> list10 = new() { 1.5, 2.5, 3.5 };
            Console.WriteLine($"Are both lists the same:  {list9.CompareTo(list10)}");
            Console.WriteLine();




        }
    }
}