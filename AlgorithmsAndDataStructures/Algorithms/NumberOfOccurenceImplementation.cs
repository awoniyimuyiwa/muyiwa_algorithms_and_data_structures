using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    /// <summary>
    /// Finds the number of times a pattern (string or char) occurs in another string
    /// </summary>
    class NumberOfOccurenceImplementation
    {
        static int NumberOfOCcurence(string pattern, string text)
        {
            var patternLength = pattern.Length;
            var index = -1;
            var count = 0;

            while ((index = text.IndexOf(pattern)) > -1)
            {
                count += 1;
                text = text.Remove(index, patternLength);
            };

            return count;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("*******NUMBER OF OCCURRENCE*******");
            Console.WriteLine("Finds the number of times a pattern (char or string) appears in a text");
            Console.WriteLine("Enter string: ");

            string text = Console.ReadLine();
            if (string.IsNullOrEmpty(text))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Text must be provided");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            Console.WriteLine("Enter pattern: ");
            string pattern = Console.ReadLine();
            if (pattern == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Pattern must be either a string or character");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            var result = NumberOfOCcurence(pattern, text);
            Console.WriteLine($"{pattern} occured {result} time(s) in {text}");

            Console.WriteLine("*******END OF NUMBER OF OCCURRENCE*******\n");
        }
    }
}
