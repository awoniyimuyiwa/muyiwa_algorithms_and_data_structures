using AlgorithmsAndDataStructures.Algorithms;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class QuickSortRunner
    {
        public static void Run(string[] items, IConsole console)
        {
            // Execute
            QuickSort.Sort(items);

            // Display result
            console.Out.WriteLine($"Result: {string.Join(" ", items)}");            
        }
    }
}
