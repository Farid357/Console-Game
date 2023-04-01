using System;

namespace ConsoleGame.Stats
{
    public sealed class ScoreWithFactor : IScoreWithFactor
    {
        private readonly IScore _score;
        private int _factor = 1;
        
        public ScoreWithFactor(IScore score)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
        }

        public int Count => _score.Count;

        public void Raise(int count)
        {
            _score.Raise(count * _factor);
        }

        public void ResetFactor()
        {
            _factor = 1;
        }

        public void IncreaseFactor(int value)
        {
            _factor += value;
        }
    }
}