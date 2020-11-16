using AlgorithmsAndDataStructures.Algorithms;
using System;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    public class NumberToWordsRunner
    {
        public static int Run(decimal number, IConsole console)
        {
            try
            {
                // Execute
                var words = NumberToWords.Run(number);

                // Display result, capitalize first letter
                console.Out.WriteLine($"Result: { char.ToUpper(words[0]) }{ words.Substring(1) }");
                return 0;
            }
            catch (OverflowException)
            {
                console.Out.WriteLine($"Error: { nameof(number) } is either too large or too small");
                return 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                console.Out.WriteLine($"Error: { nameof(number) } is too large");
                return 1;
            }
         }
    }
}
