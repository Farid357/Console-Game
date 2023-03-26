using System;
using System.Numerics;
using ConsoleGame.Tools;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class InfiniteBulletsViewFactory : IInfiniteBulletsViewFactory
    {
        private readonly ITextFactory _textFactory;

        public InfiniteBulletsViewFactory(ITextFactory textFactory)
        {
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IInfiniteBulletsView Create()
        {
            IText text = _textFactory.Create(new Vector2(100, 200));
            return new InfiniteBulletsView(text);
        }
    }
}