using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    /// <summary>
    /// Finds the number of words that occur in a text
    /// </summary>
    class NumberOfWordsImplementation
    {
        /// <summary>
        /// Returns the number of words in the text
        /// </summary>
        /// <param name="text">Text to search</param>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n)
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        static int NumberOfWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) { return 0; }

            // Remove leading and trailing spaces from text, this cuase new memory to be allocated 
            // if there are no trailing spaces then the size of the memory is the same as n 
            text = text.Trim();

            // If text has just one character
            if (text.Length == 1) { return 1; }

            int delimitersCount = 0;

            for (int index = 0; index < text.Length-1; index++)
            {
                // Ignore consecutive delimiters, count them as 1
                if ((text[index].Equals(' ') || text[index].Equals('\t') || text[index].Equals('\n')) &&
                !(text[index+1].Equals(' ') || text[index+1].Equals('\t') || text[index+1].Equals('\n')))
                {
                    delimitersCount++;
                }
            }
           
            // If n delimiters were counted then there are n+1 words
            return delimitersCount + 1;
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******NUMBER OF WORDS*******");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nCounts the number of words in a text");
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("Enter text: ");
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
            Console.WriteLine("\nExecuting...");
            // Execute
            var result = NumberOfWords(text);
            
            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{result} word(s)");

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\n*******END OF NUMBER OF WORDS*******\n");
        }
    }
}
