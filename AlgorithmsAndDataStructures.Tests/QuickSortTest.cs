using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class QuickSortTest
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void Sort_WhenItemsIsNotNull_ReturnsValidResult(int[] items, int[] expected)
        {
            QuickSort.Sort(items, 0, items.Length-1);
           
            Assert.Equal(expected, items);
        }

        [Fact]
        public void Sort_WhenItemsIsNull_ThrowsArgumentNullException()
        {
            Action actual = () => QuickSort.Sort(null, 0, 0);

            Assert.Throws<ArgumentNullException>(actual);
        }

        public static TheoryData<int[], int[]> GetData()
        {
            return new TheoryData<int[], int[]>()
            {
                {
                    new int[] { 1, 20, 3 },
                    new int[] { 1, 3, 20 }
                },

                {
                    new int[] { 1, 20, 3, 50, 60, 7, 10 },
                    new int[] { 1, 3, 7, 10, 20, 50, 60 }
                },

                {
                    new int[] { 1, 3, 20 },
                    new int[] { 1, 3, 20 }
                },
            };
        }
    }
}
