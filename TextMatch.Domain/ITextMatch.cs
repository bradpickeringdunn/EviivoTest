using System.Collections.Generic;

namespace TextMatch.Domain
{
    /// <summary>
    /// Text match for ext and subtext.
    /// </summary>
    public interface ITextMatch
    {
        /// <summary>
        /// Matches text and sub text,
        /// </summary>
        /// <returns>list of subtext first character positions in text</returns>
        IList<int> Match(string text, string subtext);
    }
}