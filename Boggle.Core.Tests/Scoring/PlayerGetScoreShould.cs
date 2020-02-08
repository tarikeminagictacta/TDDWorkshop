using Boggle.Core.Tests.Scoring.TestData;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Boggle.Core.Tests.Scoring
{
    public class PlayerGetScoreShould
    {
        [Fact]
        public void Return0PointsIfThereAreNoWords()
        {
            AssertExpectedPointsForWords(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("I")]
        [InlineData("me")]
        public void Returns0PointForWordsUnder3Letters(string word)
        {
            AssertExpectedPointsForWords(0, word);
        }

        [Theory]
        [InlineData("tea")]
        [InlineData("tree")]
        public void Returns1PointFor3To4LetterWord(string word)
        {
            AssertExpectedPointsForWords(1, word);
        }

        [Fact]
        public void Returns2PointsFor5LetterWord()
        {
            AssertExpectedPointsForWords(2, "again");
        }

        [Fact]
        public void Returns3PointsFor6LetterWord()
        {
            AssertExpectedPointsForWords(3, "access");
        }

        [Fact]
        public void Returns5PointsFor7LetterWord()
        {
            AssertExpectedPointsForWords(5, "achieve");
        }

        [Theory]
        [InlineData("accurate")]
        [InlineData("advantage")]
        [InlineData("acknowledgements")]
        [InlineData("hippopotomonstrosesquippedaliophobia")]
        public void Returns11PointsForWordWithMoreThan8Letters(string word)
        {
            AssertExpectedPointsForWords(11, word);
        }

        [Theory]
        [ClassData(typeof(SumPointsTestData))]
        public void ReturnsPointsEqualToSumOfPointsOfAllWords(int expectedPoints, IEnumerable<string> words)
        {
            AssertExpectedPointsForWords(expectedPoints, words.ToArray());
        }

        private void AssertExpectedPointsForWords(int expectedPoints, params string[] words)
        {
            var player = new Player("Tarik", words);
            var result = player.GetPoints();

            result.Should().Be(expectedPoints);
        }
    }
}
