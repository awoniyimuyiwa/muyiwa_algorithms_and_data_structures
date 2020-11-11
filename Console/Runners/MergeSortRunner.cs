﻿using AlgorithmsAndDataStructures.Algorithms;
using System;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class MergeSortRunner
    {
        public static int Run(string[] items, IConsole console)
        {
            try
            {
                // Execute
                MergeSort.Sort(items);

                // Display result
                console.Out.WriteLine($"Result: {string.Join(" ", items)}");

                return 0;
            } 
            catch (ArgumentException e)
            {
                console.Error.WriteLine($"Error: {e.ParamName} must be specified");
                return 1;
            }   
        }
    }
}
