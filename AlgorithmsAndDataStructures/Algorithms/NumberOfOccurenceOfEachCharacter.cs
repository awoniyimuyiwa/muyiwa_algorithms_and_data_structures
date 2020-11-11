using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class NumberOfOccurenceOfEachCharacter
    {
        /// <summary>
        /// Finds the number of times each character in <paramref name="text"/> occurs    
        /// </summary>
        /// <param name="text">Text to find the number of occurence of its characters</param>
        /// <returns>A dictionary containing characters in <paramref name="text"/> as keys and the number of times they occur as value</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="text"/> is null</exception>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n) 
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static Dictionary<char, int> Run(string text)
        {
            #region Not part of the algorithm
            if (text == null) { throw new ArgumentNullException("text cannot be null"); }
            #endregion

            var array = text.ToCharArray();
            var charToCountMap = new Dictionary<char, int>();

            foreach (char c in array)
            {
                if (charToCountMap.ContainsKey(c))
                {
                    charToCountMap[c]++;
                }
                else
                {
                    charToCountMap.Add(c, 1);
                }
            }

            return charToCountMap;
        }
    }
}
