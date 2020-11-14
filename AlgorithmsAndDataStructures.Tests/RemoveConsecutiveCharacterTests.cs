using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class RemoveConsecutiveCharacterTests
    {
        [Theory]
        [InlineData("hello  world", 'l', "helo  world")]
        [InlineData("buzzzbazzzfuzzz", 'z', "buzbazfuz")]
        [InlineData(null, 'l', null)]
        [InlineData(" ", ' ', " ")]
        public void Run_WhenCalled_ReturnsValidResult(string text, char theChar, string expected)
        {
            var actual = RemoveConsecutiveCharacter.Run(text, theChar);

            Assert.Equal(expected, actual);
        }
    }
}
