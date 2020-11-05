using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    class NthFibonacciImplementation
    {
        /// <summary> 
        /// Returns the number in the fibonacci series at position n
        /// </summary>
        /// <param name="n">Position in the fibonacci series</param>
        /// <remarks>
        /// BEST CASE- TIME: Ω(1), MEMORY: Ω(1) when n is 0 or 1
        /// AVERAGE CASE- TIME: Θ(2^n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(2^n), MEMORY: O(n)
        /// 
        /// The time complexity is 2^n in the worst case
        /// This is because every call to T(n) involves two calls to itself: T(n-1) and T(n-2) 
        /// The function can be presented as T(n) = T(n-1) + T(n-2) and solved by induction.
        /// As n->infinity, T(n) = 2^n
        /// Note that O(2^n) is not the tight bound, the tight bound is O(1.618^n).
        /// Any algorithm that involves X calls to itself with almost the same input n 
        /// in a single iteration has a worst case time complexity of X^n
        /// 
        /// The worst case memory complexity for any algorithm that involves recursion is always O(n)
        ///
        /// This is a naive implementation of Fibonacci, a better approach is  to cache 
        /// the output of each f(n) so they're only called once.
        /// </remarks>
        public static int Fibonacci(int n)
        {
            #region Not part of the algorithm
            if (n < 0) { throw new ArgumentException($"{n} must be at least 0"); }
            #endregion

            if (n == 0 || n == 1) { return n; }
            
            return Fibonacci(n - 1) + Fibonacci(n - 2); 
        }

        /// <summary> 
        /// Returns the number in the fibonacci series at position n
        /// </summary>
        /// <param name="n">Position in the fibonacci series</param>
        /// <remarks>
        /// BEST CASE- TIME: Ω(1), MEMORY: Ω(1) when n is 0 or 1
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(1)
        /// WORST CASE- TIME: O(n), MEMORY: O(1)

        /// Actually, T(n) will take T(n-2) steps 
        /// but in asymptotic analysis, the focus is on growth as n->infinity
        /// </remarks>
        public static int FibonacciIterative(int n)
        {
            #region Not part of the algorithm
            if (n < 0) { throw new ArgumentException($"{n} must be at least 0"); }
            #endregion

            if (n == 0 || n == 1) { return n; }

            var previous2 = 0;
            var previous = 1;

            int sumOfPrevious;
            var iteration = 2;
            do
            {
                sumOfPrevious = previous2 + previous;
                previous2 = previous;
                previous = sumOfPrevious;

                iteration++;
            } while (iteration <= n);

            return sumOfPrevious;
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******NTH FIBONACCI*******");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFinds the number at position n in the fibonacci sequence");
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
            Console.WriteLine("\nExecuting...");
            // Execute
            var result = FibonacciIterative(n-1); //var result = FibonacciImperative(iteration)

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nNumber at position {n} in the fibonacci sequence is: {result}");

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\n*******END OF NTH FIBONACCI*******\n");
        }
    }
}
