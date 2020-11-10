using AlgorithmsAndDataStructures.Algorithms;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.IO;
using System.Linq;

namespace Console.Runners
{
    class AdditionPairsRunner
    {
        public static void Run(List<int> numbers, int x, IConsole console)
        {           
            var tuples = AdditionPairs.GetPairs(numbers, x);
            if (tuples.Count() > 0)
            {
                console.Out.WriteLine($"{Environment.NewLine}Pairs of numbers that can be added to get {x}:");
                foreach (Tuple<int, int> tuple in tuples)
                {
                    console.Out.WriteLine($"{tuple.Item1}, {tuple.Item2}");
                }
            }
            else
            {
                console.Out.WriteLine($"{Environment.NewLine}None of the numbers can be added to get {x}");
            }
        }
    }
}
