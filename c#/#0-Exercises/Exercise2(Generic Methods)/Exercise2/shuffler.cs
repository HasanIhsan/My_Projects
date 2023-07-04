using System.Collections.Generic;

namespace Exercise2
{
    public class shuffler {

        //random 
        private static Random rng = new Random();


        //create a list<T> shuffle method (that will take in 2 list<T>)
        public static List<T> Shuffle<T> (List<T> list1, List<T> list2) 
        {
         
            //create a final list that has all items of list1 and list2 
            List<T> combined = new List<T>(list1);
            combined.AddRange(list2);

            //using a while loop shuffle the item in a random order using Random()
            int n = combined.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = combined[k];
                combined[k] = combined[n];
                combined[n] = value;
            }

            //return the shuffled list
            return combined;

        }
       
    }
}