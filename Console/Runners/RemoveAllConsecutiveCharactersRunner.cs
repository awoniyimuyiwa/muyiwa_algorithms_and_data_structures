using AlgorithmsAndDataStructures.Algorithms;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class RemoveAllConsecutiveCharactersRunner
    {
        public static void Run(string text, IConsole console)
        {
            // Execute
            var result = RemoveAllConsecutiveCharacters.Run(text);

            // Display result
            console.Out.WriteLine($"Result: { result }");
        }
    }
}
