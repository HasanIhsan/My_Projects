using System.Collections.Generic;
using System;

namespace Exercise2
{
    internal partial class Program
    {
        public class Genshuffler<T>
        {
            private Random rand = new Random();

            public List<T> ShuffleValueTypes(List<T> list1, List<T> list2)
            {

                //combining list 1 and list2
                List<T> finallist = new List<T>(list1);
                finallist.AddRange(list2);


                //creating a new list (tedious but it works) and is diffrent from what i did in the other file)
                List<T> newShuffledList = new();


                //get listcount and using forloop randommize it
                int listcCount = finallist.Count;
                for (int i = 0; i < listcCount; i++)
                {
                    int randomElementInList = rand.Next(0, finallist.Count);
                    newShuffledList.Add(finallist[randomElementInList]);
                    finallist.Remove(finallist[randomElementInList]);
                }



                //returned shuffled list
                return newShuffledList;

            }

        }
    }
}