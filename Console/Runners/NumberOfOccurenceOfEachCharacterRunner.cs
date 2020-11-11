using AlgorithmsAndDataStructures.Algorithms;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class NumberOfOccurenceOfEachCharacterRunner
    {
        public static void Run(string text, IConsole console)
        {
            // Execute
            var charToCountMap = NumberOfOccurenceOfEachCharacter.Run(text);

            // Display result
            console.Out.WriteLine($"Result:");
            foreach (char c in charToCountMap.Keys)
            {
                console.Out.WriteLine($"{c}: {charToCountMap[c]}");
            }
        }
    }
}
