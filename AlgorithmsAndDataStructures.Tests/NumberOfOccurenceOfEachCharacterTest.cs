using AlgorithmsAndDataStructures.Algorithms;
using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class NumberOfOccurenceOfEachCharacterTest
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void Run_WhenTextIsNotNull_ReturnsValidResult(string text, Dictionary<char, int> expected)
        {
            var actual = NumberOfOccurenceOfEachCharacter.Run(text);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Run_WhenTextIsNull_ThrowsArgumentNullException()
        {
            Action actual = () => NumberOfOccurenceOfEachCharacter.Run((string)null);

            Assert.Throws<ArgumentNullException>(actual);
        }


        public static TheoryData<string, Dictionary<char, int>> GetData()
        {
            return new TheoryData<string, Dictionary<char, int>>()
            {
                {
                    "hello",
                    new Dictionary<char, int>()
                    {
                        { 'h', 1 }, { 'e', 1 }, { 'l', 2 }, { 'o', 1 }
                    }
                },

                {
                    "world",
                    new Dictionary<char, int>()
                    {
                        { 'w', 1 }, { 'o', 1 }, { 'r', 1 }, { 'l', 1 }, { 'd', 1 }
                    }
                },

                {
                    "hello world",
                    new Dictionary<char, int>()
                    {
                        { 'h', 1 }, { 'e', 1 }, { 'l', 3 }, { 'o', 2 },
                        { ' ', 1 }, { 'w', 1 }, { 'r', 1 }, { 'd', 1 }
                    }
                }
            };
        }
    }
}
