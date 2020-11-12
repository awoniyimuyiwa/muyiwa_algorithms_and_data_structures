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
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n) 
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static string Run(string text)
        {
            if (string.IsNullOrEmpty(text)) { return text; }

            var array = text.ToCharArray();
            Array.Reverse(array);

            return new string(array);
        }
    }
}
