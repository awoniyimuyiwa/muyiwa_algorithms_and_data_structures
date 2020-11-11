using AlgorithmsAndDataStructures.Algorithms;
using System;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class ProjectEulerProblem54Runner
    {
        public static int Run(string[] hand1, string[] hand2, IConsole console)
        {
            try
            {
                // Execute
                var winner = ProjectEulerProblem54.GetWinner(hand1, hand2);

                // Display result
                if (winner == 0) { console.Out.WriteLine($"TIE. No Winner!"); }
                else if (winner == 1) { console.Out.WriteLine($"Player 1 wins!"); }
                else if (winner == 2) { console.Out.WriteLine($"Player 2 wins!"); }
                
                return 0;
            }
            catch (ArgumentException e)
            {
                console.Error.WriteLine(e.Message);
                return 1;
            }        
        }
    }
}
