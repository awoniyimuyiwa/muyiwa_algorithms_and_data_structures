using AlgorithmsAndDataStructures.Algorithms;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.IO;
using System.Linq;

namespace Console.Runners
{
    class MultiplicationPairsRunner
    {
        public static void Run(List<int> numbers, int x, IConsole console)
        {
            var tuples = MultiplicationPairs.GetPairs(numbers, x);
            if (tuples.Count() > 0)
            {
                console.Out.WriteLine($"Pairs of numbers that can be multiplied to get { x }:");
                foreach (Tuple<int, int> tuple in tuples)
                {
                    console.Out.WriteLine($"{ tuple.Item1 }, { tuple.Item2 }");
                }
            }
            else
            {
                console.Out.WriteLine($"No multiplication pairs found for { x }");
            }
        }
    }
}
