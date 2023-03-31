using System;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class WeaponView : IWeaponView
    {
        private readonly IImage _image;
        private readonly IText _bulletsText;
        private readonly IEffect _shootEffect;

        public WeaponView(IImage image, IText bulletsText, IEffect shootEffect)
        {
            _image = image ?? throw new ArgumentNullException(nameof(image));
            _bulletsText = bulletsText ?? throw new ArgumentNullException(nameof(bulletsText));
            _shootEffect = shootEffect ?? throw new ArgumentNullException(nameof(shootEffect));
        }

        public bool IsActive { get; private set; }

        public void Enable()
        {
            _image.Enable();
            _bulletsText.Enable();
            IsActive = true;
        }

        public void Disable()
        {
            _image.Enable();
            _bulletsText.Disable();
            IsActive = false;
        }

        public void Shoot()
        {
           _shootEffect.Play();
        }
    }
}