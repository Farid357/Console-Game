using System;

namespace Console_Game
{
    public sealed class WeaponWithInfiniteBullets : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly IInfiniteBulletsView _view;

        public WeaponWithInfiniteBullets(IWeapon weapon, IInfiniteBulletsView view)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool CanShoot => _weapon.CanShoot;

        public void Shoot()
        {
            _view.Visualize();
            _weapon.Shoot();
        }
    }
}