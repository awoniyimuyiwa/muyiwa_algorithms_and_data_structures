using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms
{
    /// <summary>
    /// Given a list of numbers, and a number X,
    /// find and print all pairs of numbers within the list that can be added to get X
    /// </summary>
    class AdditionPairsImplementation
    {
        static void AdditionPairs(List<int> list, int X)
        {
            var listCount = list.Count();
            int remainder;

            for (int index = 0; index < listCount; index++)
            {
                remainder = X - list[index];
                for (int index2 = index + 1; index2 < listCount; index2++)
                {
                    if (list[index2] == remainder)
                    {
                        Console.WriteLine($"{list[index]}, {list[index2]}");
                        break;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("*******ADDITION PAIRS*******");
            Console.WriteLine("Given a list of numbers, and a number X, finds and prints all pairs of numbers within the list that can be added to get X");

            Console.WriteLine("Enter list of numbers. Each number should be separated by comma and space e.g 1, 2, 3:");
            string listInput = Console.ReadLine();
            if (string.IsNullOrEmpty(listInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Input must be a valid string");
                Console.ForegroundColor = ConsoleColor.Gray;
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
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }
            }

            Console.WriteLine("Enter X: ");
            string xInput = Console.ReadLine();
            if (!int.TryParse(xInput, out int x))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: X must be a valid integer");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            Console.WriteLine($"All pairs of numbers that can be added to get {xInput}:");

            AdditionPairs(intList, x);

            Console.WriteLine("*******END OF ADDITION PAIRS*******\n");
        }
    }
}
