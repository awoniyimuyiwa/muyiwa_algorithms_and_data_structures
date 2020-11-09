using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class BinarySearchTest
    {
        [Theory]
        [MemberData(nameof(GetDataForIsSorted))]
        public void IsSorted_WhenItemsIsNotNull_ReturnsValidResult(int[] items, bool isAscending, bool expected)
        {
            var actual = BinarySearch.IsSorted(items, isAscending);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsSorted_WhenItemsIsNull_ThrowsArgumentNullException()
        {
            var anyBoolean = true;

            Action actual = () => BinarySearch.IsSorted(null, anyBoolean);

            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Search_WhenHaystackIsNull_ThrowsArgumentNullException()
        {
            Action actual = () => BinarySearch.Search(0, null);

            Assert.Throws<ArgumentNullException>(actual);
        }

        [Theory]
        [MemberData(nameof(GetDataWithSortedHaystack))]
        public void Search_WhenHaystackIsSorted_ReturnsValidResult(int needle, int[] haystack, int expected)
        {
            var actual = BinarySearch.Search(needle, haystack);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataWithUnSortedHaystack))]
        public void Search_WhenHaystackIsUnSorted_ThrowsArgumentException(int needle, int[] haystack)
        {
            Action actual = () => BinarySearch.Search(needle, haystack);

            Assert.Throws<ArgumentException>(actual);
        }

        public static TheoryData<int[], bool, bool> GetDataForIsSorted()
        {
            return new TheoryData<int[], bool, bool>()
            {
                {
                    new int[] { 1, 3, 20 },
                    true,
                    true
                },

                {
                    new int[] { 20, 1, 3 },
                    true,
                    false
                },

                {
                    new int[] { 20, 3, 1 },
                    false,
                    true
                },

                {
                    new int[] { 1, 20, 3 },
                    false,
                    false
                },
            };
        }

        public static TheoryData<int, int[], int> GetDataWithSortedHaystack()
        {
            return new TheoryData<int, int[], int>()
            {
                {
                    1,
                    new int[] { 1, 3, 20 },
                    0
                },

                {
                    3,
                    new int[] { 1, 3, 20 },
                    1
                },

                {
                    20,
                    new int[] { 1, 3, 20 },
                    2
                },
            };
        }

        public static TheoryData<int, int[]> GetDataWithUnSortedHaystack()
        {
            return new TheoryData<int, int[]>()
            {
                {
                    1,
                    new int[] { 3, 1, 20 }
                },

                {
                    3,
                    new int[] { 20, 3, 1 }
                }
            };
        }
    }
}
