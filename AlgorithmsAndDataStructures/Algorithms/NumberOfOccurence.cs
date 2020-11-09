using System;
using System.Text.RegularExpressions;

namespace AlgorithmsAndDataStructures.Algorithms
{
    /// <summary>
    /// Finds the number of times a pattern (string or char) occurs in another string
    /// </summary>
    public class NumberOfOccurence
    {
        /// <summary>
        /// Returns the number of times <paramref name="pattern"/> occurs in <paramref name="text"/>
        /// </summary>
        /// <param name="pattern">Pattern to check in text</param>
        /// <param name="text">Text to search</param>
        /// <returns>Number of times <paramref name="pattern"/> occurs in <paramref name="text"/></returns>        
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n) 
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static int Run(string pattern, string text)
        {
            if (pattern == null && text == null) { return 1;  }
            if (text == null || pattern == null) { return 0; }

            var patternLength = pattern.Length;
            var count = 0;

            int index;
            while ((index = text.IndexOf(pattern)) > -1)
            {
                count++;
                text = text.Remove(index, patternLength);
            };

            return count;
        }

        /// <summary>
        /// Returns the number of times <paramref name="pattern"/> occurs in <paramref name="text"/> using regular expression   
        /// </summary>
        /// <param name="pattern">Pattern to check in text</param>
        /// <param name="text">Text to search</param>
        /// <returns>Number of times <paramref name="pattern"/> occurs in <paramref name="text"/></returns>
        public static int RunUsingRegex(string pattern, string text)
        {
            if (pattern == null && text == null) { return 1; }
            if (text == null || pattern == null) { return 0; }

            Regex regex = new Regex(pattern);

            return regex.Matches(text).Count;
        }

            public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******NUMBER OF OCCURRENCE*******");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Environment.NewLine}Finds the number of times a pattern (character or string) occurs in a text");
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("Enter text: ");
            string text = Console.ReadLine();

            // Validate input
            if (string.IsNullOrEmpty(text))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Text must be provided");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            Console.WriteLine("Enter pattern: ");
            string pattern = Console.ReadLine();
            if (pattern == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Pattern must be either a string or character");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Environment.NewLine}Executing...");
            // Execute
            var result = Run(pattern, text);

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Environment.NewLine}{pattern} occured {result} time(s)");

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}*******END OF NUMBER OF OCCURRENCE*******{Environment.NewLine}");
        }
    }
}
