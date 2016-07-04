using TextMatch.Domain.HelperClasses;
using System.Collections.Generic;

namespace TextMatch.Domain
{
    /// <summary>
    /// String match for matching subtext and text
    /// </summary>
    public class TextMatch : ITextMatch
    {
        public IList<int> Match(string text, string subtext)
        {
            var positons = new List<int>();

            var subTextArray = TextHelperClass.SplitText(subtext);
            
            foreach (var textElement in subTextArray)
            {             
                var subTextChars = TextHelperClass.ToCharArray(textElement);
                var textChars = TextHelperClass.ToCharArray(text);
                var subtextLength = TextHelperClass.LengthOfText(textElement);
                var textLength = TextHelperClass.LengthOfText(text);

                positons.AddRange(GetSubtextPositions(textChars, textLength, subTextChars, subtextLength));
            }

            return positons;
        }
        
        private IList<int> GetSubtextPositions(char[] textChars, int textLength, char[] subTextChars, int subtextLength)
        {
            int count = 0;
            int subTextPosition = 0;
            var charPositions = new List<int>();

            for (int charPosition = 1; charPosition <= textLength; charPosition++)
            {
                if (textChars[charPosition - 1] == subTextChars[subTextPosition])
                {
                    count = count == 0 ? charPosition : count;
                    subTextPosition++;

                    if (subTextPosition == subtextLength)
                    {
                        charPositions.Add(count);

                        //Reset for new subtext evaluation.
                        subTextPosition = 0;
                        count = 0;
                        //Don t move to the next character but start from the present character.
                        charPosition--;
                    }
                }
                else
                {

                    subTextPosition = 0;
                    count = 0;
                }
            }

            return charPositions;
        }
    }
}
