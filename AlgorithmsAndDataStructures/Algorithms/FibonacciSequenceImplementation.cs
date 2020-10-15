using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    class FibonacciSequenceImplementation
    {
        public static int Fibonacci(int n)
        {
            if (n == 0 || n == 1) { return n; }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static int FibonacciImperative(int n)
        {
            if (n == 0 || n == 1) { return n; }

            var previous2 = 0;
            var previous = 1;

            int sumOfPrevious;
            var iteration = 2;
            do
            {
                sumOfPrevious = previous + previous2;
                previous2 = previous;
                previous = sumOfPrevious;

                iteration++;
            }
            while (iteration < n);

            return sumOfPrevious;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("*******FIBONACCI SEQUENCE*******");
            Console.WriteLine("Generates the first n fibonacci numbers");
            Console.WriteLine("Enter n: ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int n) || n < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: n must be a valid integer not less than 1");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            Console.WriteLine($"Result: ");
            for (int iteration = 0; iteration < n; iteration++)
            {
                Console.WriteLine(Fibonacci(iteration));
                //Console.WriteLine(FibonacciImperative(iteration));
            }

            Console.WriteLine("*******END OF FIBONACCI SEQUENCE*******\n");
        }
    }
}
