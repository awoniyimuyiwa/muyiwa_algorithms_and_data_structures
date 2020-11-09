using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class ProjectEulerProblem54Test
    {
        [Theory]
        [InlineData("-1H 5C 6S 7S KD", "2C 3S 8S 8D TD")]
        [InlineData("5D 8C 9S JS AC", "0C 5C 7D 8S QH")]
        public void GetWinner_WhenAnyCardHasInvalidRank_ThrowsArgumentException(string cards1, string cards2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(cards1, cards2);

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5h 5C 6S 7S KD", "2C 3S 8S 8D TD")]
        [InlineData("5H 5C 6S 7S KD", "2C 3S 8S 8D Td")]
        public void GetWinner_WhenAnyCardHasInvalidSuit_ThrowsArgumentException(string cards1, string cards2)
        { 
            Action actual = () => ProjectEulerProblem54.GetWinner(cards1, cards2);

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5H 5C 6S  KD", "2C 3S 8S 8D TD")]
        [InlineData("5H 5C 6S 7S 8D", "2 3S 8S 8D")]
        public void GetWinner_WhenAnyCardHasLessThan2Characters_ThrowsArgumentException(string cards1, string cards2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(cards1, cards2);

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5Hd 5C 6S 7S 8D", "2C 3S 8S 8D")]
        [InlineData("5H 5C 6S 7S 8D", "2Cd 3S 8S 8D")]
        public void GetWinner_WhenAnyCardHasMoreThan2Characters_ThrowsArgumentException(string cards1, string cards2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(cards1, cards2);

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5H 5C 6S 7S KD", "2C 3S 8S 8D TD", 2)]
        [InlineData("5D 8C 9S JS AC", "2C 5C 7D 8S QH", 1)]
        [InlineData("2D 9C AS AH AC", "3D 6D 7D TD QD", 2)]
        [InlineData("4D 6S 9H QH QC", "3D 6D 7H QD QS", 1)]
        [InlineData("2H 2D 4C 4D 4S", "3C 3D 3S 9S 9D", 1)]
        [InlineData("5D 8C 9S JS AC", "5D 8C 9S JS AC", 0)]
        public void GetWinner_WhenCards1AndCards2AreValid_ReturnsValidResult(string cards1, string cards2, int expected)
        {
            var actual = ProjectEulerProblem54.GetWinner(cards1, cards2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("5H 5C 6S 7S", "2C 3S 8S 8D TD")]
        [InlineData("5H 5C 6S 7S KD", "2C 3S 8S 8D")]
        public void GetWinner_WhenCards1OrCards2IsLessThan5_ThrowsArgumentException(string cards1, string cards2)
        { 
            Action actual = () => ProjectEulerProblem54.GetWinner(cards1, cards2);

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5H 5C 6S 7S KD KD", "2C 3S 8S 8D TD")]
        [InlineData("5H 5C 6S 7S KD", "2C 3S 8S 8D TD TD")]
        public void GetWinner_WhenCards1OrCards2IsMoreThan5_ThrowsArgumentException(string cards1, string cards2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(cards1, cards2);

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData(null, "2C 3S 8S 8D TD")]
        [InlineData("5H 5C 6S 7S KD", null)]
        public void GetWinner_WhenCards1OrCards2IsNull_ThrowsArgumentNullException(string cards1, string cards2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(cards1, cards2);

            Assert.Throws<ArgumentNullException>(actual);
        }
    }
}
