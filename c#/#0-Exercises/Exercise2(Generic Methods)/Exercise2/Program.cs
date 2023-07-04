namespace Exercise2
{
    internal partial class Program
    {

        public static void Main(string[] args)
        {
 

            //create 2 lists
            List<string> list1 = new();
            List<string> list2 = new();

            //add 3 items to both lists
            list1.Add("yuki");
            list1.Add("leo");
            list1.Add("haru");

            list2.Add("saya");
            list2.Add("lilith");
            list2.Add("liz");

            //create a new list and call the shuffle method on it
            List<string> list3 = shuffler.Shuffle(list1, list2);

            
            //print the items of list3
            foreach(var item in list3)
            {
                Console.WriteLine($"items in list3 genric method = {item}");
            }


            List<int> l1 = new();
            List<int> l2 = new();

            l1.Add(1);
            l1.Add(2);
            l1.Add(3);
           
            l2.Add(4);
            l2.Add(5);
            l2.Add(6);

            Genshuffler<int> shul = new();
            List<int> l3 = shul.ShuffleValueTypes(l1, l2);


            //print the items of l3
            foreach (var item in l3)
            {
                Console.WriteLine($"items in l3 genric class = {item}");
            }
        }
    }
}