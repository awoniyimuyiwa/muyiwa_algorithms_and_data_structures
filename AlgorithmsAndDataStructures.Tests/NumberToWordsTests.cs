using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class NumberToWordsTests
    {
        [Theory]
        [InlineData(-1, "minus one")]
        [InlineData(0, "zero")]
        [InlineData(10, "ten")]
        [InlineData(11, "eleven")]
        [InlineData(12, "twelve")]
        [InlineData(13, "thirteen")]
        [InlineData(14, "fourteen")]
        [InlineData(15, "fifteen")]
        [InlineData(16, "sixteen")]
        [InlineData(17, "seventeen")]
        [InlineData(18, "eighteen")]
        [InlineData(19, "nineteen")]
        [InlineData(20, "twenty")]
        [InlineData(21, "twenty one")]
        [InlineData(22, "twenty two")]
        [InlineData(30, "thirty")]
        [InlineData(33, "thirty three")]
        [InlineData(40, "fourty")]
        [InlineData(44, "fourty four")]
        [InlineData(50, "fifty")]
        [InlineData(55, "fifty five")]
        [InlineData(60, "sixty")]
        [InlineData(66, "sixty six")]
        [InlineData(70, "seventy")]
        [InlineData(77, "seventy seven")]
        [InlineData(80, "eighty")]
        [InlineData(88, "eighty eight")]
        [InlineData(90, "ninety")]
        [InlineData(99, "ninety nine")]
        [InlineData(100, "one hundred")]
        [InlineData(555, "five hundred fifty five")]
        [InlineData(666, "six hundred sixty six")]
        [InlineData(777, "seven hundred seventy seven")]
        [InlineData(888, "eight hundred eighty eight")]
        [InlineData(1000, "one thousand")]
        [InlineData(111111, "one hundred eleven thousand one hundred eleven")]
        [InlineData(1000000, "one million")]
        [InlineData(222222222, "two hundred twenty two million two hundred twenty two thousand two hundred twenty two")]
        [InlineData(1000000000, "one billion")]
        [InlineData(333333333333, "three hundred thirty three billion three hundred thirty three million three hundred thirty three thousand three hundred thirty three")]
        [InlineData(1000000000000, "one trillion")]
        [InlineData(444444444444444, "four hundred fourty four trillion four hundred fourty four billion four hundred fourty four million four hundred fourty four thousand four hundred fourty four")]
        [InlineData(1000000000000000, "one quadrillion")]
        [InlineData(555555555555555555, "five hundred fifty five quadrillion five hundred fifty five trillion five hundred fifty five billion five hundred fifty five million five hundred fifty five thousand five hundred fifty five")]
        [InlineData(1000000000000000000, "one quintillion")]
        [InlineData(9999999999999999999, "nine quintillion nine hundred ninety nine quadrillion nine hundred ninety nine trillion nine hundred ninety nine billion nine hundred ninety nine million nine hundred ninety nine thousand nine hundred ninety nine")]
        public void Run_WhenCalledWithNumberNotOutOfRange_ReturnsValidResult(decimal number, string expected)
        {
            var actual = NumberToWords.Run(number);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(9999999999999999999.1)]
        public void Run_WhenCalledWithNumberOutOfRange_ThrowsArgumentOutOfRangeException(decimal number)
        {
            Action actual = () => NumberToWords.Run(number);

            Assert.Throws<ArgumentOutOfRangeException>(actual);
        }
    }
}
