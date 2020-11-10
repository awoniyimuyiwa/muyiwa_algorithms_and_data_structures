using AlgorithmsAndDataStructures.Algorithms;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class MergeSortRunner
    {
        public static void Run(string[] items, IConsole console)
        {
            // Execute
            MergeSort.Sort(items);

            // Display result
            console.Out.WriteLine($"Result: {string.Join(" ", items)}");            
        }
    }
}
