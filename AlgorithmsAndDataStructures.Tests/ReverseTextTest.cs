using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class ReverseTextTest
    {
        [Theory]
        [InlineData("hello", "olleh")]
        [InlineData("world", "dlrow")]
        [InlineData(null, null)]
        [InlineData("  ", "  ")]
        public void Run_WhenCalled_ReturnsValidResult(string text, string expected)
        {
            var actual = ReverseText.Run(text);

            Assert.Equal(expected, actual);
        }
    }
}
