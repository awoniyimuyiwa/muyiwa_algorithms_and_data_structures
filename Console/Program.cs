using Console.Extensions;
using Console.Runners;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;

namespace Console
{
    class Program
    {
        public static int Main(string[] args)
        {
            var runCommand = new RootCommand("Runs an algorithm")
            {
                new Command("addition-pairs", "Given a list of numbers and another number x, finds all pairs of numbers within the list that can be added to get x")
                {
                    new Option<List<int>>(new[] { "--numbers", "-n" }, "List from which addition pairs will be retrieved")
                    {
                        IsRequired = true
                    },
                    new Option<int>(new[] { "--x" }, "Number whose addition pairs are to be retrieved")
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

                new Command("bst-traversal", "Binary search tree traversal. Given a list of items, stores them in a binary search tree and prints out the result of traversing the tree using different traversal algorithms")
                {
                    new Option<string[]>(new[] { "--items", "-i" }, "Items to store in the binary search tree")
                    {
                        IsRequired = true
                    },
                }.WithHandler(typeof(BinarySearchTreeTraversalRunner).GetMethod(nameof(BinarySearchTreeTraversalRunner.Run))),

                new Command("merge-sort", "Given a list of items, sorts them using merge-sort algorithm")
                {
                    new Option<string[]>(new[] { "--items", "-i" }, "Items to sort")
                    {
                        IsRequired = true
                    },
                }.WithHandler(typeof(MergeSortRunner).GetMethod(nameof(MergeSortRunner.Run))),

                new Command("multiplication-pairs", "Given a list of numbers and another number x, finds all pairs of numbers within the list that can be multiplied to get x")
                {
                    new Option<List<int>>(new[] { "--numbers", "-n" }, "List from which multiplication pairs will be retrieved")
                    {
                        IsRequired = true
                    },
                    new Option<int>(new[] { "--x" }, "Number whose multiplication pairs are to be retrieved")
                    {
                        IsRequired = true
                    },
                }.WithHandler(typeof(MultiplicationPairsRunner).GetMethod(nameof(MultiplicationPairsRunner.Run))),

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
                    new Option<string[]>(new[] { "--items", "-i" }, "Items to sort")
                    {
                        IsRequired = true
                    },
                }.WithHandler(typeof(QuickSortRunner).GetMethod(nameof(QuickSortRunner.Run))),
            };

            runCommand.Name = "run";

            return runCommand.Invoke(args);
        }
    }
}
