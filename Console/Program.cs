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
                new Command("addition-pairs", "Given a list of numbers and another number x, finds and prints all pairs of numbers within the list that can be added to get x")
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

                new Command("binary-search-tree-traversal", "Given a list of items, stores them in a binary search tree and prints out the result of traversing the tree using different traversal algorithms")
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

                new Command("multiplication-pairs", "Given a list of numbers and another number x, finds and prints all pairs of numbers within the list that can be multiplied to get x")
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
