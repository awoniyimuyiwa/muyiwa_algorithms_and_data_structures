using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms
{
    /// <summary>
    /// Best case: time: Big-Omega(nlogn), memory: Big-Omega(n) 
    /// Average case: time: Big-Theta(nlogn), memory: Big-Theta(n)
    /// Worst case: time: O(nlogn), memory: O(n)
    /// </summary>
    class MergeSortImplementation
    {
        private static void MergeSort(int[] array, int startIndex, int lastIndex)
        {
            if (startIndex < lastIndex)
            {
                int middleIndex = (startIndex + lastIndex) / 2;

                MergeSort(array, startIndex, middleIndex); // Divide
                MergeSort(array, middleIndex, lastIndex); // Divide
                Merge(array, startIndex, middleIndex, lastIndex); // Conquer
            }
        }

        private static void Merge(int[] array, int firstIndex, int middleIndex, int lastIndex)
        {
            int leftArrayIndex = firstIndex;
            int rightArrayIndex = middleIndex;

            var sortedArray = new int[array.Length];
            int sortedArrayIndex = 0;

            while (leftArrayIndex <= middleIndex && rightArrayIndex <= lastIndex)
            {
                if (array[leftArrayIndex] > array[rightArrayIndex])
                {
                    sortedArray[sortedArrayIndex] = array[rightArrayIndex];
                    rightArrayIndex++;
                }
                else
                {
                    sortedArray[sortedArrayIndex] = array[leftArrayIndex];
                    leftArrayIndex++;
                }

                sortedArrayIndex++;
            }

            // Copy items remaining in leftArray to sortedArray
            while (leftArrayIndex <= middleIndex)
            {
                sortedArray[sortedArrayIndex] = array[leftArrayIndex];
                leftArrayIndex++;
                sortedArrayIndex++;
            }

            // Copy items remaining in rightArray to sortedArray
            while (rightArrayIndex <= lastIndex)
            {
                sortedArray[sortedArrayIndex] = array[rightArrayIndex];
                rightArrayIndex++;
                sortedArrayIndex++;
            }

            // Copy from sortedArray to array
            int index = 0;
            while (index <= sortedArrayIndex)
            {
                array[index] = sortedArray[index];
                index++;
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("*******MERGE SORT*******");

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

            MergeSort(intList.ToArray(), 0, intList.Count());

            Console.WriteLine("Sorted numbers:");
            Console.WriteLine(string.Join(", ", intList));

            Console.WriteLine("*******END OF MERGE SORT*******\n");
        }
    }
}
