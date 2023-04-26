using System;
using System.IO;
using System.Speech.Recognition;

class Program
{
    static void Main(string[] args)
    {
        // Set up the speech recognition engine
        var recognizer = new SpeechRecognitionEngine();
        recognizer.SetInputToDefaultAudioDevice();

        // Load a grammar from a file
        var grammar = new Grammar(Path.Combine(Environment.CurrentDirectory, "MyGrammar.xml"));
        recognizer.LoadGrammar(grammar);

        // Set up event handlers
        recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
        recognizer.SpeechHypothesized += Recognizer_SpeechHypothesized;

        // Start the speech recognition engine
        recognizer.RecognizeAsync(RecognizeMode.Multiple);

        // Wait for user input to exit the program
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
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
    }
}
