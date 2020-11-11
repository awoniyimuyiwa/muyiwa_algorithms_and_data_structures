using AlgorithmsAndDataStructures.Algorithms;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class FibonacciSequenceRunner
    {
        public static int Run(int from, int to, IConsole console)
        {
            if (from < 0 || to < 0) 
            { 
                console.Error.WriteLine("Error: from and to must be at least 0");
                return 1;
            }

            // Display result
            console.Out.Write($"Result: ");
            int result;

            if (from < to)
            {
                while (from <= to)
                {
                    // Execute
                    result = NthFibonacci.FibonacciIterative(from);

                    // Display result
                    console.Out.Write($"{result} ");

                    from++;        
                }
            } 
            else
            {
                while (from >= to)
                {
                    result = NthFibonacci.FibonacciIterative(from);
                    console.Out.Write($"{result} ");

                    from--;
                }
            }

            console.Out.WriteLine();

            return 0;
        }
    }
}
