using System.Text.RegularExpressions;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class NumberOfOccurence
    {
        /// <summary>
        /// Finds the number of times <paramref name="pattern"/> occurs in <paramref name="text"/>
        /// </summary>
        /// <param name="pattern">Pattern to check in text</param>
        /// <param name="text">Text to search</param>
        /// <returns>Number of times <paramref name="pattern"/> occurs in <paramref name="text"/></returns>        
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n) 
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static int Run(string pattern, string text)
        {
            if (text == null && pattern == null) { return 1;  }
            if (text == null && pattern != null) { return 0; }
            if (text != null && pattern == null) { return 0; }
            
            if (text == "" && pattern == "") { return 1; }
            if (text == "" && pattern != "") { return 0; }
            if (text != "" && pattern == "") { return 0; }

            var patternLength = pattern.Length;
            var count = 0;

            int index;
            while ((index = text.IndexOf(pattern)) > -1)
            {
                count++;
                text = text.Remove(index, patternLength);
            };

            return count;
        }

        /// <summary>
        /// Finds the number of times <paramref name="pattern"/> occurs in <paramref name="text"/> using regular expression   
        /// </summary>
        /// <param name="pattern">Pattern to check in text</param>
        /// <param name="text">Text to search</param>
        /// <returns>Number of times <paramref name="pattern"/> occurs in <paramref name="text"/></returns>
        public static int RunUsingRegex(string pattern, string text)
        {
            if (string.IsNullOrEmpty(text) && string.IsNullOrEmpty(pattern)) { return 1; }
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern)) { return 0; }

            Regex regex = new Regex(pattern);

            return regex.Matches(text).Count;
        }     
    }
}
