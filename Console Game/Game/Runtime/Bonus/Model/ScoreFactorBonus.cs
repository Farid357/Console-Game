using System;
using System.Threading.Tasks;
using ConsoleGame.Stats;
using ConsoleGame.Tools;

namespace ConsoleGame.Bonus
{
    public sealed class ScoreFactorBonus : IBonus
    {
        private readonly IScoreWithFactor _score;
        private readonly float _resetFactorSeconds;

        public ScoreFactorBonus(IScoreWithFactor score, float resetFactorSeconds)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _resetFactorSeconds = resetFactorSeconds.ThrowIfLessThanZeroException();
        }

        public async void Pick()
        {
            _score.IncreaseFactor(1);
            await Task.Delay(TimeSpan.FromSeconds(_resetFactorSeconds));
            _score.ResetFactor();
        }
    }
}