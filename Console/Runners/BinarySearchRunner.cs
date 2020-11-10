﻿using AlgorithmsAndDataStructures.Algorithms;
using System;
using System.CommandLine;
using System.CommandLine.IO;
using System.Linq;

namespace Console.Runners
{
    class BinarySearchRunner
    {
        public static void Run(string needle, string[] haystack, bool verbose, IConsole console)
        {
            // Pre-execution
            // Ensure items in haystack are sorted in ascending order
            if (!BinarySearch.IsSorted(haystack))
            {
                if (verbose)
                {
                    console.Out.WriteLine($"{Environment.NewLine}Items in haystack are not sorted! Sorting...");
                }

                haystack = haystack.OrderBy(item => item).ToArray();

                if (verbose)
                {
                    console.Out.WriteLine($"Sorted haystack: {string.Join(" ", haystack)}");
                }
            }

            if (verbose)
            {
                console.Out.WriteLine($"{Environment.NewLine}Searching...");
            }

            // Execute
            int index = BinarySearch.Search(needle, haystack);

            // Display result
            if (index > -1)
            {
                console.Out.WriteLine($"{Environment.NewLine}{needle} is at position: {index + 1} in haystack");
            }
            else
            {
                console.Out.WriteLine($"{Environment.NewLine}{needle} was not found in haystack");
            }
        }
    }
}