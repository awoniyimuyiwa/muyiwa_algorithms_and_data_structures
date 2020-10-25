using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    /// <summary>
    ///  Removes all consecutive occurence of characters from text
    /// </summary>
    class RemoveAllConsecutiveCharsImplementation
    {
        /// <summary>
        /// Removes all consecutive occurence of any character from the given text   
        /// </summary>
        /// <param name="text">Text to search</param>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(1) when there are no consecutives 
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        static string RemoveAllConsecutiveChars(string text)
        {
            // If text has just one character
            if (text.Length == 1) { return text; }

            // Since items might be removed while iterating, start iteration from the last character to avoid IndexOutOfBoundException
            var index = text.Length - 1;

            do 
            {
                if (text[index].Equals(text[index - 1])) 
                {
                    // new memory is allocated for current length of text - 1, 
                    // the max memory allocated at any point is n-1   
                    text = text.Remove(index, 1);
                }

                index--;
            } while(index >= 1);

            return text;
        }

        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******REMOVE ALL CONSECUTIVE CHARACTERS*******");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nGiven a text, removes all consecutive characters from the text");
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("Enter text: ");

            // Validate input
            string text = Console.ReadLine();
            if (string.IsNullOrEmpty(text))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Text must be provided");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nExecuting...");
            // Execute
            //Console.WriteLine($"text length is: {text.Length}"); 
            text = RemoveAllConsecutiveChars(text);
            //Console.WriteLine($"result length is: {text.Length}"); 

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nResult: {text}");

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\n*******END OF REMOVE ALL CONSECUTIVE CHARACTERS*******\n");
        }
    }
}
