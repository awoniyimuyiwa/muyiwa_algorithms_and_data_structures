using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class AdditionPairs
    {
        /// <summary>
        /// Given a list of <paramref name="numbers"/>, and a number <paramref name="X"/>,
        /// find pairs of numbers within <paramref name="numbers"/> can be added to get <paramref name="X"/>
        /// </summary>
        /// <param name="numbers">List of numbers to search</param>
        /// <param name="X">Addition result</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="numbers"/> is null</exception>
        /// <remarks>
        /// Where n is the size of the list
        /// BEST CASE- TIME: Ω(n^2), MEMORY: Ω(1)
        /// AVERAGE CASE- TIME: Θ(n^2), MEMORY: Θ(1)
        /// WORST CASE- TIME: O(n^2), MEMORY: O(1)
        /// </remarks>
        public static List<Tuple<int, int>> GetPairs(List<int> numbers, int X)
        {
            #region Not part of the algorithm
            if (numbers == null) { throw new ArgumentNullException("numbers cannot be null"); }
            #endregion

            numbers = numbers.Distinct().ToList();
            var numbersCount = numbers.Count();
            var tuples = new List<Tuple<int, int>>();
            int remainder;

            for (int index = 0; index < numbersCount; index++)
            {
                remainder = X - numbers[index];
                for (int index2 = index + 1; index2 < numbersCount; index2++)
                {
                    if (numbers[index2] == remainder)
                    {
                        tuples.Add(Tuple.Create(numbers[index], numbers[index2]));
                        break;
                    }
                }
            }

            return tuples;
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******ADDITION PAIRS*******");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Environment.NewLine}Given a list of numbers, and a number X, finds and prints all pairs of numbers within the list that can be added to get X");
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

            var tuples = GetPairs(intList, x);
            if (tuples.Count() > 0)
            {
                Console.WriteLine($"{Environment.NewLine}Pairs of numbers that can be added to get {xInput}:");
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
            Console.WriteLine($"{Environment.NewLine}*******END OF ADDITION PAIRS*******{Environment.NewLine}");
        }
    }
}
