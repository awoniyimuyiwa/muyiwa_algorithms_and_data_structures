using AlgorithmsAndDataStructures.Algorithms;
using System;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class NthFibonacciRunner
    {
        public static int Run(int n, IConsole console)
        {
            try
            {
                // Execute
                var result = NthFibonacci.Fibonacci(n);

                // Display result
                console.Out.WriteLine($"Result: {result}");

                return 0;
            } 
            catch (ArgumentException)
            {
                console.Error.WriteLine($"Error: n must not be less than zero");
                return 1;
            }
        }
    }
}
