using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class ScoreReward : IReward
    {
        private readonly IScore _score;
        private readonly int _addScoreCount;

        public ScoreReward(IScore score, int addScoreCount)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _addScoreCount = addScoreCount.ThrowIfLessThanOrEqualsToZeroException();
        }

        public bool IsApplied { get; private set; }

        public void Apply()
        {
            IsApplied = true;
            _score.Raise(_addScoreCount);
        }
    }
}