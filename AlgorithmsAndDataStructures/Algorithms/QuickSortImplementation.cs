using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms
{

    class QuickSortImplementation
    {
        /// <summary>
        /// Sorts a given list of items
        /// </summary>
        /// <param name="array">List of items to be sorted</param>
        /// <param name="startIndex">Index in list to start sorting from</param>
        /// <param name="endIndex">Index in list to stop sorting</param>
        /// <remarks>
        /// BEST CASE- TIME: Ω(n*log(n)), MEMORY: Ω(n)
        /// AVERAGE CASE- TIME: Θ(n*log(n)), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n^2)), MEMORY: O(n) when partitioning leads to unbalancesd sub-arrays everytime such that no items to the left of partitionIndex after partitioning  
        /// 
        /// The time complexity is n*log(n) base 2 in the best and average case because if partititoning leads to balanced sub-arrays everytime, the size of n gets split by half in each iteration
        /// thereby making it log(n) base2 steps. At each step, another n steps are required for sorting.
        /// maximum of n steps required for sorting in each of the log(n) base 2 steps = n*log(n) base 2 
        /// </remarks>
        public static void QuickSort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int partitionIndex = Partition(array, startIndex, endIndex); // Divide

                QuickSort(array, startIndex, partitionIndex); // Conquer
                QuickSort(array, partitionIndex+1, endIndex); // Conquer
            }
        }

        // Partitioning and sorting is done here
        static int Partition(int[] array, int startIndex, int endIndex)
        {
            int leftArrayIndex = startIndex;
            int rightArrayIndex = endIndex;
            int partitionIndex = leftArrayIndex; 
            int tempForSwapping;
            bool shouldContinuePartitioning = true;

            while (shouldContinuePartitioning) 
            {
                while ((array[partitionIndex] <= array[rightArrayIndex]) && partitionIndex != rightArrayIndex) 
                { rightArrayIndex--; }

                if (partitionIndex == rightArrayIndex) { shouldContinuePartitioning = false; }
                else if (array[partitionIndex] > array[rightArrayIndex]) 
                {
                    tempForSwapping = array[partitionIndex];
                    array[partitionIndex] = array[rightArrayIndex];
                    array[rightArrayIndex] = tempForSwapping;

                    partitionIndex = rightArrayIndex;
                }

                if (shouldContinuePartitioning)
                {
                    while ((array[partitionIndex] >= array[leftArrayIndex]) && partitionIndex != leftArrayIndex) 
                    { leftArrayIndex++; }

                    if (partitionIndex == leftArrayIndex) { shouldContinuePartitioning = false; }
                    else if (array[partitionIndex] < array[leftArrayIndex]) 
                    {
                        tempForSwapping = array[partitionIndex];
                        array[partitionIndex] = array[leftArrayIndex];
                        array[leftArrayIndex] = tempForSwapping;

                        partitionIndex = leftArrayIndex;
                    }
                }
            }

            return partitionIndex;
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******QUICK SORT*******");
            Console.WriteLine("\nEnter list of numbers. Each number should be separated by comma and space e.g 1, 2, 3:");
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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nSorting...");
            var array = intList.ToArray();
            // Execute
            QuickSort(array, 0, array.Length-1);

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nResult:");
            Console.WriteLine(string.Join(", ", array));

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\n*******END OF QUICK SORT*******\n");
        }
    }
}
