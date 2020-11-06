using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms
{
    class MultiplicationPairs
    {
        /// <summary>
        /// Given a list of numbers, and a number X,
        /// finds all pairs of numbers within the list that can be multiplied to get X
        /// </summary>
        /// <param name="list">List of numbers to search</param>
        /// <param name="X">Multiplication result</param>
        /// <remarks>
        /// Where n is the size of the list
        /// BEST CASE- TIME: Ω(n^2), MEMORY: Ω(1)
        /// AVERAGE CASE- TIME: Θ(n^2), MEMORY: Θ(1)
        /// WORST CASE- TIME: O(n^2), MEMORY: O(1)
        /// </remarks>
        public static List<Tuple<int, int>> GetMultiplicationPairs(List<int> list, int X)
        {
            var tuples = new List<Tuple<int, int>>();
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
                        tuples.Add(Tuple.Create(list[index], list[index2]));
                    }
                    else if (list[index2] == quotient)
                    {
                        tuples.Add(Tuple.Create(list[index], list[index2]));
                        break;
                    }
                }
            }

            return tuples;
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******MULTIPLICATION PAIRS*******");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Environment.NewLine}Given a list of numbers, and a number X, finds and prints all pairs of numbers within the list that can be multiplied to get X");
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}Enter list of numbers. Separate numbers by a space e.g 1 20 3:");
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
            var stringArray = listInput.Split(" ");
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
            Console.WriteLine($"{Environment.NewLine}Executing...");
            // Execute and display result
            Console.ForegroundColor = ConsoleColor.Green;
            
            var tuples = GetMultiplicationPairs(intList, x);
            if (tuples.Count() > 0)
            {
                Console.WriteLine($"{Environment.NewLine}Pairs of numbers that can be multiplied to get {xInput}:");
                foreach (Tuple<int, int> tuple in tuples)
                {
                    Console.WriteLine($"{tuple.Item1}, {tuple.Item2}");
                }
            } 
            else
            {
                Console.WriteLine($"{Environment.NewLine}None of the numbers can be multiplied to get {xInput}");
            }
            

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}*******END OF MULTIPLICATION PAIRS*******{Environment.NewLine}");
        }
    }
}
