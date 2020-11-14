using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class NumberOfWordsTests
    {
        [Theory]
        [InlineData("\t\t \nhello     \t", 1)]
        [InlineData(" \n\thello  \t\t \n  world \t\t \n", 2)]
        [InlineData(" \n\thello  world \t\t \n again \t\t \n", 3)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("     ", 0)]
        [InlineData(" \t    \t", 0)]
        [InlineData("a", 1)]
        public void Run_WhenCalled_ReturnsValidResult(string text, int expected)
        {
            var actual = NumberOfWords.Run(text);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("\t\t \nhello     \t", 1)]
        [InlineData(" \n\thello  \t\t \n  world \t\t \n", 2)]
        [InlineData(" \n\thello  world \t\t \n again \t\t \n", 3)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("     ", 0)]
        [InlineData(" \t    \t", 0)]
        [InlineData("a", 1)]
        public void RunUsingRegex_WhenCalled_ReturnsValidResult(string text, int expected)
        {
            var actual = NumberOfWords.RunUsingRegex(text);

            Assert.Equal(expected, actual);
        }
    }
}
