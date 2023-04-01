using System;
using System.Numerics;
using ConsoleGame.Tests.UI;
using ConsoleGame.Tools;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class InfiniteWeaponViewFactory : IInfiniteWeaponViewFactory
    {
        private readonly ITextFactory _textFactory;
        private readonly IWeaponViewFactory _weaponViewFactory;

        public InfiniteWeaponViewFactory(ITextFactory textFactory, IWeaponViewFactory weaponViewFactory)
        {
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
            _weaponViewFactory = weaponViewFactory ?? throw new ArgumentNullException(nameof(weaponViewFactory));
        }

        public IInfiniteWeaponView Create()
        {
            IText text = _textFactory.Create(new Vector2(100, 200));
            return new InfiniteWeaponView(text, _weaponViewFactory.Create(new DummyImage()));
        }
    }
}