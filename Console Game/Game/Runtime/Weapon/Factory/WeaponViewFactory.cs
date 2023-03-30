using System;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class WeaponViewFactory : IWeaponViewFactory
    {
        private readonly IText _bulletsText;

        public WeaponViewFactory(IText bulletsText)
        {
            _bulletsText = bulletsText ?? throw new ArgumentNullException(nameof(bulletsText));
        }

        public IWeaponView Create(IImage image)
        {
            return new WeaponView(image, _bulletsText);
        }
    }
}