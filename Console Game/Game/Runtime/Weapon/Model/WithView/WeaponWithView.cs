using System;

namespace ConsoleGame.Weapons
{
    public sealed class WeaponWithView : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly IWeaponView _view;

        public WeaponWithView(IWeapon weapon, IWeaponView view)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool CanShoot => _weapon.CanShoot;
        
        public IWeaponData Data => _weapon.Data;

        public void Shoot()
        {
            _weapon.Shoot();
            _view.Shoot();
        }
    }
}