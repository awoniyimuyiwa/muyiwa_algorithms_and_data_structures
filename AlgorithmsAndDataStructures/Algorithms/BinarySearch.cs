using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class BinarySearch
    {
        /// <summary>
        /// Search for <paramref name="needle"/> in <paramref name="haystack"/> using binary search algorithm
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
        public static int Search<T>(T needle, T[] haystack) where T : IComparable
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

                int comparisonResult = needle.CompareTo(haystack[middleIndex]);
                if ( comparisonResult == 0) { return middleIndex; }
                else if (comparisonResult < 0) { endIndex = middleIndex - 1; }
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
        public static bool IsSorted<T>(T[] items, bool isAscending = true) where T : IComparable
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
                    if (items[index - 1].CompareTo(items[index]) > 0)
                    {
                        isSorted = false;
                        break;
                    }
                }
                else
                {
                    if (items[index - 1].CompareTo(items[index]) < 0)
                    {
                        isSorted = false;
                        break;
                    }
                }
            }

            return isSorted;
        }
    }
}
