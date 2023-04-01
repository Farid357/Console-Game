using System;
using ConsoleGame.Stats;

namespace ConsoleGame.Bonus
{
    public sealed class ScoreFactorBonus : IBonus
    {
        private readonly IScoreWithFactor _score;

        public ScoreFactorBonus(IScoreWithFactor score)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
        }

        public void Pick()
        {
            _score.IncreaseFactor(1);
        }
    }
}