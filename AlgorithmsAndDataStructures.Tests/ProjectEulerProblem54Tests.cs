using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class ProjectEulerProblem54Tests
    {
        [Theory]
        [InlineData("-1H 5C 6S 7S KD", "2C 3S 8S 8D TD")]
        [InlineData("5D 8C 9S JS AC", "0C 5C 7D 8S QH")]
        public void GetWinner_WhenAnyCardHasInvalidRank_ThrowsArgumentException(string hand1, string hand2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(hand1.Split(" "), hand2.Split(" "));

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5h 5C 6S 7S KD", "2C 3S 8S 8D TD")]
        [InlineData("5H 5C 6S 7S KD", "2C 3S 8S 8D Td")]
        public void GetWinner_WhenAnyCardHasInvalidSuit_ThrowsArgumentException(string hand1, string hand2)
        { 
            Action actual = () => ProjectEulerProblem54.GetWinner(hand1.Split(" "), hand2.Split(" "));

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5H 5C 6S  KD", "2C 3S 8S 8D TD")]
        [InlineData("5H 5C 6S 7S 8D", "2 3S 8S 8D")]
        public void GetWinner_WhenAnyCardHasLessThan2Characters_ThrowsArgumentException(string hand1, string hand2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(hand1.Split(" "), hand2.Split(" "));

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5Hd 5C 6S 7S 8D", "2C 3S 8S 8D")]
        [InlineData("5H 5C 6S 7S 8D", "2Cd 3S 8S 8D")]
        public void GetWinner_WhenAnyCardHasMoreThan2Characters_ThrowsArgumentException(string hand1, string hand2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(hand1.Split(" "), hand2.Split(" "));

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5H 5C 6S 7S KD", "2C 3S 8S 8D TD", 2)]
        [InlineData("5D 8C 9S JS AC", "2C 5C 7D 8S QH", 1)]
        [InlineData("2D 9C AS AH AC", "3D 6D 7D TD QD", 2)]
        [InlineData("4D 6S 9H QH QC", "3D 6D 7H QD QS", 1)]
        [InlineData("2H 2D 4C 4D 4S", "3C 3D 3S 9S 9D", 1)]
        [InlineData("5D 8C 9S JS AC", "5D 8C 9S JS AC", 0)]
        // One pair
        [InlineData("5D 5C 4S 3S QC", "5D 5C 4S 3S QC", 0)]
        // Two pairs
        [InlineData("5D 5C 4S 4S QC", "5D 5C 4S 4S QC", 0)]
        // Three of a kind
        [InlineData("5D 5C 5S 4S QC", "5D 5C 5S 4S QC", 0)]
        // Straight
        [InlineData("2D 3C 4S 5S 6C", "2D 3C 4S 5S 6C", 0)]
        [InlineData("2D 3C 4S 5H QD", "2D 3C 4S 5S QD", 0)]
        // Flush
        [InlineData("5D 4D 6D 2D 7D", "5D 4D 6D 2D 7D", 0)]
        // Full house
        [InlineData("2D 2C 2S 3H 3D", "2D 2C 2S 3H 3D", 0)]
        // Four of a kind
        [InlineData("2D 2C 2S 2H 3D", "2D 2C 2S 2H 3D", 0)]
        // Straight flush
        [InlineData("2D 3D 4D 5D 6D", "2D 3D 4D 5D 6D", 0)]
        // Royal flush
        [InlineData("TD JD QD KC AC", "TD JD QD KC AC", 0)]
        public void GetWinner_WhenHand1AndHand2AreValid_ReturnsValidResult(string hand1, string hand2, int expected)
        {
            var actual = ProjectEulerProblem54.GetWinner(hand1.Split(" "), hand2.Split(" "));

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("5H 5C 6S 7S", "2C 3S 8S 8D TD")]
        [InlineData("5H 5C 6S 7S KD", "2C 3S 8S 8D")]
        public void GetWinner_WhenHand1OrHand2HasLessThan5Cards_ThrowsArgumentException(string hand1, string hand2)
        { 
            Action actual = () => ProjectEulerProblem54.GetWinner(hand1.Split(" "), hand2.Split(" "));

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5H 5C 6S 7S KD KD", "2C 3S 8S 8D TD")]
        [InlineData("5H 5C 6S 7S KD", "2C 3S 8S 8D TD TD")]
        public void GetWinner_WhenHand1OrHand2HasMoreThan5_ThrowsArgumentException(string hand1, string hand2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(hand1.Split(" "), hand2.Split(" "));

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData(null, "2C 3S 8S 8D TD")]
        [InlineData("5H 5C 6S 7S KD", null)]
        public void GetWinner_WhenHand1OrHand2IsNull_ThrowsArgumentNullException(string hand1, string hand2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(hand1?.Split(" "), hand2?.Split(" "));

            Assert.Throws<ArgumentNullException>(actual);
        }
    }
}
