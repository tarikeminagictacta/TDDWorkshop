using System.Collections.Generic;
using System.Linq;

namespace Boggle.Core
{
    public class Game
    {
        private readonly List<Player> _players;

        public Game(List<Player> players)
        {
            _players = players;
        }

        public Dictionary<string, int> GetPlayerPoints()
        {
            var allWords = _players.SelectMany(player => player.Words);
            var duplicateWords = allWords
                .GroupBy(word => word)
                .Where(grouped => grouped.Count() > 1)
                .Select(grouped => grouped.Key).ToList();
            return _players.ToDictionary(player => player.Name, player => player.GetPoints(duplicateWords));
        }
    }
}