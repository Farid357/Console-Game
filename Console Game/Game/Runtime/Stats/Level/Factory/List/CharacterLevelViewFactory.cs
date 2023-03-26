using System;
using System.Drawing;
using System.Numerics;
using ConsoleGame.Stats;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class CharacterLevelViewFactory : ILevelViewFactory
    {
        private readonly ITextFactory _textFactory;

        public CharacterLevelViewFactory(ITextFactory textFactory)
        {
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public ILevelView Create()
        {
            ITransform transform = new Transform(new Vector2(100, 250));
            Font font = new Font("Arial", 24);
            IText text = _textFactory.Create(transform, font, Color.Aqua);
            ILevelView levelView = new LevelView("Player", text);
            return levelView;
        }
    }
}