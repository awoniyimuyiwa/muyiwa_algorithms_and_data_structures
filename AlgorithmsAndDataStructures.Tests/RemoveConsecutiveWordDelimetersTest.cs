using AlgorithmsAndDataStructures.Algorithms;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class RemoveConsecutiveWordDelimetersTest
    {
        [Theory]
        [MemberData(nameof(GetTheoryData))]
        public void Execute_WhenCalled_ReturnsValidResult(string text, string expected)
        {
            var actual = RemoveConsecutiveWordDelimeters.Execute(text);

            Assert.Equal(expected, actual);
        }

        public static TheoryData<string, string> GetTheoryData()
        {
            // Note that the RemoveConsecutiveWordDelimeters.Execute works by starting iteration from the last character in the text, 
            // it removes a character if it is a word delimeter (any of ' ', '\t', '\n') and the next character in the iteration is also a word delimeter 
            return new TheoryData<string, string>()
            {
                {
                    "hello\n\t\t\n  world\t  ",
                    "hello\nworld\t"
                },

                {
                   "\t\t\t\n  \t\n\n hello \t\t world\n\n\n\t\n",
                   "\thello world\n"
                }
            };
        }
    }
}
