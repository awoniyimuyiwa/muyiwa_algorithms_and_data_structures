using AlgorithmsAndDataStructures.Algorithms;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class NumberOfOccurenceRunner
    {
        public static void Run(string text, string pattern, IConsole console)
        {
            // Execute
            int numOcccurence = NumberOfOccurence.RunUsingRegex(pattern, text);

            // Display result
            console.Out.WriteLine($"Result: { numOcccurence }");
        }
    }
}
