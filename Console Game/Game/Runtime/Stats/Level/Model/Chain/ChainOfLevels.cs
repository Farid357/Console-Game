using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleGame.SaveSystem;
using ConsoleGame.Tools;

namespace ConsoleGame.Stats
{
    [Serializable]
    public sealed class ChainOfLevel : IChainOfLevel
    {
        private readonly List<ILevel> _levels;
        private readonly ISaveStorage<ILevel> _levelStorage;

        public ChainOfLevel(List<ILevel> levels, ISaveStorage<ILevel> levelStorage)
        {
            _levels = levels ?? throw new ArgumentNullException(nameof(levels));
            _levelStorage = levelStorage ?? throw new ArgumentNullException(nameof(levelStorage));
            CurrentLevel = _levelStorage.LoadOrDefault(levels.First());
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
            {
                CurrentLevel = _levels[nextLevelIndex];
                CurrentLevel.Visualize();
            }

            _levelStorage.Save(CurrentLevel);
        }
    }
}