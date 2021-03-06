﻿using System;
using AlgorithmsAndDataStructures.Algorithms;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class QuickSortRunner
    {
        public static int Run(string[] items, IConsole console)
        {
            try
            {
                // Execute
                QuickSort.Sort(items);

                // Display result
                console.Out.WriteLine($"Result: { string.Join(" ", items) }");

                return 0;
            }
            catch (ArgumentException)
            {
                console.Error.WriteLine($"Error: { nameof(items) } must be specified");
                return 1;
            }           
        }
    }
}
