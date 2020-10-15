using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    class NthFibonacciImplementation
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("*******NTH FIBONACCI*******");
            Console.WriteLine("Finds the number at position n in the fibonacci sequence");
            Console.WriteLine("Enter n: ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int n) || n < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: n must be a valid integer not less than 1");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            var result = FibonacciSequenceImplementation.Fibonacci(n - 1);
            Console.WriteLine($"Number at position {n} in the fibonacci sequence is: {result}");

            Console.WriteLine("*******END OF NTH FIBONACCI*******\n");
        }
    }
}
