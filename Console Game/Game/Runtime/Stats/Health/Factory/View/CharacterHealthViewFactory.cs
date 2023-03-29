using System;
using System.Numerics;
using ConsoleGame.Tools;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class CharacterHealthViewFactory : IHealthViewFactory
    {
        private readonly ITextFactory _textFactory;
        private readonly IBarFactory _barFactory;
        
        public CharacterHealthViewFactory(ITextFactory textFactory, IBarFactory barFactory)
        {
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
            _barFactory = barFactory ?? throw new ArgumentNullException(nameof(barFactory));
        }

        public IHealthView Create()
        {
            IText text = _textFactory.Create(new Vector2(70, 300));
            ITransform barTransform = new Transform(new Vector2(90, 300));
            IBar bar = _barFactory.Create(barTransform, "");
            return new CharacterHealthView(text, bar);
        }
    }
}