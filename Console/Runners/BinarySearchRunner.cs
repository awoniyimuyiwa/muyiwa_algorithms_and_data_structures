using AlgorithmsAndDataStructures.Algorithms;
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
                    console.Out.WriteLine($"Items in haystack are not sorted! Sorting...");
                }

                haystack = haystack.OrderBy(item => item).ToArray();

                if (verbose)
                {
                    console.Out.WriteLine($"Sorted haystack: {string.Join(" ", haystack)}");
                }
            }

            if (verbose)
            {
                console.Out.WriteLine($"Searching...");
            }

            // Execute
            int index = BinarySearch.Search(needle, haystack);

            // Display result
            if (index > -1)
            {
                console.Out.WriteLine($"Result: {index + 1}");
            }
            else
            {
                console.Out.WriteLine($"{needle} was not found in haystack");
            }
        }
    }
}
