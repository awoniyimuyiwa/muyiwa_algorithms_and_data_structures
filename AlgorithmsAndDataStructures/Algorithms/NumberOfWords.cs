using System;
using System.Text.RegularExpressions;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class NumberOfWords
    {
        /// <summary>
        /// Returns the number of words in <paramref name="text"/>
        /// </summary>
        /// <param name="text">Text to search</param>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n)
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static int Run(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) { return 0; }

            // Pre processing, new memory will be allocated by methods called for preprocessing 
            // Remove consecutive word delimeters
            text = RemoveConsecutiveWordDelimeters.Run(text);
            // Remove word delimeters at the start and end of text.             
            text = text.Trim(' ', '\t', '\n');

            // If text has just one character
            if (text.Length == 1) { return 1; }

            int delimitersCount = 0;
            for (int index = 0; index < text.Length; index++)
            {
                if (text[index].Equals(' ') || text[index].Equals('\t') || text[index].Equals('\n')) 
                { 
                    delimitersCount++;
                }
            }

            // If n delimiters were counted then there are n+1 words
            return delimitersCount + 1;
        }

        /// <summary>
        /// Returns the number of words in <paramref name="text"/> using regular expression
        /// </summary>
        /// <param name="text">Text to search</param>
        public static int RunUsingRegex(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) { return 0; }

            string pattern = "\\w+";
            Regex regex = new Regex(pattern);

            return regex.Matches(text).Count;
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******NUMBER OF WORDS*******");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Environment.NewLine}Counts the number of words in a text");
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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Environment.NewLine}Executing...");
            // Execute
            var result = Run(text);
            
            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Environment.NewLine}{result} word(s)");

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}*******END OF NUMBER OF WORDS*******{Environment.NewLine}");
        }
    }
}
