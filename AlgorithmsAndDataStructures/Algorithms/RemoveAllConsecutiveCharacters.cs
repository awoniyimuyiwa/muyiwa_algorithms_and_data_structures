namespace AlgorithmsAndDataStructures.Algorithms
{
    public class RemoveAllConsecutiveCharacters
    {
        /// <summary>
        /// Removes all consecutive occurence of characters from <paramref name="text"/>   
        /// </summary>
        /// <param name="text">Text to remove all consecutive occurence of characters from</param>
        /// <returns>The processed text</returns>
        /// <remarks>
        /// Where n is length of the text
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(1) when there are no consecutives 
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)
        /// </remarks>
        public static string Run(string text)
        {
            if (string.IsNullOrEmpty(text) || text.Length == 1) { return text; }

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
            } while (index >= 1);

            return text;
        }
    }
}
