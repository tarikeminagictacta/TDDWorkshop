using System.Collections.Generic;
using System.Linq;

namespace Boggle.Core
{
    public class Game
    {
        private readonly IReadOnlyList<Player> _players;

        public Game(IReadOnlyList<Player> players)
        {
            _players = players;
        }

        public Dictionary<string, PlayerScore> GetPlayerPoints()
        {
            var allWords = _players.SelectMany(player => player.Words);
            var duplicateWords = allWords
                .GroupBy(word => word)
                .Where(grouped => grouped.Count() > 1)
                .Select(grouped => grouped.Key).ToList();
            return _players.ToDictionary(player => player.Name, player => player.GetScore(duplicateWords));
        }

        public GameWinner GetWinner()
        {
            var gameResults = GetPlayerPoints();
            var winner = gameResults
                .OrderByDescending(x => x.Value.Points)
                .ThenByDescending(x => x.Value.LongestWordsLength)
                .ThenByDescending(x => x.Value.LongestWords.Count)
                .First();
            return new GameWinner(winner.Key, winner.Value);
        }
    }
}