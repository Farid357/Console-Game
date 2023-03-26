using System;
using ConsoleGame.Tools;

namespace ConsoleGame.Stats
{
    [Serializable]
    public sealed class Level : ILevel
    {
        private readonly ILevelView _levelView;
        private readonly int _maxXp;

        public Level(ILevelView levelView, int startXp, int maxXp)
        {
            _levelView = levelView ?? throw new ArgumentNullException(nameof(levelView));
            Xp = startXp.ThrowIfLessThanZeroException();
            _maxXp = maxXp.ThrowIfLessThanOrEqualsToZeroException();
        }

        public int Xp { get; private set; }

        public bool IsFull() => Xp == _maxXp;

        public bool CanIncrease(int xp) => Xp + xp <= _maxXp;

        public void Increase(int xp)
        {
            if (CanIncrease(xp) == false)
                throw new InvalidOperationException($"Can't increase level, xp: {xp}");

            Xp += xp.ThrowIfLessThanZeroException();
            _levelView.Visualize(Xp, _maxXp);
        }
    }
}