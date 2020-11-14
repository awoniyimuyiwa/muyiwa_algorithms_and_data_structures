using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class RemoveAllConsecutiveCharactersTests
    {
        [Theory]
        [InlineData("hello  world", "helo world")]
        [InlineData("bbubzzzbabbbbbzzzfffufzz", "bubzbabzfufz")]
        [InlineData(null, null)]
        [InlineData("    ", " ")]
        [InlineData(" ", " ")]
        public void Run_WhenCalled_ReturnsValidResult(string text, string expected)
        {
            var actual = RemoveAllConsecutiveCharacters.Run(text);

            Assert.Equal(expected, actual);
        }
    }
}
