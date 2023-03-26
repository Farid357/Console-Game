using System;
using ConsoleGame.Save_Storages;

namespace ConsoleGame.Stats
{
    public sealed class LevelWithSave : ILevel
    {
        private readonly ILevel _level;
        private readonly ISaveStorage<ILevel> _saveStorage;

        public LevelWithSave(ILevel level, ISaveStorage<ILevel> saveStorage)
        {
            _level = level ?? throw new ArgumentNullException(nameof(level));
            _saveStorage = saveStorage ?? throw new ArgumentNullException(nameof(saveStorage));
        }

        public int Xp => _level.Xp;

        public bool IsFull() => _level.IsFull();

        public bool CanIncrease(int xp) => _level.CanIncrease(xp);

        public void Increase(int xp)
        {
            _level.Increase(xp);
            _saveStorage.Save(_level);
        }
    }
}