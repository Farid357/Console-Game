using System;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class InfiniteWeaponView : IInfiniteWeaponView
    {
        private readonly IText _text;
        private readonly IWeaponView _weaponView;

        public InfiniteWeaponView(IText text, IWeaponView weaponView)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));
        }
        
        public bool IsActive => _weaponView.IsActive;

        public void VisualizeBullets()
        {
            _text.Visualize("\u221E");
        }
        
        public void Enable()
        {
            _weaponView.Enable();
        }

        public void Disable()
        {
            _weaponView.Disable();
        }

        public void Shoot()
        {
            _weaponView.Shoot();
        }
    }
}