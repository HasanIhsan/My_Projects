namespace Exercise5
{


    //a static class called ListExtensions
    public static class ListExtension// Non-nested, non-generic, static class
    {

        //, create and add an extension method called
        //CompareTo that uses a suitable extended type as the first parameter.This
        //method aims to compare the elements of two List<T> instances.The Main
        //method will call this method later in such format listA.CompareTo(listB)
        public static bool CompareTo<T>(this List<T> list1, List<T>? list2)
        {

            //if both list are null
            if(list1== null || list2 == null) return true;


            //if both list have same elements regarless of order
            //but ofcourse i'm ordering them first 
            bool isEqual = Enumerable.SequenceEqual(list1.OrderBy(e => e), list2.OrderBy(e => e));
            if (isEqual)
            { 
                return true;
            }
            else
            {
                //other wise just return false
                return false;
            }



           

        }
    }
    
}