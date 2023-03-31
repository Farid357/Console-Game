using System;
using System.Numerics;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class WeaponViewFactory : IWeaponViewFactory
    {
        private readonly IText _bulletsText;
        private readonly IEffect _effect;
        
        public WeaponViewFactory(IText bulletsText, IEffectFactory effectFactory)
        {
            _bulletsText = bulletsText ?? throw new ArgumentNullException(nameof(bulletsText));
            _effect = effectFactory.Create(new Transform(new Vector3(20, 50, 10)));
        }

        public IWeaponView Create(IImage image)
        {
            return new WeaponView(image, _bulletsText, _effect);
        }
    }
}