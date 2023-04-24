using System.Collections;

namespace generics
{
    internal partial class Program
    {
        //creating a generic list
        public class GenList<T> 
        {
            //is not allowed to hold more then 4 items
            private const int MAX_ITEMS = 4;
            
            //creating a list of T 
            private readonly T[] gList = new T[MAX_ITEMS];

            //keep track num of items
            private int count = 0;



            //add a new item
            public void Add(T item)
            {
                if(count < MAX_ITEMS)
                {
                    gList[count++] = item;
                }else
                {
                    throw new ArgumentOutOfRangeException($"index out of range: {count}");
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
                    if(index < count)
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
                    if(index < count )
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
}