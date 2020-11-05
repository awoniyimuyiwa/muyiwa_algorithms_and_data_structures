using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    /// <summary>
    ///  Removes consecutive occurence of a given character from a given text
    /// </summary>
    class RemoveConsecutiveCharImplementation
    {
        /// <summary>
        /// Removes consecutive occurence of the given character from the given text   
        /// <summary>
        /// <param name="text">Text to search</param>
        /// <param name="text">The character to remove its occurence</param>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(1) when there are no consecutives
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static string RemoveConsecutiveChar(string text, char theChar)
        { 
            // If text has just one character
            if (text.Length == 1) { return text; }

            // Since items might be removed while iterating, start iteration from the last character to avoid IndexOutOfBoundException
            var index = text.Length - 1;

            do 
            {
                if (text[index].Equals(theChar) && text[index - 1].Equals(theChar)) 
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
            
            Console.WriteLine("*******REMOVE CONSECUTIVE CHARACTER*******");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nGiven a text and a character C, removes consecutive Cs from text");
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

            Console.WriteLine("Enter character e.g a: ");
            int theChar = Console.Read();
            if (theChar == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: A character must be provided");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nExecuting...");
            // Execute
            //Console.WriteLine($"text length is: {text.Length}");
            text = RemoveConsecutiveChar(text, (char)theChar);
            //Console.WriteLine($"result length is: {text.Length}");

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nResult: {text}");

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\n*******END OF REMOVE CONSECUTIVE CHARACTER*******\n");
        }
    }
}
