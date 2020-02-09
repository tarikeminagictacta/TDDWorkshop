using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Boggle.Core.Tests.Scoring
{
    public class GameGetWinnerShould
    {
        [Fact]
        public void GetWinnerBasedOnPoints()
        {
            var game = new Game(new List<Player>
            {
                new Player("Tarik", new List<string> {"tea", "tree"}),
                new Player("Haris", new List<string> {"again", "access", "achieve", "accurate", "tee", "me"})
            });

            var result = game.GetWinner();

            result.Name.Should().Be("Haris");
            result.Score.Points.Should().Be(22);
        }

        [Fact]
        public void GetWinnerWhenPlayersAreTiedOnPointsAndOneHasLongerWord()
        {
            var game = new Game(new List<Player>
            {
                new Player("Tarik", new List<string> {"absolute", "accident"}),
                new Player("Haris", new List<string> {"accurate", "abilities"})
            });

            var result = game.GetWinner();

            result.Name.Should().Be("Haris");
            result.Score.Points.Should().Be(22);
            var playerScores = game.GetPlayerScores();
            var tarikPlayerScore = playerScores["Tarik"];
            var harisPlayerScore = playerScores["Haris"];
            tarikPlayerScore.Points.Should().Be(harisPlayerScore.Points);
            tarikPlayerScore.LongestWordsLength.Should().BeLessThan(harisPlayerScore.LongestWordsLength);
        }

        [Fact]
        public void GetWinnerWhenPlayersAreTiedOnPointsAndLongestWordButNotOnCountOfLongestWords()
        {
            var game = new Game(new List<Player>
            {
                new Player("Tarik", new List<string> {"absolute", "airport", "accept", "action"}),
                new Player("Haris", new List<string> {"accurate", "accident"})
            });

            var result = game.GetWinner();

            result.Name.Should().Be("Haris");
            result.Score.Points.Should().Be(22);
            var playerScores = game.GetPlayerScores();
            var tarikPlayerScore = playerScores["Tarik"];
            var harisPlayerScore = playerScores["Haris"];
            tarikPlayerScore.Points.Should().Be(harisPlayerScore.Points);
            tarikPlayerScore.LongestWordsLength.Should().Be(harisPlayerScore.LongestWordsLength);
            tarikPlayerScore.LongestWords.Count.Should().BeLessThan(harisPlayerScore.LongestWords.Count);
        }
    }
}
