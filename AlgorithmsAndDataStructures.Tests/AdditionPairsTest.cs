using AlgorithmsAndDataStructures.Algorithms;
using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class AdditionPairsTest
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void GetPairs_WhenNumbersIsNotNull_ReturnsValidResult(List<int> numbers, int X, List<Tuple<int,int>> expected)
        {
           var actual = AdditionPairs.GetPairs(numbers, X);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPairs_WhenNumbersIsNull_ThrowsArgumentNullException()
        {
            Action actual = () => AdditionPairs.GetPairs(null, 0);

            Assert.Throws<ArgumentNullException>(actual);
        }

        public static TheoryData<List<int>, int, List<Tuple<int, int>>> GetData()
        {
            return new TheoryData<List<int>, int, List<Tuple<int, int>>>()
            {
                {
                    new List<int>() { 1, 20, 3 },
                    4,
                    new List<Tuple<int, int>>() 
                    { 
                       new Tuple<int, int>(1, 3)
                    }
                },

                {
                    new List<int>() { 1, 20, 3 },
                    5,
                    new List<Tuple<int, int>>()
                    {
                    }
                },

                {
                    new List<int>() { 6, 3, 2, 5, 0, 1, 4 },
                    6,
                    new List<Tuple<int, int>>()
                    {
                        new Tuple<int, int>(6, 0),
                        new Tuple<int, int>(2, 4),
                        new Tuple<int, int>(5, 1),
                    }
                },

                {
                    new List<int>() { 6, 3, 6, 2, 5, 2, 0, 4, 1, 4 },
                    6,
                    new List<Tuple<int, int>>()
                    {
                        new Tuple<int, int>(6, 0),
                        new Tuple<int, int>(2, 4),
                        new Tuple<int, int>(5, 1),
                    }
                }
            };
        }
    }
}
