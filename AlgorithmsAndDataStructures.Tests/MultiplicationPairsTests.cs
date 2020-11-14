using AlgorithmsAndDataStructures.Algorithms;
using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class MultiplicationPairsTests
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void GetPairs_WhenNumbersIsNotNull_ReturnsValidResult(List<int> numbers, int X, List<Tuple<int, int>> expected)
        {
            var actual = MultiplicationPairs.GetPairs(numbers, X);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPairs_WhenNumbersIsNull_ThrowsArgumentNullException()
        {
            Action actual = () => MultiplicationPairs.GetPairs(null, 0);

            Assert.Throws<ArgumentNullException>(actual);
        }

        public static TheoryData<List<int>, int, List<Tuple<int, int>>> GetData()
        {
            return new TheoryData<List<int>, int, List<Tuple<int, int>>>()
            {
                {
                    new List<int>() { 1, 20, 3 },
                    3,
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
                    new List<int>() { 6, 3, 20, 2, 1 },
                    6,
                    new List<Tuple<int, int>>()
                    {
                        new Tuple<int, int>(6, 1),
                        new Tuple<int, int>(3, 2)
                    }
                },

                {
                    new List<int>() { 6, 3, 2, 20, 6, 2, 1 },
                    6,
                    new List<Tuple<int, int>>()
                    {
                        new Tuple<int, int>(6, 1),
                        new Tuple<int, int>(3, 2)
                    }
                },

                {
                    new List<int>() { 6, 3, 0, 2, 20 },
                    0,
                    new List<Tuple<int, int>>()
                    {
                        new Tuple<int, int>(6, 0),
                        new Tuple<int, int>(3, 0),
                        new Tuple<int, int>(0, 2),
                        new Tuple<int, int>(0, 20),
                    }
                },

                {
                    new List<int>() { 4, 0, 2, 8 },
                    0,
                    new List<Tuple<int, int>>()
                    {
                        new Tuple<int, int>(4, 0),
                        new Tuple<int, int>(0, 2),
                        new Tuple<int, int>(0, 8),
                    }
                },

                {
                    new List<int>() { 4, 6, 2, 8 },
                    10,
                    new List<Tuple<int, int>>()
                    {
                    }
                },
            };
        }
    }
}
