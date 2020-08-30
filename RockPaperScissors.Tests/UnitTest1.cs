using System;
using Xunit;

namespace RockPaperScissors.Tests
{
    public enum GameResult
    {
        Draw = 1,
        Lose = 2,
        Win = 3,
    }


    public enum Shape
    {
        Rock,
        Paper,
        Scissors,
    }


    public class UnitTest1
    {
        public GameResult Compare(Shape left, Shape right)
        {
            if (left == right)
                return GameResult.Draw;

            var item1 = (int)left;
            var item2 = ((int)right + 1) % 3;

            return item1 == item2 ? GameResult.Win : GameResult.Lose;
        }

        [Theory]
        [InlineData(Shape.Paper)]
        [InlineData(Shape.Rock)]
        [InlineData(Shape.Scissors)]
        public void EqualTest(Shape left)
        {
            Assert.Equal(GameResult.Draw, Compare(left, left));
        }

        [Theory]
        [InlineData(Shape.Scissors, Shape.Paper)]
        [InlineData(Shape.Paper, Shape.Rock)]
        [InlineData(Shape.Rock, Shape.Scissors)]
        public void WinTest(Shape left, Shape right)
        {
            Assert.Equal(GameResult.Win, Compare(left, right));
        }
        
        [Theory]
        [InlineData(Shape.Paper, Shape.Scissors)]
        [InlineData(Shape.Rock, Shape.Paper)]
        [InlineData(Shape.Scissors, Shape.Rock)]
        public void LoseTest(Shape left, Shape right)
        {
            Assert.Equal(GameResult.Lose, Compare(left, right));
        }
    }
}
