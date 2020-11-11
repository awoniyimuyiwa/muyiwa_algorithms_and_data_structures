using AlgorithmsAndDataStructures.Algorithms;
using System;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class RemovConsecutiveWordDelimetersRunner
    {
        public static void Run(string text, IConsole console)
        {
            // Execute
            var result = RemoveConsecutiveWordDelimeters.Run(text);

            // Display result
            console.Out.WriteLine($"Result: {result}");
        }
    }
}
