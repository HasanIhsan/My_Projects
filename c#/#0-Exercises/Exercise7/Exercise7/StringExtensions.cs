namespace Exercise7
{
    public static class StringExtensions
    {
        //find word method:
        /*
         * . Add an extension method to the "StringExtensions" class called "FindWord"
            to extend the string data type to search for a word in a string. This method
            has two parameters: 
            the string object (that is being extended by this method)
            and a "word" of type string. 
        
            You should use LINQ methods or Lambda
            expressions in finding the target word. This method returns true when the
            word is found; false otherwise.
        
            You may use a set of separators such as
            commas, periods, and spaces to split the string into a group of words. 
            
            You can also use more separators if this makes sense to you. Use this method
            whenever you’re looking for a word in a string in this project. 

         */
        public static bool FindWord(this string input, string word)
        {
            char[] separators = new[] { ',', '.', ' ' }; //add more separators as needed
            string[] words = input.Split(separators);
            return words.Any(w => w.Equals(word));
        }


    }
}