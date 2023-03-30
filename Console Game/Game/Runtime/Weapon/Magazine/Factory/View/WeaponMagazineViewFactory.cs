using System;
using System.Drawing;
using System.Numerics;
using ConsoleGame.UI;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class WeaponMagazineViewFactory : IWeaponMagazineViewFactory
    {
        private readonly ITextFactory _textFactory;

        public WeaponMagazineViewFactory(ITextFactory textFactory)
        {
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IWeaponMagazineView Create()
        {
            ITransform transform = new Transform(new Vector2(150, 200));
            Font font = new Font("Arial", 18);
            IText text = _textFactory.Create(transform, font, Color.Blue);
            return new WeaponMagazineView(text);
        }
    }
}