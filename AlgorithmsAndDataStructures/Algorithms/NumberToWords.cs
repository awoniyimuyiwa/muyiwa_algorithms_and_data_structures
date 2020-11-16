using System;
using System.Text;

namespace AlgorithmsAndDataStructures.Algorithms
{
    public class NumberToWords
    {
        /// <summary>
        /// Converts a decimal number to words. 
        /// </summary>
        /// <param name="number">Number to convert. 
        /// should not exceed 9999999999999999999.999999999 which is:
        /// Nine quintillion nine hundred ninety nine quadrillion nine hundred ninety nine trillion nine hundred ninety nine billion nine hundred ninety nine million nine hundred ninety nine thousand nine hundred ninety nine point one hundred
        /// </param>
        /// <returns>Words representing <paramref name="number"/></returns>
        public static string Run(decimal number)
        {
            var words = new StringBuilder();
            ulong wholeNumber;
            decimal fraction;
            ulong fractionAsWholeNumber;

            if (number < 0)
            {
                words.Append("minus ");
                // Convert number to positive
                number *= -1;
            }
             
            wholeNumber = decimal.ToUInt64(number);
            fraction = number - wholeNumber;
            fractionAsWholeNumber = decimal.ToUInt64(Math.Round(fraction * 100));
            
            words.Append(Convert(wholeNumber));
            if (fractionAsWholeNumber > 0)
            {
                words.Append(" point ");
                words.Append(Convert(fractionAsWholeNumber));               
            } 
            
            return words.ToString();
        }

        static readonly string[] units = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        static readonly string[] tens = new string[]
        {    
            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen",    
            "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety"
        };

        /// <summary>
        /// </summary>
        /// <param name="number">
        /// A ulong has 64 bits and can only hold 19 digits. 
        /// As a result of the ulong data type restriction on number, 
        /// an overflow exception will be thrown by the runtime 
        /// when this method is invoked with a number that has more than 19 digits
        /// </param>
        /// <returns></returns>
        static string Convert(ulong number)
        {
            ulong quotient;
            ulong remainder;
            var words = new StringBuilder();
           
            if (number < 10)
            {
                words.Append(units[number]);
            }
            else if (number < 100)
            {
                // number is less than a hundred(2 zeros, 3 digits), that means number is in tens range
                if (number < 20)
                {
                    // 10 is substracted from number to get the right index in tens array,
                    // ten is at index 0, 11 at index 1 and so on
                    words.Append(tens[number - 10]);
                }
                else
                {
                    quotient = number / 10;
                    remainder = number % 10;
                    // 8 is added to quotient to get the right index in tens array, 
                    // twenty at index 10, thirty at index 11 and so on
                    words.Append(tens[quotient + 8]);
                    if (remainder > 0) 
                    {
                        words.Append(" ");
                        words.Append(Convert(remainder));
                    }
                }
            }
            else if (number < 1000)
            {
                // number is less than a thousand(3 zeros, 4-6 digits), that means number is in hundreds range
                quotient = number / 100;
                remainder = number % 100;
                words.Append(Convert(quotient));
                words.Append(" hundred");
                if (remainder > 0)
                {
                    //words.Append(" and ");
                    words.Append(" ");
                    words.Append(Convert(remainder));
                }
            }
            else if (number < 1000000)
            {
                // number is less than a million(6 zeros, 7-9 digits), that means number is in thousands range
                quotient = number / 1000;
                remainder = number % 1000;
                words.Append(Convert(quotient));
                words.Append(" thousand");
                if (remainder > 0) 
                {
                    words.Append(" ");
                    words.Append(Convert(remainder)); 
                }
            }
            else if (number < 1000000000)
            {
                // number is less than a billion(9 zeros, 10-12 digits), that means number is in millions range
                quotient = number / 1000000;
                remainder = number % 1000000;
                words.Append(Convert(quotient));
                words.Append(" million");
                if (remainder > 0) 
                {
                    words.Append(" ");
                    words.Append(Convert(remainder)); 
                }
            }
            else if (number < 1000000000000)
            {
                // number is less than a trillion(12 zeros, 13-15 digits), that means number is in billions range
                quotient = number / 1000000000;
                remainder = number % 1000000000;
                words.Append(Convert(quotient));
                words.Append(" billion");
                if (remainder > 0) 
                {
                    words.Append(" ");
                    words.Append(Convert(remainder)); 
                }
            }
            else if (number < 1000000000000000)
            {
                // number is less than a quadrillion(15 zeros, 16-18 digits), that means number is in trillions range
                quotient = number / 1000000000000;
                remainder = number % 1000000000000;
                words.Append(Convert(quotient));
                words.Append(" trillion");
                if (remainder > 0) 
                {
                    words.Append(" ");
                    words.Append(Convert(remainder)); 
                }
            }
            else if (number < 1000000000000000000)
            {
                // number is less than a quintillion(18 zeros, 19 digits), that means number is in quadrillions range
                quotient = number / 1000000000000000;
                remainder = number % 1000000000000000;
                words.Append(Convert(quotient));
                words.Append(" quadrillion");
                if (remainder > 0) 
                {
                    words.Append(" ");
                    words.Append(Convert(remainder));
                }
            }
            else if (number <= 9999999999999999999)
            {
                // digits of number hasn't exceeded 19 so still in quintillion range(18 zeros 19-21 digits)
                quotient = number / 1000000000000000000;
                remainder = number % 1000000000000000000;
                words.Append(Convert(quotient));
                words.Append(" quintillion");
                if (remainder > 0) 
                {
                    words.Append(" ");
                    words.Append(Convert(remainder)); 
                }
            }
            else 
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"{ nameof(number) } is too large");
            }

            return words.ToString();
        }
    }
}
