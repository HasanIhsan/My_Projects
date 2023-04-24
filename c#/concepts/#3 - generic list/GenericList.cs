//Programmer: Hassan Ihsan
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    
        //creating a generic list
        public class GenericList<T>
        {
            //is not allowed to hold more then 4 items
            private const int MAX_ITEMS = 10;

            //creating a list of T 
            private readonly T[] gList = new T[MAX_ITEMS];

            //keep track num of items
            private int count = 0;


            //clear the list
            public void Clear()
            {
                if(MAX_ITEMS > 0)
                {
                    Array.Clear(gList);
                }
            }

            //get item at index
            public T GetItem(int index)
            {
                //make sure the index is a valid index
                if (index < count)
                {
                    return gList[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"index out of range: {index}");
                }
            }

            //add a new item
            public void Add(T item)
            {
                if (count < MAX_ITEMS)
                {
                    gList[count++] = item;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"index out of range: {count}");
                }
            }

           

        public void Insert(int index, T value)
        {
            if (index < count)
            {
                gList[index] = value; //ex: list[0] = 2; so value is 10
            }
            else
            {
                throw new ArgumentOutOfRangeException($"index out of range: {index}");
            }
        }

        //mot workinng
            public void Remove(int index)
            {
                if(index < MAX_ITEMS)
                {
                    
                }
            }


           
            // the number of populated items in the collection
            public int Length
            {
                get { return count; }
            }

            



            //define an indexer
            public T this[int index]
            {
                get
                {
                    //make sure the index is a valid index
                    if (index < count)
                    {
                        return gList[index];
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException($"index out of range: {index}");
                    }
                }

                //assignin a value
                set
                {
                    if (index < count)
                    {
                        gList[index] = value; //ex: list[0] = 2; so value is 10
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException($"index out of range: {index}");
                    }
                }
            }

            //facilitaet use of foreach (not the best implementation but this will get the job done)
            public IEnumerator GetEnumerator()
            {
                return gList.GetEnumerator();
            }
 
    }
}
