using System.Collections.Generic;
using System.Linq;

namespace Boggle.Core
{
    public class PlayerScore
    {
        public int Points { get; }
        public int LongestWordsLength => LongestWords.FirstOrDefault()?.Length ?? 0;
        public IReadOnlyList<string> LongestWords { get; }

        public PlayerScore(int points, IReadOnlyList<string> longestWords)
        {
            Points = points;
            LongestWords = longestWords;
        }
    }
}