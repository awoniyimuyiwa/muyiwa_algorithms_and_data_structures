namespace AlgorithmsAndDataStructures.Algorithms
{
    public class Palindrome
    {
        /// <summary>
        /// Checks if <paramref name="text"/> is a palindrome
        /// </summary>
        /// <param name="text">Text to check</param>
        /// <returns>true if <paramref name="text"/> is a palindrome, false otherwise</returns>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n) 
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static bool IsPalindrome(string text)
        {
            if (text == null) { return false; }
           
            var reversedText = ReverseText.Run(text);

            if (reversedText.Equals(text)) { return true; }

            return false;
        }
    }
}
