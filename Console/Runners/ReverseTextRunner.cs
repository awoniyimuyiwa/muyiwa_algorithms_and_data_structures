using AlgorithmsAndDataStructures.Algorithms;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class ReverseTextRunner
    {
        public static void Run(string text, IConsole console)
        {
            // Execute
            var result = ReverseText.Run(text);

            // Display result
            console.Out.WriteLine($"Result: {result}");
        }
    }
}
