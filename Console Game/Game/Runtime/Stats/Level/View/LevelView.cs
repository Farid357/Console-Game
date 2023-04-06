using System;
using ConsoleGame.UI;

namespace ConsoleGame.Stats
{
    [Serializable]
    public sealed class LevelView : ILevelView
    {
        private readonly IText _text;
        
        public LevelView(IText text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public void Visualize(int xp, int maxXp)
        {
            _text.Visualize($"Player Xp: {xp}, MaxXp: {maxXp}");
        }
    }
}