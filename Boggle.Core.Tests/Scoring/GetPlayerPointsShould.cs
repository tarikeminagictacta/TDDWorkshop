using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Boggle.Core.Tests.Scoring
{
    public class GetPlayerPointsShould
    {
        [Fact]
        public void ReturnScoreForEachPlayer()
        {
            var game = new Game(new List<Player>
            {
                new Player("Tarik", new List<string> {"tea", "tree"}),
                new Player("Haris", new List<string> {"again", "access", "achieve", "accurate", "tee", "me"})
            });

            var results = game.GetPlayerPoints();

            results["Tarik"].Should().Be(2);
            results["Haris"].Should().Be(22);
        }

        [Fact]
        public void NotTakeIntoPointsDuplicateWordsBetweenTwoPlayers()
        {
            var game = new Game(new List<Player>
            {
                new Player("Tarik", new List<string> {"tea", "tree", "accurate"}),
                new Player("Haris", new List<string> {"again", "access", "achieve", "accurate", "tea", "me"})
            });

            var results = game.GetPlayerPoints();

            results["Tarik"].Should().Be(1);
            results["Haris"].Should().Be(10);
        }

        [Fact]
        public void NotTakeIntoPointsDuplicateWordsBetweenAnyPlayers()
        {
            var game = new Game(new List<Player>
            {
                new Player("Tarik", new List<string> { "tea", "tree", "accurate" }),
                new Player("Haris", new List<string> { "again", "access", "achieve", "accurate", "tea", "me" }),
                new Player("Adis", new List<string> { "access", "tree", "tea" })
            });

            var results = game.GetPlayerPoints();

            results["Tarik"].Should().Be(0);
            results["Haris"].Should().Be(7);
            results["Adis"].Should().Be(0);
        }
    }
}
