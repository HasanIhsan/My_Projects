using System.Text.RegularExpressions;
using System.Net.Http;
using System.Threading.Tasks;

namespace Exercise7
{
    public static class WebAsyncMethods
    {
        //i use client alot so i made it a global var
       public static HttpClient _client;

        /*
         * Create an asynchronous method called "GetPageLength" that
            returns a web page's length. 
        
            The method downloads the content of the
            target page into a string (you can use an HttpClient object for this) and then
            returns the string length. 
        
            This method accepts only one string URL
            parameter to hold the address of a web page. 
         */
        public static async Task<int> GetPageLength(string url)
        {
            _client = new HttpClient();
            string content = await _client.GetStringAsync(url);
            return content.Length;
        }


        /*
         * Create an asynchronous method called "GetLargestPage" to
            find a web page with the most words for a given set of web addresses. 
        
            This method only accepts an array of strings called "urls" to hold several web
            pages' addresses and returns the URL of the longest page as a string.
        
            The method should call GetPageLength for each URL such that the calls will run
            concurrently rather than consecutively
         */
        public static async Task<string> GetLargestPage(string[] urls)
        {
            // creating a list of anonymous objects
            //each object has two properties: "Url" and "Task".
            //takes a single argument "url" and returns a new object with the "Url" property set to the input "url" and the "Task" property set to the result of the function call "GetPageLength(url)".
            var tasks = urls.Select(url => new { Url = url, Task = GetPageLength(url) }).ToList();
            await Task.WhenAll(tasks.Select(x => x.Task));

            // creating a list of anonymous objects
            //and ordering them and geting the first
            var largest = tasks.OrderByDescending(x => x.Task.Result).FirstOrDefault();
            return largest?.Url;
        }


        /*
         * Create an asynchronous method called "IsWordFound" that
            searches for a particular word within a web page. 
        
            This method accepts two
            string parameters: word and url. 
        
            It returns Boolean true when found,
            otherwise false. 
         */
        public static async Task<bool> IsWordFound(string word, string url)
        {
            _client = new HttpClient();
            string content = await _client.GetStringAsync(url);
            return content.Contains(word);
        }


        /*
         * Create an asynchronous method called "GetWordCount" that
            looks up the number of occurrences of a particular word in multiple web
            pages.
        
            This method accepts a word as a string and an array of strings for
            holding the urls of web pages. 
        
            It returns a summary report showing the word
            count on each web page (hint, you may let this method return a
            Dictionary<TKey,TValue> object having the URL as the key and the word
            count as its value)
         */
        public static async Task<Dictionary<string, int>> GetWordCount(string word, string[] urls)
        {
            _client = new HttpClient();

            
            // create a list of anonymous objects
            // with "Url" and "WordCount" properties, by processing each URL in the "urls" collection
            var tasks = urls.Select(async url =>
            {
                // Use an HttpClient instance to asynchronously fetch the HTML content at the current URL
                var html = await _client.GetStringAsync(url);

                // Count the occurrences of the given "word" in the HTML content
                // and create a new anonymous object with "Url" and "WordCount" properties
                return new { Url = url, WordCount = CountWord(html, word) };
            }).ToList();

            //anonymous object
            var results = await Task.WhenAll(tasks);

            //return the count
            return results.ToDictionary(r => r.Url, r => r.WordCount);
        }


        // Helper Method
        private static int CountWord(string text, string word)
        {
            return text.ToLower().Split(new[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Count(w => w == word.ToLower());
        }

       

    }
}