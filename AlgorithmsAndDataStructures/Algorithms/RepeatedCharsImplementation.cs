using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms
{
    /// <summary>
    /// Finds the characters that occur more than once in a text, prints the characters and the number of times they occur
    /// </summary>
    class RepeatedCharsImplementation
    {
        /// <summary>
        /// Finds and returns a dictionary containing characters in the text as keys
        /// and the number of times each character occurs as value     
        /// </summary>
        /// <param name="text">Text to check</param>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n) 
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static Dictionary<char, int> GetCharToCountMap(string text)
        {
            var array = text.ToCharArray();
            var charToCountMap = new Dictionary<char, int>();

            foreach (char c in array)
            {
                if (charToCountMap.ContainsKey(c))
                {
                    charToCountMap[c] += 1;
                }
                else
                {
                    charToCountMap.Add(c, 1);
                }
            }

            return charToCountMap;
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;
            Console.WriteLine("*******REPEATED CHARACTERS*******");
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFinds all characters that occur more than once in a text, prints the repeated characters and the number of times they occur");
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("Enter text: ");

            // Validate input
            string text = Console.ReadLine();
            if (string.IsNullOrEmpty(text))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Text must be provided");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nExecuting...");
            // Execute
            var charToCountMap = GetCharToCountMap(text);

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nResult:");
            var enumerator = charToCountMap.GetEnumerator();
            var hasDuplicateChars = false;
            KeyValuePair<char, int> keyValuePair;

            do
            {
                keyValuePair = enumerator.Current;
                if (keyValuePair.Value > 1)
                {
                    Console.WriteLine($"{keyValuePair.Key} occurs {keyValuePair.Value} time(s)");
                    hasDuplicateChars = true;
                }
            } while (enumerator.MoveNext());

            if (!hasDuplicateChars) { Console.WriteLine("No repeated characters"); }

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\n*******END OF REPEATED CHARACTERS*******\n");
        }
    }
}
