using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class Palindrome
    {
        /// <summary>
        /// Checks if <paramref name="text"/> is a palindrome
        /// </summary>
        /// <param name="text">Text to check</param>
        /// <returns>true if <paramref name="text"/> is a palindrome, false otherwise</returns>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n) 
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static bool IsPalindrome(string text)
        {
            if (text == null) { return false; }
           
            var reversedText = ReverseText.Run(text);

            if (reversedText.Equals(text)) { return true; }

            return false;
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******PALINDROME*******");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Environment.NewLine}Given a text, checks if reverse of the text is the same as the text");
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
            var result = IsPalindrome(text);

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            if (result)
            {
                Console.WriteLine($"{Environment.NewLine}{text} is a palindrome");
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine}{text} is not a palindrome");
            }

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}*******END OF PALINDROME*******{Environment.NewLine}");
        }
    }
}
