using System.Collections.Generic;
using System.Linq;

namespace Boggle.Core
{
    public class Player
    {
        private readonly List<int> _wordScores = new List<int> { 1, 1, 2, 3, 5, 11 };

        public string Name { get; }
        public List<string> Words { get; }
        
        public Player(string name, IEnumerable<string> words)
        {
            Name = name;
            Words = words.ToList();
        }

        public int GetPoints(List<string> duplicateWords = null)
        {
            var wordsWithoutDuplicates =
                duplicateWords == null ? Words : Words.Where(word => !duplicateWords.Contains(word));
            return wordsWithoutDuplicates.Select(WordScore).Sum();
        }

        private int WordScore(string word)
        {
            var wordLength = word?.Length ?? 0;
            var scoreIndex = wordLength - 3;
            var lastScoreIndex = _wordScores.Count - 1;
            if (scoreIndex < 0) return 0;
            return scoreIndex <= lastScoreIndex ? _wordScores[scoreIndex] : _wordScores[lastScoreIndex];
        }
    }
}
