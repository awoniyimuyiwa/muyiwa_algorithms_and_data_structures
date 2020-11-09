using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class NumberOfOccurenceOfEachCharacter
    {
        /// <summary>
        /// Finds and returns a dictionary containing characters in the text as keys
        /// and the number of times each character occurs as value     
        /// </summary>
        /// <param name="text">Text to check</param>
        /// <returns>Dictionary containing characters in the text as keys and the number of times each character occurs as value</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="text"/> is null</exception>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n) 
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static Dictionary<char, int> Run(string text)
        {
            #region Not part of the algorithm
            if (text == null) { throw new ArgumentNullException("text cannot be null"); }
            #endregion

            var array = text.ToCharArray();
            var charToCountMap = new Dictionary<char, int>();

            foreach (char c in array)
            {
                if (charToCountMap.ContainsKey(c))
                {
                    charToCountMap[c]++;
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
            Console.WriteLine("*******NUMBER OF OCCURENCE OF EACH CHARACTER*******");
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Environment.NewLine}Finds and prints the number of times each character in a text occurs");
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}Enter text: ");

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
            Console.WriteLine($"{Environment.NewLine}Executing...");
            // Execute
            var charToCountMap = Run(text);

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Environment.NewLine}Result:");
            
            foreach(char c in charToCountMap.Keys)
            {
                Console.WriteLine($"{c} occurs {charToCountMap[c]} time(s)");
            }

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}*******END OF NUMBER OF OCCURENCE OF EACH CHARACTER*******{Environment.NewLine}");
        }
    }
}
