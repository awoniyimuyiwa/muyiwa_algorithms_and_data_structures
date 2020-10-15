using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms
{
    /// <summary>
    /// Finds the characters that occur more than once in a string, prints the characters and the number of times they occur
    /// </summary>
    class RepeatedCharsImplementation
    {
        /// <summary>
        /// Finds the number of times each character in a string occurs
        /// </summary>
        static Dictionary<char, int> GetCharCountPairs(string input)
        {
            var array = input.ToCharArray();
            var charCountPairs = new Dictionary<char, int>();

            foreach (char c in array)
            {
                if (charCountPairs.ContainsKey(c))
                {
                    charCountPairs[c] += 1;
                }
                else
                {
                    charCountPairs.Add(c, 1);
                }
            }

            return charCountPairs;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("*******REPEATED CHARACTERS*******");
            Console.WriteLine("Finds characters that occur more than once in a string");
            Console.WriteLine("Enter string: ");

            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Input must be a valid string");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            var charCountPairs = GetCharCountPairs(input);
            var enumerator = charCountPairs.GetEnumerator();
            var hasDuplicateChars = false;
            KeyValuePair<char, int> keyValuePair;

            do
            {
                keyValuePair = enumerator.Current;
                if (keyValuePair.Value > 1)
                {
                    Console.WriteLine($"{keyValuePair.Key} has {keyValuePair.Value - 1} duplicate(s)");
                    hasDuplicateChars = true;
                }
            } while (enumerator.MoveNext());

            if (!hasDuplicateChars) { Console.WriteLine("No duplicate characters"); }

            Console.WriteLine("*******END OF REPEATED CHARACTERS*******\n");
        }
    }
}
