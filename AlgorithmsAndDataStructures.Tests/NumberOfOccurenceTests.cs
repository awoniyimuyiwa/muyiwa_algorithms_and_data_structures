using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class NumberOfOccurenceTests
    {
        [Theory]
        [InlineData("hello", "hello world", 1)]
        [InlineData("hello", "hello world hello world again", 2)]
        [InlineData("\t\t", "\t\t \nhello     \t", 1)]
        [InlineData("\n\t", " \n\thello  \t\t \n  world \t\t \n", 1)]
        [InlineData("\t\t \n", " \n\thello  world \t\t \n again \t\t \n", 2)]
        [InlineData(null, null, 1)]
        [InlineData(null, " ", 0)]
        [InlineData(" ", null, 0)]
        [InlineData("", "", 1)]
        [InlineData("", " ", 0)]
        [InlineData(" ", "", 0)]
        public void Run_WhenCalled_ReturnsValidResult(string pattern, string text, int expected)
        {
            var actual = NumberOfOccurence.Run(pattern, text);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("hello", "hello world", 1)]
        [InlineData("hello", "hello world hello world again", 2)]
        [InlineData("\t\t", "\t\t \nhello     \t", 1)]
        [InlineData("\n\t", " \n\thello  \t\t \n  world \t\t \n", 1)]
        [InlineData("\t\t \n", " \n\thello  world \t\t \n again \t\t \n", 2)]
        [InlineData(null, null, 1)]
        [InlineData(null, " ", 0)]
        [InlineData(" ", null, 0)]
        [InlineData("", "", 1)]
        [InlineData("", " ", 0)]
        [InlineData(" ", "", 0)]
        public void RunUsingRegex_WhenCalled_ReturnsValidResult(string pattern, string text, int expected)
        {
            var actual = NumberOfOccurence.RunUsingRegex(pattern, text);

            Assert.Equal(expected, actual);
        }
    }
}
