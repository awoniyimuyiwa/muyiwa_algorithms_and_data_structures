using AlgorithmsAndDataStructures.Algorithms;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class SerializeToJsonRunner
    {
        public static void Run(double temp, string summary, IConsole console)
        {
            // Execute
            var result = SerializeToJson.Run(temp, summary);

            // Display result
            console.Out.WriteLine($"{ result }");
        }
    }
}
