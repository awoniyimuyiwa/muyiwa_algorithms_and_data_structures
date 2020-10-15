using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    class PalindromeImplementation
    {
        static bool IsPalindrome(string input)
        {
            var reversedInput = ReverseStringImplementation.Reverse(input);

            if (reversedInput.Equals(input)) { return true; }

            return false;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("*******PALINDROME*******");
            Console.WriteLine("Enter string: ");

            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Input must be a valid string");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            if (IsPalindrome(input))
            {
                Console.WriteLine($"{input} is a palindrome");
            }
            else
            {
                Console.WriteLine($"{input} is not a palindrome");
            }

            Console.WriteLine("*******END OF PALINDROME*******\n");
        }
    }
}
