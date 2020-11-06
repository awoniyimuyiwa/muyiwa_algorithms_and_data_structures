using AlgorithmsAndDataStructures.Algorithms;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class ReverseTextImplementationTest
    {
        [Theory]
        [InlineData("hello", "olleh")]
        [InlineData("world", "dlrow")]
        public void Reverse_WhenCalled_ReturnsValidResult(string text, string expected)
        {
            var actual = ReverseTextImplementation.Reverse(text);

            Assert.Equal(expected, actual);
        }
    }
}
