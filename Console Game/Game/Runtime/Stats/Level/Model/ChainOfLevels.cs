using System;
using System.Collections.Generic;

namespace ConsoleGame.Stats
{
    [Serializable]
    public sealed class ChainOfLevels : ILevel
    {
        private readonly List<ILevel> _all;
        private ILevel _currentLevel;

        public ChainOfLevels(List<ILevel> all, ILevel firstLevel)
        {
            _all = all ?? throw new ArgumentNullException(nameof(all));
            _currentLevel = firstLevel ?? throw new ArgumentNullException(nameof(firstLevel));

            if (_all.Contains(firstLevel) == false)
                throw new ArgumentOutOfRangeException($"Levels list doesn't contains first level!");
        }
        
        public int Xp => _currentLevel.Xp;

        public bool IsFull() => _currentLevel.IsFull();

        public bool CanIncrease(int xp) => _currentLevel.CanIncrease(xp);

        public void Increase(int xp)
        {
            if (CanIncrease(xp) == false)
                throw new InvalidOperationException($"Can't increase level! Xp: {xp}");

            _currentLevel.Increase(xp);
            int nextLevelIndex = _all.IndexOf(_currentLevel) + 1;
            
            if (_currentLevel.IsFull() && _all.Count > nextLevelIndex)
                _currentLevel = _all[nextLevelIndex];
        }
    }
}