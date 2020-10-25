using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms
{
    /// <summary>
    /// Given a list of numbers, and a number X,
    /// find and print all pairs of numbers within the list that can be multiplied to get X
    /// </summary>
    class MultiplicationPairsImplementation
    {
         // <summary>
        /// Given a list of numbers, and a number X,
        /// find and print all pairs of numbers within the list that can be multiplied to get X
        /// </summary>
        /// <param name="list">List of numbers to search</param>
        /// <param name="X">Multiplication result</param>
        /// <remarks>
        /// Where n is the size of the list
        /// BEST CASE- TIME: Ω(n^2), MEMORY: Ω(1)
        /// AVERAGE CASE- TIME: Θ(n^2), MEMORY: Θ(1)
        /// WORST CASE- TIME: O(n^2), MEMORY: O(1)
        /// </remarks>
        static void PrintMultiplicationPairs(List<int> list, int X)
        {
            var listCount = list.Count();
            int quotient = 0;

            for (int index = 0; index < listCount; index++)
            {
                // Avoid division by zero exception
                if (list[index] != 0)
                {
                    quotient = X / list[index];
                }

                for (int index2 = index + 1; index2 < listCount; index2++)
                {
                    if (list[index] == 0 && X == 0)
                    {
                        Console.WriteLine($"{list[index]}, {list[index2]}");
                    }
                    else if (list[index2] == quotient)
                    {
                        Console.WriteLine($"{list[index]}, {list[index2]}");
                        break;
                    }
                }
            }
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******MULTIPLICATION PAIRS*******");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nGiven a list of numbers, and a number X, finds and prints all pairs of numbers within the list that can be multiplied to get X");
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("Enter list of numbers. Each number should be separated by comma and space e.g 1, 2, 3:");
            string listInput = Console.ReadLine();

            // Validate input 
            if (string.IsNullOrEmpty(listInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Input must be a valid string");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            var intList = new List<int>();
            var stringArray = listInput.Split(", ");
            foreach (string s in stringArray)
            {
                if (int.TryParse(s, out int sAsInt))
                {
                    intList.Add(sAsInt);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: {s} is not a valid integer");
                    Console.ForegroundColor = defaultForegroundColor;
                    return;
                }
            }

            Console.WriteLine("Enter X: ");
            string xInput = Console.ReadLine();
            if (!int.TryParse(xInput, out int x))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: X must be a valid integer");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nExecuting...");
            // Execute and display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nAll pairs of numbers that can be multiplied to get {xInput}:");
            // Execute
            PrintMultiplicationPairs(intList, x);

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\n*******END OF MULTIPLICATION PAIRS*******\n");
        }
    }
}
