using System;
using ConsoleGame;

namespace Console_Game
{
    public sealed class InfiniteWeapon : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly IInfiniteWeaponView _weaponView;
        
        public InfiniteWeapon(IWeapon weapon, IInfiniteWeaponView weaponView)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));
        }

        public bool CanShoot => _weapon.CanShoot;
        
        public IWeaponActivityView View => _weapon.View;

        public void Shoot()
        {
            _weapon.Shoot();
            _weaponView.Shoot();
            _weaponView.VisualizeBullets();
        }
    }
}