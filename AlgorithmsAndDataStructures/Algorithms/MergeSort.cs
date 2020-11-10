using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class MergeSort
    {
        /// <summary>
        /// Sorts <paramref name="items"/> using merge sort algorithm
        /// </summary>
        /// <param name="items">List of items to be sorted</param>
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
        public static void Sort<T>(T[] items) where T : IComparable
        {
            #region Not part of the algorithm
            if (items == null) { throw new ArgumentNullException("items cannot be null"); }
            #endregion

            Sort(items, 0, items.Length - 1);
        }

        static void Sort<T>(T[] items, int startIndex, int endIndex) where T : IComparable
        {
            #region Not part of the algorithm
            if (items == null) { throw new ArgumentNullException("items cannot be null"); }
            if (startIndex < 0) { throw new ArgumentException("startIndex cannot be less than zero"); }
            if (startIndex > endIndex) { throw new ArgumentException("startIndex cannot be greater than endIndex"); }
            if (endIndex > items.Length - 1) { throw new ArgumentException($"endIndex cannot be greater than { items.Length -1 }"); }
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
        static void Merge<T>(T[] items, int startIndex, int middleIndex, int endIndex) where T : IComparable
        {
            int leftSideIndex = startIndex;
            int rightSideIndex = middleIndex+1;

            var sortedItems = new T[items.Length];
            int sortedItemsIndex = 0;

            while (leftSideIndex <= middleIndex && rightSideIndex <= endIndex)
            {
                if (items[leftSideIndex].CompareTo(items[rightSideIndex]) < 0)
                {
                    sortedItems[sortedItemsIndex] = items[leftSideIndex];
                    leftSideIndex++;
                    sortedItemsIndex++;
                }
                else
                {
                    sortedItems[sortedItemsIndex] = items[rightSideIndex];
                    rightSideIndex++;
                    sortedItemsIndex++;
                }
            }

            // Copy items remaining in leftArray to sortedArray
            while (leftSideIndex <= middleIndex)
            {
                sortedItems[sortedItemsIndex] = items[leftSideIndex];
                leftSideIndex++;
                sortedItemsIndex++;
            }

            // Copy items remaining in rightArray to sortedArray
            while (rightSideIndex <= endIndex)
            {
                sortedItems[sortedItemsIndex] = items[rightSideIndex];
                rightSideIndex++;
                sortedItemsIndex++;
            }

            // Copy from sortedItems back to items
            // Note that sortedItemsIndex at this stage will always be equal to the total number of items sorted so it needs to be reduced by 1
            sortedItemsIndex--;
            int itemsIndex = endIndex;
            while (itemsIndex >= startIndex)
            {
                items[itemsIndex] = sortedItems[sortedItemsIndex];
                sortedItemsIndex--;
                itemsIndex--;
            }
        }
    }
}
