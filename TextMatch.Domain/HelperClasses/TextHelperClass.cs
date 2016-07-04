using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMatch.Domain.HelperClasses
{
    public static class TextHelperClass
    {
        /// <summary>
        /// Coverts string to char array
        /// </summary>
        public static char[] ToCharArray(string text)
        {
            var result = new List<char>();

            foreach (var character in text)
            {
                result.Add(character);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Returns the length of a string
        /// </summary>
        public static int LengthOfText(string subtext)
        {
            int count = 0;
            foreach (char letter in subtext)
            {
                count++;
            }

            return count;
        }

        /// <summary>
        /// Create list of strings separated by a specified character.
        /// </summary>
        public static List<string> SplitText(string input)
        {
            var result = new List<string>();
            
            string arrayElement = null;

            foreach (var character in input)
            {
                if (char.IsLetter(character))
                {
                    //I would normally use a string builder for this rather than the += operator.
                    arrayElement += character;
                }

                if (!char.IsLetter(character) && arrayElement != null)
                {
                    result.Add(arrayElement);
                    arrayElement = null;
                }

            }

            if (arrayElement != null)
            {
                result.Add(arrayElement);
            }

            return result;
        }
    }
}
