using System;
using ConsoleGame.UI;

namespace ConsoleGame.Stats
{
    [Serializable]
    public sealed class LevelView : ILevelView
    {
        private readonly string _levelOwnerName;
        private readonly IText _text;
        
        public LevelView(string levelOwnerName, IText text)
        {
            _levelOwnerName = levelOwnerName ?? throw new ArgumentNullException(nameof(levelOwnerName));
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public void Visualize(int xp, int maxXp)
        {
            _text.Visualize($"{_levelOwnerName} Xp: {xp}, MaxXp: {maxXp}");
        }
    }
}