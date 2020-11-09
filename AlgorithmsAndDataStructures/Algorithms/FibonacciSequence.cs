using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class FibonacciSequence
    {
        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******FIBONACCI SEQUENCE*******");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Environment.NewLine}Generates the first n fibonacci numbers");
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("Enter n: ");
            string input = Console.ReadLine();

            // Validate input
            if (!int.TryParse(input, out int n) || n < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: n must be a valid integer not less than 1");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Environment.NewLine}Executing...");

            // Execute and display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Environment.NewLine}Result: ");
            for (int iteration = 1; iteration <= n; iteration++)
            {
                Console.WriteLine(NthFibonacci.Fibonacci(iteration - 1));
            }

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}*******END OF FIBONACCI SEQUENCE*******{Environment.NewLine}");
        }
    }
}
