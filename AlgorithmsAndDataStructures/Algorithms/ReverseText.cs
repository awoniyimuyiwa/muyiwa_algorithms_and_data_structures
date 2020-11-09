using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class ReverseText
    {
        /// <summary>
        /// Reverses <paramref name="text"/>  
        /// </summary>
        /// <param name="text">Text to reverse</param>
        /// <returns>The reversed text</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="text"/> is null</exception>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n) 
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static string Run(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) { return text; }

            var array = text.ToCharArray();
            Array.Reverse(array);

            return new string(array);
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******REVERSE TEXT*******");
            Console.WriteLine($"{Environment.NewLine}Enter text to reverse: ");

            string text = Console.ReadLine();
            // Validate input
            if (string.IsNullOrEmpty(text))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Text must be provided");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Environment.NewLine}Executing...");
            // Execute algorithm 
            var result = Run(text);

             // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Environment.NewLine}Result: {result}");

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}*******END OF REVERSE TEXT******{Environment.NewLine}");
        }
    }
}