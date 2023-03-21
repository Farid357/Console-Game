using System;
using Console_Game.UI;

namespace Console_Game
{
    [Serializable]
    public sealed class ScoreView : IScoreView
    {
        private readonly IText _text;

        public ScoreView(IText text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public void Visualize(int count)
        {
            _text.Visualize($"Score: {count}");
        }
    }
}