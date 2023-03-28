using System;
using System.Collections.Generic;

namespace ConsoleGame.Stats
{
    [Serializable]
    public sealed class ChainOfLevel : IChainOfLevel
    {
        private readonly List<ILevel> _levels;

        public ChainOfLevel(List<ILevel> levels, ILevel firstLevel)
        {
            _levels = levels ?? throw new ArgumentNullException(nameof(levels));
            CurrentLevel = firstLevel ?? throw new ArgumentNullException(nameof(firstLevel));

            if (_levels.Contains(firstLevel) == false)
                throw new ArgumentOutOfRangeException($"Levels list doesn't contains first level!");
        }

        public ILevel CurrentLevel { get; private set; }

        public int CurrentLevelIndex => _levels.IndexOf(CurrentLevel);

        public int Xp => CurrentLevel.Xp;

        public bool IsFull() => CurrentLevel.IsFull();

        public bool CanIncrease(int xp) => CurrentLevel.CanIncrease(xp);

        public void Increase(int xp)
        {
            if (CanIncrease(xp) == false)
                throw new InvalidOperationException($"Can't increase level! Xp: {xp}");

            CurrentLevel.Increase(xp);
            int nextLevelIndex = CurrentLevelIndex + 1;

            if (CurrentLevel.IsFull() && _levels.Count > nextLevelIndex)
                CurrentLevel = _levels[nextLevelIndex];
        }
    }
}