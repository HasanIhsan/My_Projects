using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Xml;

class Program
{
    private static List<string> _words;
    public static SpeechRecognitionEngine recognizer;

    static void Main(string[] args)
    {
        // Initialize the _words list
        _words = new List<string>();

        // Set up the speech recognition engine
        recognizer = new SpeechRecognitionEngine();

        // Load the initial grammar from file
        LoadGrammar(recognizer);

        // Set up event handlers
        recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
        recognizer.SpeechHypothesized += Recognizer_SpeechHypothesized;

        // Start the speech recognition engine
        recognizer.SetInputToDefaultAudioDevice();
        recognizer.RecognizeAsync(RecognizeMode.Multiple);

        // Wait for user input to exit the program
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    private static void LoadGrammar(SpeechRecognitionEngine recognizer)
    {
        // Read the grammar from file
        var grammarPath = "MyGrammar.xml";
        var grammarXml = File.ReadAllText(grammarPath);

        _words.Add("hey");

        // Parse the grammar XML using an XmlDocument
        var grammarDoc = new XmlDocument();
        grammarDoc.LoadXml(grammarXml);

        Console.WriteLine(grammarDoc.OuterXml);
        Console.WriteLine();

        // Select the <one-of> element and append a new <item> element for each new word
        var oneOfElement = grammarDoc.SelectSingleNode("//one-of");
        if (oneOfElement == null)
        {
            // If there's no <one-of> element, create a new one and append it to the root
            oneOfElement = grammarDoc.CreateElement("one-of");
            grammarDoc.DocumentElement.AppendChild(oneOfElement);
        }

        foreach (var newWord in _words.Where(word => !oneOfElement.InnerXml.Contains(word)))
        {
            var newItemElement = grammarDoc.CreateElement("item");
            newItemElement.InnerText = newWord;
            oneOfElement.AppendChild(newItemElement);
        }

        // Write the updated grammar to file
        using (var writer = new XmlTextWriter(grammarPath, null))
        {
            writer.Formatting = Formatting.Indented;
            grammarDoc.Save(writer);
        }

        Console.WriteLine(_words.Count());
        // Load the grammar into the speech recognition engine
        var grammar = new Grammar(grammarPath);
        recognizer.LoadGrammar(grammar);
    }

    private static void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        // Print the recognized text to the console
        Console.WriteLine($"Recognized: {e.Result.Text}");

       
    }


    private static void Recognizer_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
    {
        // Print the hypothesis to the console
        Console.WriteLine($"Hypothesis: {e.Result.Text}");

        // If the user said a new word, add it to the list
        if (!_words.Contains(e.Result.Text))
        {
            _words.Add(e.Result.Text);
            Console.WriteLine($"Added '{e.Result.Text}' to grammar.");
            AddNewWordsToGrammar(_words);
        }
    }


    private static void AddNewWordsToGrammar(List<string> words)
    {
        // Create a new list of choices for the new words
        var choices = new Choices(words.ToArray());

        // Create a new grammar builder from the choices
        var builder = new GrammarBuilder(choices);

        // Create a new grammar object from the builder
        var grammar = new Grammar(builder);

        // Load the new grammar into the recognition engine
        recognizer.UnloadAllGrammars();
        recognizer.LoadGrammar(grammar);
    }
}
