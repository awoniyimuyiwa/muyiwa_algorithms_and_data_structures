using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class QuickSort
    {
        /// <summary>
        /// Sorts <paramref name="items"/> using quick sort algorithm
        /// </summary>
        /// <param name="items">List of items to be sorted</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="items"/> is null</exception>
        /// <remarks>
        /// BEST CASE- TIME: Ω(n*log(n)), MEMORY: Ω(n)
        /// AVERAGE CASE- TIME: Θ(n*log(n)), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n^2)), MEMORY: O(n) when partitioning leads to unbalancesd sub-arrays everytime such that no items to the left of partitionIndex after partitioning  
        /// 
        /// The time complexity is n*log(n) base 2 in the best and average case because if partititoning leads to balanced sub-arrays everytime, the size of n gets split by half in each iteration
        /// thereby making it log(n) base2 steps. At each step, another n steps are required for sorting.
        /// maximum of n steps required for sorting in each of the log(n) base 2 steps = n*log(n) base 2 
        /// </remarks>
        public static void Sort<T>(T[] items) where T : IComparable
        {
            if (items == null) { throw new ArgumentNullException(nameof(items)); }

            Sort(items, 0, items.Length - 1);
        }
    
        static void Sort<T>(T[] items, int startIndex, int endIndex) where T : IComparable
        {
            if (startIndex < endIndex)
            {
                int partitionIndex = Partition(items, startIndex, endIndex); // Divide

                Sort(items, startIndex, partitionIndex); // Conquer
                Sort(items, partitionIndex+1, endIndex); // Conquer
            }
        }

        // Partitioning and sorting is done here
        static int Partition<T>(T[] items, int startIndex, int endIndex) where T : IComparable
        {
            int leftSideIndex = startIndex;
            int rightSideIndex = endIndex;
            int partitionIndex = leftSideIndex; 
            T tempForSwapping;
            bool shouldContinuePartitioning = true;

            while (shouldContinuePartitioning) 
            {
                while ((items[partitionIndex].CompareTo(items[rightSideIndex]) < 1) && partitionIndex != rightSideIndex) 
                { rightSideIndex--; }

                if (partitionIndex == rightSideIndex) { shouldContinuePartitioning = false; }
                else if (items[partitionIndex].CompareTo(items[rightSideIndex]) > 0) 
                {
                    tempForSwapping = items[partitionIndex];
                    items[partitionIndex] = items[rightSideIndex];
                    items[rightSideIndex] = tempForSwapping;

                    partitionIndex = rightSideIndex;
                }

                if (shouldContinuePartitioning)
                {
                    while ((items[partitionIndex].CompareTo(items[leftSideIndex]) > -1) && partitionIndex != leftSideIndex) 
                    { leftSideIndex++; }

                    if (partitionIndex == leftSideIndex) { shouldContinuePartitioning = false; }
                    else if (items[partitionIndex].CompareTo(items[leftSideIndex]) < 0) 
                    {
                        tempForSwapping = items[partitionIndex];
                        items[partitionIndex] = items[leftSideIndex];
                        items[leftSideIndex] = tempForSwapping;

                        partitionIndex = leftSideIndex;
                    }
                }
            }

            return partitionIndex;
        }
    }
}
