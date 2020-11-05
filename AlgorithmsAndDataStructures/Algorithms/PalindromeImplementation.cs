using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    class PalindromeImplementation
    {
        /// <summar>
        /// Returns true if text is a palindrome, false otherwise.   
        /// <summary>
        /// <param name="text">Text to check</param>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n) 
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static bool IsPalindrome(string text)
        {
            #region Not part of the algorithm
            if (text == null) { throw new ArgumentException($"text cannot be null"); }
            #endregion

            var reversedText = ReverseTextImplementation.Reverse(text);

            if (reversedText.Equals(text)) { return true; }

            return false;
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******PALINDROME*******");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nGiven a text, checks if reverse of the text is the same as the text");
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
            Console.WriteLine($"\nExecuting...");
            // Execute
            var result = IsPalindrome(text);

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            if (result)
            {
                Console.WriteLine($"\n{text} is a palindrome");
            }
            else
            {
                Console.WriteLine($"\n{text} is not a palindrome");
            }

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\n*******END OF PALINDROME*******\n");
        }
    }
}
