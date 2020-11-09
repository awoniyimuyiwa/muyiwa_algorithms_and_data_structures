using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class NthFibonacciTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        public void Fibonacci_WhenNGreaterThanZero_ReturnsValidResult(int n, int expected)
        {
            var actual = NthFibonacci.Fibonacci(n);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        public void FibonacciIterative_WhenNGreaterThanZero_ReturnsValidResult(int n, int expected)
        {
            var actual = NthFibonacci.FibonacciIterative(n);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Fibonacci_WhenNLessThanZero_ThrowsArgumentException()
        {
            Action actual = () => NthFibonacci.Fibonacci(-1);

            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void FibonacciIterative_WhenNLessThanZero_ThrowsArgumentException()
        {
            Action actual = () => NthFibonacci.FibonacciIterative(-1);

            Assert.Throws<ArgumentException>(actual);
        }
    }
}
