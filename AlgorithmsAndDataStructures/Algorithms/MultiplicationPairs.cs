using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class MultiplicationPairs
    {
        /// <summary>
        /// Given a list of <paramref name="numbers"/>, and a number <paramref name="X"/>,
        /// find pairs of numbers within <paramref name="numbers"/> can be multiplied to get <paramref name="X"/>
        /// </summary>
        /// <param name="numbers">List of numbers to search</param>
        /// <param name="X">Multiplication result</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="numbers"/> is null</exception>
        /// <remarks>
        /// Where n is the size of the list
        /// BEST CASE- TIME: Ω(n^2), MEMORY: Ω(1)
        /// AVERAGE CASE- TIME: Θ(n^2), MEMORY: Θ(1)
        /// WORST CASE- TIME: O(n^2), MEMORY: O(1)
        /// </remarks>
        public static List<Tuple<int, int>> GetPairs(List<int> numbers, int X)
        {
            #region Not part of the algorithm
            if (numbers == null) { throw new ArgumentNullException("numbers cannot be null"); }
            #endregion

            numbers = numbers.Distinct().ToList();
            var numbersCount = numbers.Count();
            var tuples = new List<Tuple<int, int>>();
            int quotient = 0;
            int remainder = 0;

            for (int index = 0; index < numbersCount; index++)
            {
                // Avoid division by zero exception
                if (numbers[index] != 0)
                {
                    quotient = X / numbers[index];
                    remainder = X % numbers[index];
                }

                for (int index2 = index + 1; index2 < numbersCount; index2++)
                {
                    if (numbers[index] == 0 && X == 0)
                    {
                        tuples.Add(Tuple.Create(numbers[index], numbers[index2]));
                    }
                    else if (numbers[index2] == quotient && remainder == 0)
                    {
                        tuples.Add(Tuple.Create(numbers[index], numbers[index2]));
                        break;
                    }
                }
            }

            return tuples;
        }
    }
}
