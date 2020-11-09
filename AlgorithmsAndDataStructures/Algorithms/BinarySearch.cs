using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class BinarySearch
    {
        /// <summary>
        /// Searches for <paramref name="needle"/> in <paramref name="haystack"/> using binary search algorithm
        /// </summary>
        /// <param name="needle">item to be searched</param>
        /// <param name="haystack">list in which to search for needle, items in the list must be sorted in ascending order</param>
        /// <returns>The index of <paramref name="needle"/> in <paramref name="haystack"/> if <paramref name="needle"/> exists in <paramref name="haystack"/>, -1 otherwise</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="haystack"/> is not sorted in ascending order</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="haystack"/> is null</exception>
        /// <remarks>
        /// BEST CASE- TIME: Ω(1), MEMORY: Ω(1) when needle is at the center of haystack
        /// AVERAGE CASE- TIME: Θ(log(n)), MEMORY: Θ(1)
        /// WORST CASE- TIME: O(log(n)), MEMORY: O(1)
        /// 
        /// The time complexity is log(n) base 2 in the worst case because the size of n gets split by half in each 
        /// That means the function can be presented as T(n) = a + T(n/2) where a is some constant
        /// Any function that splits its input size n by X in each iteration has a worst case time complexity of log(n) base X,
        /// A function that splits its input size n by 5 in every call for instance will have a worst case time complexity of log(n) base 5
        /// </remarks>
        public static int Search(int needle, int[] haystack)
        {
            #region Not part of the algorithm
            if (haystack == null) { throw new ArgumentNullException("haystack cannot be null"); }
            if (!IsSorted(haystack)) { throw new ArgumentException($"Items in haystack must be sorted in ascending order"); }
            #endregion

            int startIndex = 0;
            int endIndex = haystack.Length - 1;

            while (startIndex <= endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;

                if (needle == haystack[middleIndex]) { return middleIndex; }
                else if (needle < haystack[middleIndex]) { endIndex = middleIndex - 1; }
                else { startIndex = middleIndex + 1; }
            }

            return -1;
        }

        /// <summary>
        /// Detects if <paramref name="items"/> are sorted in the desired order
        /// </summary>
        /// <param name="items"></param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="items"/> is null</exception>
        /// <param name="isAscending">Set to true to check if <paramref name="items"/> are sorted in ascending order, set to false otherwise</param>
        /// <returns>true if items are sorted in the desired order, false otherwise</returns>
        public static bool IsSorted(int[] items, bool isAscending = true)
        {
            #region Not part of the algorithm
            if (items == null) { throw new ArgumentNullException("items cannot be null"); }
            #endregion

            var isSorted = true;
            var arrayLength = items.Length;

            for (int index = 1; index < arrayLength; index++)
            {
                if (isAscending)
                {
                    if (items[index - 1] > items[index])
                    {
                        isSorted = false;
                        break;
                    }
                }
                else
                {
                    if (items[index - 1] < items[index])
                    {
                        isSorted = false;
                        break;
                    }
                }
            }

            return isSorted;
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******BINARY SEARCH*******");
            Console.WriteLine($"{Environment.NewLine}Enter list of numbers. Separate numbers by a space e.g 1 20 3:");

            // Validate input
            string listInput = Console.ReadLine();
            if (string.IsNullOrEmpty(listInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: List of numbers must be provided");
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

            Console.WriteLine("Enter number to search: ");
            string numberToSearchInput = Console.ReadLine();
            if (!int.TryParse(numberToSearchInput, out int numberToSearch))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: number to search must be a valid integer");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            // Pre-execution
            var intArray = intList.ToArray();
            // Ensure items in haystack are sorted in ascending order
            if (!IsSorted(intArray))
            {
                Console.WriteLine($"{Environment.NewLine}Items are not sorted! Sorting...");
                intArray = intArray.OrderBy(x => x).ToArray();
                //intArray = MergeSort.Sort(intArray);
                Console.WriteLine($"Sorted items: {string.Join(", ", intArray)}");
            }

            Console.WriteLine($"{Environment.NewLine}Searching...");
            // Execute
            int index = Search(numberToSearch, intArray);

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            if (index > -1) { Console.WriteLine($"{Environment.NewLine}{numberToSearch} is at position: {index + 1} in the list"); }
            else { Console.WriteLine($"{Environment.NewLine}{numberToSearch} was not found in the list"); }

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}*******END OF BINARY SEARCH*******{Environment.NewLine}");
        }
    }
}