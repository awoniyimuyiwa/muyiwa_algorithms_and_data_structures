using AlgorithmsAndDataStructures.Algorithms;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class ProjectEulerProblem54Test
    {
        [Theory]
        [InlineData("-1H 5C 6S 7S KD", "2C 3S 8S 8D TD")]
        [InlineData("1D 8C 9S ZS AC", "2C 5C 7D 8S QH")]
        public void GetWinner_WhenAnyOfTheCardsForPlayer1HasInvalidRank_ThrowsArgumentException(string hand1, string hand2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(hand1, hand2);

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5H 5C 6S 7S KD", "2C 3S 8S yD TD")]
        [InlineData("5D 8C 9S JS AC", "0C 5C 7D 8S QH")]
        public void GetWinner_WhenAnyOfTheCardsForPlayer2HasInvalidRank_ThrowsArgumentException(string hand1, string hand2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(hand1, hand2);

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5h 5C 6S 7S KD", "2C 3S 8S 8D TD")]
        public void GetWinner_WhenAnyOfTheCardsForPlayer1HasInvalidSuit_ThrowsArgumentException(string hand1, string hand2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(hand1, hand2);

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5H 5C 6S 7S KD", "2C 3S 8S 8D Td")]
        public void GetWinner_WhenAnyOfTheCardsForPlayer2HasInvalidSuit_ThrowsArgumentException(string hand1, string hand2)
        {
            Action actual = () => ProjectEulerProblem54.GetWinner(hand1, hand2);

            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void GetWinner_WhenAnyOfTheCardsForPlayer1HasLessThan2Characters_ThrowsArgumentException()
        {
            Action actual = () => ProjectEulerProblem54.GetWinner("5H 5C 6S  KD", "2D 3S 8S 8D");

            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void GetWinner_WhenAnyOfTheCardsForPlayer2HasLessThan2Characters_ThrowsArgumentException()
        {
            Action actual = () => ProjectEulerProblem54.GetWinner("5H 5C 6S 7S KD", "2 3S 8S 8D");

            Assert.Throws<ArgumentException>(actual);
        }
    
        [Fact]
        public void GetWinner_WhenAnyOfTheCardsForPlayer1HasMoreThan2Characters_ThrowsArgumentException()
        {
            Action actual = () => ProjectEulerProblem54.GetWinner("5Hd 5C 6S 7S 8D", "2C 3S 8S 8D TD");

            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void GetWinner_WhenAnyOfTheCardsForPlayer2HasMoreThan2Characters_ThrowsArgumentException()
        {
            Action actual = () => ProjectEulerProblem54.GetWinner("5H 5C 6S 7S 8D", "2C 3S 8S 8DY TD");

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData("5H 5C 6S 7S KD", "2C 3S 8S 8D TD", 2)]
        [InlineData("5D 8C 9S JS AC", "2C 5C 7D 8S QH", 1)]
        [InlineData("2D 9C AS AH AC", "3D 6D 7D TD QD", 2)]
        [InlineData("4D 6S 9H QH QC", "3D 6D 7H QD QS", 1)]
        [InlineData("2H 2D 4C 4D 4S", "3C 3D 3S 9S 9D", 1)]
        [InlineData("5D 8C 9S JS AC", "5D 8C 9S JS AC", 0)]
        public void GetWinner_WhenCardsForBothPlayersAreValid_ReturnsValidResult(string cardsForPlayer1, string cardsForPlayer2, int expected)
        {
            var actual = ProjectEulerProblem54.GetWinner(cardsForPlayer1, cardsForPlayer2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetWinner_WhenCardsForPlayer1IsLessThan5_ThrowsArgumentException()
        {
            Action actual = () => ProjectEulerProblem54.GetWinner("5H 5C 6S 7S", "2C 3S 8S 8D TD");

            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void GetWinner_WhenCardsForPlayer2IsLessThan5_ThrowsArgumentException()
        {
            Action actual = () => ProjectEulerProblem54.GetWinner("5H 5C 6S 7S KD", "2C 3S 8S 8D");

            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void GetWinner_WhenCardsForPlayer1IsMoreThan5_ThrowsArgumentException()
        {
            Action actual = () => ProjectEulerProblem54.GetWinner("5H 5C 6S 7S 8D, 9Q", "2C 3S 8S 8D TD");

            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void GetWinner_WhenCardsForPlayer2IsMoreThan5_ThrowsArgumentException()
        {
            Action actual = () => ProjectEulerProblem54.GetWinner("5H 5C 6S 7S 8D", "2C 3S 8S 8D TD, JQ");

            Assert.Throws<ArgumentException>(actual);
        }
    }
}
