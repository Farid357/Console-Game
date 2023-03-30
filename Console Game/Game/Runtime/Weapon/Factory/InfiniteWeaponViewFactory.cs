using System;
using System.Numerics;
using ConsoleGame.Tools;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class InfiniteWeaponViewFactory : IInfiniteWeaponViewFactory
    {
        private readonly ITextFactory _textFactory;

        public InfiniteWeaponViewFactory(ITextFactory textFactory)
        {
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IInfiniteWeaponView Create()
        {
            IText text = _textFactory.Create(new Vector2(100, 200));
            return new InfiniteWeaponView(text);
        }
    }
}