using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    /// <summary>
    /// Finds the number of times a pattern (string or char) occurs in another string
    /// </summary>
    class NumberOfOccurenceImplementation
    {
        /// <summary>
        /// Returns the number of times a pattern occurs in a text    
        /// </summary>
        /// <param name="pattern">Pattern to check in text</param>
        /// <param name="text">Text to search</param>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n) 
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        static int NumberOfOCcurence(string pattern, string text)
        {
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

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******NUMBER OF OCCURRENCE*******");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFinds the number of times a pattern (character or string) occurs in a text");
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
            Console.WriteLine("\nExecuting...");
            // Execute
            var result = NumberOfOCcurence(pattern, text);

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{pattern} occured {result} time(s)");

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\n*******END OF NUMBER OF OCCURRENCE*******\n");
        }
    }
}
