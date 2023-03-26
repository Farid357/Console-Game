using System;
using ConsoleGame.UI;

namespace ConsoleGame.Weapons
{
    public sealed class WeaponMagazineView : IWeaponMagazineView
    {
        private readonly IText _text;

        public WeaponMagazineView(IText text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public void Visualize(int bullets, int maxBullets)
        {
            _text.Visualize($"{bullets}/{maxBullets}");
        }
    }
}