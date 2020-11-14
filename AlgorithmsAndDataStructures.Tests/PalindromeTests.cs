using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class PalindromeTests
    {
        [Theory]
        [InlineData("51515", true)]
        [InlineData("hello world", false)]
        [InlineData(null, false)]
        [InlineData("  ", true)]
        public void IsPalindrome_WhenCalled_ReturnsValidResult(string text, bool expected)
        {
            var actual = Palindrome.IsPalindrome(text);

            Assert.Equal(expected, actual);
        }
    }
}
