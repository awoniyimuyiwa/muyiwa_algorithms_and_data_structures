using AlgorithmsAndDataStructures.Algorithms;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class PalindromeRunner
    {
        public static void Run(string text, IConsole console)
        {
            // Execute
            var result = Palindrome.IsPalindrome(text);

            // Display result
            console.Out.WriteLine($"Result: {result}");
        }
    }
}
