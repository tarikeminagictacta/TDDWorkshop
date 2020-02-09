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
            result.Score.LongestWords.Should().Contain("abilities");
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
            result.Score.LongestWords.Count.Should().Be(2);
        }
    }
}
