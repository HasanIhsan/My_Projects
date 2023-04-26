using System;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace plagiarismchecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read the file
            string fileContent = File.ReadAllText("file.txt");

            // Search for websites related to the content of the file
            string[] urlsToScan = SearchForWebsites(fileContent);

            foreach (string url in urlsToScan)
            {
                // Extract text from the website
                string websiteContent = ExtractWebsiteContent(url);

                // Compare the content
                double similarityScore = CalculateSimilarityScore(fileContent, websiteContent);

                // Check if plagiarism is detected
                if (similarityScore > 0.8) // Set the threshold as per your requirements
                {
                    Console.WriteLine("Plagiarism detected in file {0} and website {1}.", fileContent, url);
                }
            }
        }

        static string[] SearchForWebsites(string query)
        {
            // Prepare the Google search query
            string searchUrl = $"https://www.google.com/search?q={query}";

          //  Console.WriteLine(searchUrl);
            // Load the search results page using HtmlAgilityPack
            var web = new HtmlWeb();
            var homePage = web.Load(searchUrl);

            // Extract the URLs from the search results
            var searchResults = homePage.DocumentNode.SelectNodes("//div[@class='g']");
            if (searchResults == null)
            {
                return new string[0];
            }
            string[] urls = searchResults.SelectMany(result => result.Descendants("a")).Select(a => a.GetAttributeValue("href", "")).ToArray();

            return urls;
        }

        static string ExtractWebsiteContent(string url)
        {
            // Load the website using HtmlAgilityPack
            var web = new HtmlWeb();
            var doc = web.Load(url);

            // Extract the text from the website
            var nodes = doc.DocumentNode.DescendantsAndSelf()
                .Where(n => n.NodeType == HtmlNodeType.Text && !string.IsNullOrWhiteSpace(n.InnerHtml));
            string websiteContent = string.Join(" ", nodes.Select(n => n.InnerHtml.Trim()));

            return websiteContent;
        }

        static double CalculateSimilarityScore(string fileContent, string websiteContent)
        {
            // Tokenize the content of the file and website
            string[] fileTokens = fileContent.Split(' ');
            string[] websiteTokens = websiteContent.Split(' ');

            // Get the intersection of the tokens
            var intersection = fileTokens.Intersect(websiteTokens);

            // Calculate the similarity score
            double similarityScore = (double)intersection.Count() / (double)websiteTokens.Count();

            return similarityScore;
        }
    }
}
