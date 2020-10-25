using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    class RemoveConsecutiveWordDelimetersImplementation
    {
        /// <summary>
        /// Removes consecutive word delimeters from a given text
        /// </summary>
        /// <param name="text">Text to search</param>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(1) when there are no consecutive word delimeters
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static string RemoveConsecutiveWordDelimeters(string text)
        { 
            // If text has just one character
            if (text.Length == 1) { return text; }

            // Since items might be removed while iterating, start iteration from the last character to avoid IndexOutOfBoundException
            var index = text.Length - 1;

            do
            {
                if ((text[index].Equals(' ') || text[index].Equals('\t') || text[index].Equals('\n')) &&
                ((text[index - 1].Equals(' ') || text[index - 1].Equals('\t') || text[index - 1].Equals('\n'))))
                {
                    // New memory is allocated for current length of text - 1
                    // the max memory allocated at any point is n-1   
                    text = text.Remove(index, 1);
                }

                index--;
            } while (index >= 1);

            return text;
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******REMOVE CONSECUTIVE WORD DELIMETERS*******");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nGiven a text, removes all consecutive space, tab and newline characters from the text");
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("Enter text: ");
            string text = Console.ReadLine();

            // Validate input
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Text must contain at least one non-whitespace character");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nExecuting...");
            //Console.WriteLine($"text length is: {text.Length}"); 
            // Execute
            text = RemoveConsecutiveWordDelimeters(text);
            //Console.WriteLine($"result length is: {text.Length}"); 

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nResult: {text}");

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\n*******END OF REMOVE CONSECUTIVE WORD DELIMETERS*******\n");
        }
    }
}