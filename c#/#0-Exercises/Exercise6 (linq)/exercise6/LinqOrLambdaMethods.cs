namespace Exercise6
{
    public static class LinqOrLambdaMethods
    {
        /*
         * a. A static method called "LinqFirstCharacter". Within the method, create
              a query using query expression notation (e.g.,from…where…select) to
              get a string (e.g., a,d,c) composed of the first character of every word
              in an array of strings. This method accepts an array of strings as a
              parameter and returns a string.
         */
        public static string LinqFirstCharacter(this string[] words)
        {
            IEnumerable<char> firstCharacters = from word in words
                                                select word[0];
            return string.Join(",", firstCharacters);
        }


        /*
         * b. A static method called "LambdaFirstCharacter" will achieve the same
              business goal as the previous method (1.a) but using the LINQ lambda
              expression.
         */
        public static string LambdaFirstCharacter(this string[] words)
        {
            IEnumerable<char> firstCharacters = words.Select(word => word[0]);
            return string.Join(",", firstCharacters);
        }



        /*
         * c. A static method called "LinqLongestWord". Within the method, create
              a query using query expression notation (i.e. from…where…select) to
              find out the longest word(s) in an array of strings. This method accepts
              an array of strings as a parameter and returns a string. If two words
              have the same length, the method should return one string composed
              of those words in a comma-delimited format (word1,word2) as shown
              in the sample output.
         */
        public static string LinqLongestWord(this string[] words)
        {
      
            IEnumerable<string> longestWords = from word in words
                                               let longestLength = words.Max(w => w.Length)
                                               where word.Length == longestLength
                                               select word;
            return string.Join(",", longestWords);
        }

        /*
         * d. A static method called "LambdaLongestWord" will achieve the same
              business goal as the previous method (1.c) but using the LINQ lambda
              expression. 
         */
        public static string LambdaLongestWord(this string[] words)
        { 
            IEnumerable<string> longestWords = words.Where(w => w.Length == words.Max(w => w.Length));
            return string.Join(",", longestWords);
        }

        /*
         * e. A static method called "LinqShortestWord". Within the method, create
              a query using query expression notation (i.e. from…where…select) to
              find out the shortest word(s) in an array of strings. This method accepts
              an array of strings as a parameter and returns a string. If two words
              have the same length, the method should return one string composed
              of those words in a comma-delimited format (word1,word2) as shown
              in the sample output. 
         */
        public static string LinqShortestWord(this string[] words)
        { 
            IEnumerable<string> shortestWords = from word in words
                                                let shortestLength = words.Min(w => w.Length)
                                                where word.Length == shortestLength
                                                select word;
            return string.Join(",", shortestWords);
        }

        /*
         * f. A static method called "LambdaShortestWord" will achieve the same
              business goal as the previous method (1.e) but using the LINQ lambda
              expression. 
         */
        public static string LambdaShortestWord(this string[] words)
        { 

            IEnumerable<string> shortestWords = words.Where(w => w.Length == words.Min(w => w.Length));
            return string.Join(",", shortestWords);
        }

        /*
         * g. A static method called "LinqWordsCount". Within the method, create
              a query using query expression notation (i.e. from…where…select) to
              count the words in an array of strings. This method accepts an array of
              strings as a parameter and returns a string. 
         */
        public static string LinqWordsCount(this string[] words)
        {
            int totalWords = (from word in words
                              select word).Count();
      

            return totalWords.ToString();
        }

        /*
         * h. A static method called "LambdaWordsCount" will achieve the same
              business goal as the previous method (1.g) but using the LINQ lambda
              expression. 
         */
        public static string LambdaWordsCount(this string[] words)
        {
            int totalWords = words.Count();
            return totalWords.ToString();
        }
    }
}