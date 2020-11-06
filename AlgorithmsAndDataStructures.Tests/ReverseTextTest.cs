using AlgorithmsAndDataStructures.Algorithms;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class ReverseTextTest
    {
        [Theory]
        [InlineData("hello", "olleh")]
        [InlineData("world", "dlrow")]
        public void Reverse_WhenCalled_ReturnsValidResult(string text, string expected)
        {
            var actual = ReverseText.Reverse(text);

            Assert.Equal(expected, actual);
        }
    }
}
