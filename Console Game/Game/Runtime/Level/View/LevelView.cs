using System;

namespace Console_Game.Stats
{
    [Serializable]
    public sealed class LevelView : ILevelView
    {
        private readonly string _levelOwnerName;

        public LevelView(string levelOwnerName)
        {
            _levelOwnerName = levelOwnerName ?? throw new ArgumentNullException(nameof(levelOwnerName));
        }

        public void Visualize(int xp, int maxXp)
        {
            Console.WriteLine($"{_levelOwnerName} Xp: {xp}, MaxXp: {maxXp}");
        }
    }
}