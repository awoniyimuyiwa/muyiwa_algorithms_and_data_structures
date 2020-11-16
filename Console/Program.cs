using Console.Extensions;
using Console.Runners;
using System.Collections.Generic;
using System.CommandLine;

namespace Console
{
    public class Program
    {
        static int Main(string[] args)
        {
            // No logic should be here
            return Run(args);
        }

        /// <summary>
        /// Support for unit tests
        /// </summary>
        /// <param name="args"></param>
        /// <param name="console"></param>
        /// <returns></returns>
        public static int Run(string[] args, IConsole console = null)
        {
            var algoCommand = new RootCommand("Runs an algorithm")
            {
                new Command("addition-pairs", "Given a list of numbers and another number x, finds all pairs of numbers within the list that can be added to get x")
                {
                    new Option<List<int>>(new[] { "--numbers", "-n" }, "List from which addition pairs will be retrieved")
                    {
                        IsRequired = true
                    },
                    new Option<int>(new[] { "--x", "-x" }, "Number whose addition pairs are to be retrieved")
                    {
                        IsRequired = true
                    },
                }.WithHandler(typeof(AdditionPairsRunner).GetMethod(nameof(AdditionPairsRunner.Run))),

                new Command("binary-search", "Given a needle, and an haystack, finds the position of needle in haystack using binary search algorithm")
                {
                    new Option<string>(new[] { "--needle", "-n" }, "Item to search for")
                    {
                        IsRequired = true
                    },
                    new Option<string[]>(new[] { "--haystack", "-hs" }, "List in which to search")
                    {
                        IsRequired = true
                    },
                    new Option<bool>(new[] { "--verbose", "-v" }, getDefaultValue: () => false, "Show execution details"),
                }.WithHandler(typeof(BinarySearchRunner).GetMethod(nameof(BinarySearchRunner.Run))),

                new Command("bst-traverse", "Binary search tree traverse. Given a list of items, stores them in a binary search tree and prints out the result of traversing the tree using different traversal algorithms")
                {
                    new Argument<string[]>("items", "Items to store in the binary search tree") {}
                }.WithHandler(typeof(BinarySearchTreeTraverseRunner).GetMethod(nameof(BinarySearchTreeTraverseRunner.Run))),

                new Command("fib", "Fibonacci. Finds the number at posititon n in the fibonacci sequence")
                {
                    new Argument<int>("n", "Position in the fibonacci sequence. Must not be less than 0") {}
                }.WithHandler(typeof(NthFibonacciRunner).GetMethod(nameof(NthFibonacciRunner.Run))),

                new Command("fib-seq", "Fibonacci sequence. Finds all numbers in the fibonacci sequence within a given range")
                {
                    new Option<int>(new[] { "--from", "-f" }, getDefaultValue: () => 0, "Position in the fibonacci sequence to start from. Must not be less than 0") {},
                    new Option<int>(new[] { "--to", "-t" }, "Position in the fibonacci sequence to end at. Must not be less than 0")
                    {
                        IsRequired = true
                    }
                }.WithHandler(typeof(FibonacciSequenceRunner).GetMethod(nameof(FibonacciSequenceRunner.Run))),

                new Command("is-palindrome", "Is palindrome. Checks if the reverse of a text is the same as the text")
                {
                    new Argument<string>("text", "Text to check") {}
                }.WithHandler(typeof(PalindromeRunner).GetMethod(nameof(PalindromeRunner.Run))),

                new Command("merge-sort", "Given a list of items, sorts them using merge-sort algorithm")
                {
                    new Argument<string[]>("items", "Items to sort")
                }.WithHandler(typeof(MergeSortRunner).GetMethod(nameof(MergeSortRunner.Run))),

                new Command("multip-pairs", "Multiplication pairs. Given a list of numbers and another number x, finds all pairs of numbers within the list that can be multiplied to get x")
                {
                    new Option<List<int>>(new[] { "--numbers", "-n" }, "List from which multiplication pairs will be retrieved")
                    {
                        IsRequired = true
                    },
                    new Option<int>(new[] { "--x", "-x" }, "Number whose multiplication pairs are to be retrieved")
                    {
                        IsRequired = true
                    },
                }.WithHandler(typeof(MultiplicationPairsRunner).GetMethod(nameof(MultiplicationPairsRunner.Run))),

                new Command("num-occur", "Number of occurence. Given a text and a specific pattern (character or text), finds the number of times pattern occurs in text")
                {
                    new Option<string>(new[] { "--text", "-t" }, "Text from which to retrieve the number of coccurence of pattern")
                    {
                        IsRequired = true
                    },
                    new Option<string>(new[] { "--pattern", "-p" }, "Pattern to search for")
                    {
                        IsRequired = true
                    }
                }.WithHandler(typeof(NumberOfOccurenceRunner).GetMethod(nameof(NumberOfOccurenceRunner.Run))),

                new Command("num-occur-each-char", "Number of occurence of each character. Finds the number of times each character in a text occurs")
                {
                    new Argument<string>("text", "Text to retrieve the number of coccurence of its characters")
                }.WithHandler(typeof(NumberOfOccurenceOfEachCharacterRunner).GetMethod(nameof(NumberOfOccurenceOfEachCharacterRunner.Run))),

                new Command("num-words", "Finds the number of words in a text")
                {
                    new Argument<string>("text", "Text to find its number of words") {}
                }.WithHandler(typeof(NumberOfWordsRunner).GetMethod(nameof(NumberOfWordsRunner.Run))),

                new Command("num-to-words", "Converts a number to words")
                {
                    new Argument<decimal>("number", "Number to convert to words") {}
                }.WithHandler(typeof(NumberToWordsRunner).GetMethod(nameof(NumberToWordsRunner.Run))),

                new Command(
                    "proj-euler-prob-54", 
                    "Project euler problem 54. Given 5 cards each for two players in a game of poker, determines which of the two players is the winner. " +
                    "A card is represented by 2 characters, the first character is the card's rank and the second is the card's suit. " +
                    "Valid ranks are: 2, 3, 4, 5, 6, 7, 8, 9, T, J, Q, K and A (where T is Ten, J is Jack, Q is Queen, K is King, and A is Ace). " +
                    "Valid suits are: C, D, H and S (where C is Club, D is Diamond, H is Heart and S is Spade). " +
                    "More info here: https://projecteuler.net/problem=54")
                {
                    new Option<string[]>(new[] { "--hand1", "-h1" }, "The 5 cards for player 1 e.g 2S 3D 4H 9C QH")
                    {
                        IsRequired = true
                    },

                    new Option<string[]>(new[] { "--hand2", "-h2" }, "The 5 cards for player 2 e.g 2S 3D 4H 9C QH")
                    {
                        IsRequired = true
                    },
                }.WithHandler(typeof(ProjectEulerProblem54Runner).GetMethod(nameof(ProjectEulerProblem54Runner.Run))),

                new Command("quick-sort", "Given a list of items, sorts them using quick-sort algorithm")
                {
                    new Argument<string[]>("items", "Items to sort")
                   
                }.WithHandler(typeof(QuickSortRunner).GetMethod(nameof(QuickSortRunner.Run))),

                new Command("rem-all-cons-char", "Removes all consecutive characters from a text")
                {
                    new Argument<string>("text", "Text to remove all consecutive characters from")
                }.WithHandler(typeof(RemoveAllConsecutiveCharactersRunner).GetMethod(nameof(RemoveAllConsecutiveCharactersRunner.Run))),

                new Command("rem-cons-char", "Removes consecutive occurence of a specific character from text")
                {
                    new Option<string>(new[] { "--text", "-t" }, "Text to remove consecutive occurence of character from")
                    {
                        IsRequired = true
                    },
                    new Option<char>(new[] { "--character", "-c" }, "Character to remove its consecutive occurence")
                    {
                        IsRequired = true
                    }
                }.WithHandler(typeof(RemoveConsecutiveCharacterRunner).GetMethod(nameof(RemoveConsecutiveCharacterRunner.Run))),

                new Command("rem-cons-word-dels", "Removes consecutive word delimeters (' ', '\\t', '\\n') from text")
                {
                    new Argument<string>("text", "Text to remove consecutive word delimeters from")
                }.WithHandler(typeof(RemoveConsecutiveWordDelimetersRunner).GetMethod(nameof(RemoveConsecutiveWordDelimetersRunner.Run))),

                new Command("reverse", "Reverses a text")
                {
                    new Argument<string>("text", "Text to reverse") {}
                }.WithHandler(typeof(ReverseTextRunner).GetMethod(nameof(ReverseTextRunner.Run))),

                new Command("weather-to-json", "Creates and outputs a weather forecast object as json")
                {
                    new Option<double>(new[] { "--temp", "-t" }, "Temperature in celsius")
                    {
                        IsRequired = true
                    },
                    new Option<string>(new[] { "--summary", "-s" }, "Friendly text that describes the weather")
                    {
                        IsRequired = true
                    }
                }.WithHandler(typeof(SerializeToJsonRunner).GetMethod(nameof(SerializeToJsonRunner.Run))),
            };

            algoCommand.Name = "algo";
            return algoCommand.Invoke(args, console);
        }
    }
}
