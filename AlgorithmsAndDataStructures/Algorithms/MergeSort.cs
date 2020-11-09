using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class MergeSort
    {
        /// <summary>
        /// Sorts <paramref name="items"/> from <paramref name="startIndex"/> to <paramref name="endIndex"/> using merge sort algorithm
        /// </summary>
        /// <param name="items">List of items to be sorted</param>
        /// <param name="startIndex">Index in list to start sorting from</param>
        /// <param name="endIndex">Index in list to stop sorting</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="items"/> is null</exception>
        /// <remarks>
        /// BEST CASE- TIME: Ω(n*log(n)), MEMORY: Ω(n)
        /// AVERAGE CASE- TIME: Θ(n*log(n)), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n*log(n)), MEMORY: O(n)
        /// 
        /// The time complexity is n*log(n) base 2 in the worst case because the size of n gets split by half in each iteration
        /// thereby making it log(n) base2 steps. At each step, another n steps are required for sorting.
        /// maximum of n steps required for sorting in each of the log(n) base 2 steps= n*log(n) base 2 
        /// </remarks>
        public static void Sort(int[] items, int startIndex, int endIndex)
        {
            #region Not part of the algorithm
            if (items == null) { throw new ArgumentNullException("items cannot be null"); }
            #endregion

            if (startIndex < endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;

                Sort(items, startIndex, middleIndex); // Divide
                Sort(items, middleIndex+1, endIndex); // Divide
                Merge(items, startIndex, middleIndex, endIndex); // Conquer
            }
        }

        // Sorting is done here
        static void Merge(int[] array, int startIndex, int middleIndex, int endIndex)
        {
            int leftArrayIndex = startIndex;
            int rightArrayIndex = middleIndex+1;

            var sortedArray = new int[array.Length];
            int sortedArrayIndex = 0;

            while (leftArrayIndex <= middleIndex && rightArrayIndex <= endIndex)
            {
                if (array[leftArrayIndex] < array[rightArrayIndex])
                {
                    sortedArray[sortedArrayIndex] = array[leftArrayIndex];
                    leftArrayIndex++;
                    sortedArrayIndex++;
                }
                else
                {
                    sortedArray[sortedArrayIndex] = array[rightArrayIndex];
                    rightArrayIndex++;
                    sortedArrayIndex++;
                }
            }

            // Copy items remaining in leftArray to sortedArray
            while (leftArrayIndex <= middleIndex)
            {
                sortedArray[sortedArrayIndex] = array[leftArrayIndex];
                leftArrayIndex++;
                sortedArrayIndex++;
            }

            // Copy items remaining in rightArray to sortedArray
            while (rightArrayIndex <= endIndex)
            {
                sortedArray[sortedArrayIndex] = array[rightArrayIndex];
                rightArrayIndex++;
                sortedArrayIndex++;
            }

            // Copy from sortedArray to array
            // Note that sortedArrayIndex at this stage will always be equal to the number of items sorted so it needs to be reduced by 1
            sortedArrayIndex--;
            int arrayIndex = endIndex;
            while (arrayIndex >= startIndex)
            {
                array[arrayIndex] = sortedArray[sortedArrayIndex];
                sortedArrayIndex--;
                arrayIndex--;
            }
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******MERGE SORT*******");
            Console.WriteLine($"{Environment.NewLine}Enter list of numbers. Separate numbers by space e.g 1 20 3:");
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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Environment.NewLine}Sorting...");
            var array = intList.ToArray();
            // Execute
            Sort(array, 0, array.Length-1);

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{Environment.NewLine}Result: ");
            Console.WriteLine(string.Join(" ", array));

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}*******END OF MERGE SORT*******{Environment.NewLine}");
        }
    }
}
