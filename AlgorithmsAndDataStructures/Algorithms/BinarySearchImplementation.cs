using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms
{
    /// <summary>
    /// BEST CASE- TIME: Big-Omega(log (n)), MEMORY: Big-Omega(1) 
    /// AVERAGE CASE- TIME: Big-Theta(log (n)), MEMORY: Big-Theta(1)
    /// WORST CASE- TIME: O(log (n)), MEMORY: O(1)
    /// </summary>
    class BinarySearchImplementation
    {
        static int BinarySearch(int needle, int[] haystack)
        {
            int startIndex = 0;
            int endIndex = haystack.Count() - 1;

            while (startIndex <= endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;

                if (needle == haystack[middleIndex]) { return middleIndex; }
                else if (needle < haystack[middleIndex]) { endIndex = middleIndex - 1; }
                else { startIndex = middleIndex + 1; }
            }

            return -1;
        }

        static bool IsSorted(int[] array, bool ascending = true)
        {
            var isSorted = true;
            var arrayLength = array.Length;

            for (int index = 1; index < arrayLength; index++)
            {
                if (ascending)
                {
                    if (array[index - 1] > array[index])
                    {
                        isSorted = false;
                        break;
                    }
                }
                else
                {
                    if (array[index - 1] < array[index])
                    {
                        isSorted = false;
                        break;
                    }
                }
            }

            return isSorted;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("*******BINARY SEARCH*******");

            Console.WriteLine("Enter numbers separated by comma and space e.g 1, 2, 3:");
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

            Console.WriteLine("Enter number to search: ");
            string numberToSearchInput = Console.ReadLine();
            if (!int.TryParse(numberToSearchInput, out int numberToSearch))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: number to search must be a valid integer");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            var intArray = intList.ToArray();
            // Ensure items in haystack are sorted in ascending order
            if (!IsSorted(intArray))
            {
                Console.WriteLine("Items are not sorted in ascending order! Sorting...");
                intArray.OrderBy(x => x);
                Console.WriteLine("Sorting done!");
            }

            int index = BinarySearch(numberToSearch, intArray);
            if (index > -1) { Console.WriteLine($"{numberToSearch} is at index: {index} in the list"); }
            else { Console.WriteLine($"{numberToSearch} was not found in the list"); }
            Console.WriteLine("*******END OF BINARY SEARCH*******\n");
        }
    }
}
