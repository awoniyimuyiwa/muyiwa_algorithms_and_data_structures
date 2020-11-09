using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class RemoveConsecutiveCharacter
    {
        /// <summary>
        /// Removes consecutive occurence of <paramref name="theChar"/> from <paramref name="text"/>   
        /// <summary>
        /// <param name="text">Text to search</param>
        /// <param name="theChar">The character to remove its occurence</param>
        /// <returns>The adjusted text</returns>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(1) when there are no consecutives
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static string Run(string text, char theChar)
        {
            if (text == null || text.Length == 1) { return text; }
            
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
            Console.WriteLine($"{Environment.NewLine}Given a text and a character C, removes consecutive Cs from text");
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
            Console.WriteLine($"{Environment.NewLine}Executing...");
            // Execute
            //Console.WriteLine($"text length is: {text.Length}");
            text = Run(text, (char)theChar);
            //Console.WriteLine($"result length is: {text.Length}");

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Environment.NewLine}Result: {text}");

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}*******END OF REMOVE CONSECUTIVE CHARACTER*******{Environment.NewLine}");
        }
    }
}
