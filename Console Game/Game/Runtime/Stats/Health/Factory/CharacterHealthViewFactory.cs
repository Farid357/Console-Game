using System;
using System.Numerics;
using ConsoleGame.Tools;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class CharacterHealthViewFactory : IHealthViewFactory
    {
        private readonly ITextFactory _textFactory;

        public CharacterHealthViewFactory(ITextFactory textFactory)
        {
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IHealthView Create()
        {
            IText text = _textFactory.Create(new Vector2(70, 300));
            return new CharacterHealthView(text);
        }
    }
}