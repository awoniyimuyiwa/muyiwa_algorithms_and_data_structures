using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class RemoveConsecutiveWordDelimetersTests
    {
        [Theory]
        [InlineData("hello\n\t\t\n  world\t", "hello\nworld\t")]
        [InlineData("\t\t\t\n  \t\n\n hello \t\t world\n\n\n\t\n", "\thello world\n")]
        [InlineData("\t ", "\t")]
        [InlineData("\n ", "\n")]
        [InlineData("\t\n", "\t")]
        [InlineData("\n\t", "\n")]
        [InlineData(null, null)]
        [InlineData("", "")]
        public void Run_WhenCalled_ReturnsValidResult(string text, string expected)
        {
            var actual = RemoveConsecutiveWordDelimeters.Run(text);

            Assert.Equal(expected, actual);
        }
    }
}
