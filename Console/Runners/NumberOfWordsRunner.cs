using AlgorithmsAndDataStructures.Algorithms;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class NumberOfWordsRunner
    {
        public static void Run(string text, IConsole console)
        {
            // Execute
            var result = NumberOfWords.RunUsingRegex(text);
            
            // Display result
            console.Out.WriteLine($"Result: { result }");
        }
    }
}
