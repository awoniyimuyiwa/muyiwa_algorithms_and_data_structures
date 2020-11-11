using AlgorithmsAndDataStructures.Algorithms;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class RemoveConsecutiveCharacterRunner
    {
        public static void Run(string text, char character, IConsole console)
        {
            // Execute
            var result = RemoveConsecutiveCharacter.Run(text, character);

            // Display result
            console.Out.WriteLine($"Result: {result}");
        }
    }
}
