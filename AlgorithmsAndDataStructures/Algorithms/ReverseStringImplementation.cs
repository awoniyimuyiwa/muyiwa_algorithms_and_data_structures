using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    class ReverseStringImplementation
    {
        public static string Reverse(string input)
        {
            var array = input.ToCharArray();
            Array.Reverse(array);

            return new string(array);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("*******STRING REVERSE*******");
            Console.WriteLine("Enter string to reverse: ");

            string stringToReverse = Console.ReadLine();
            if (string.IsNullOrEmpty(stringToReverse))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Input must be a valid string");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            var result = Reverse(stringToReverse);
            Console.WriteLine($"Result: {result}");

            Console.WriteLine("*******END OF STRING REVERSE*******\n");
        }
    }
}
