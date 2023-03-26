using System;
using System.Drawing;
using System.Numerics;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class ScoreViewFactory : IScoreViewFactory
    {
        private readonly ITextFactory _textFactory;

        public ScoreViewFactory(ITextFactory textFactory)
        {
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IScoreView Create()
        {
            ITransform transform = new Transform(new Vector2(100, 100));
            Font font = new Font("Arial", 18);
            IText scoreText = _textFactory.Create(transform, font, Color.Azure);
            IScoreView scoreView = new ScoreView(scoreText);
            return scoreView;
        }
    }
}