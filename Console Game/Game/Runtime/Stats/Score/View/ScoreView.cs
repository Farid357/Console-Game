using System;
using ConsoleGame.UI;

namespace ConsoleGame
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