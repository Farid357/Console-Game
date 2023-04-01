using System;

namespace ConsoleGame.Weapons
{
    public sealed class WeaponWithMagazine : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly IWeaponMagazine _magazine;

        public WeaponWithMagazine(IWeapon weapon, IWeaponMagazine magazine)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _magazine = magazine;
        }
        
        public bool CanShoot => _weapon.CanShoot && _magazine.Bullets > 0;
        
        public IWeaponActivityView View => _weapon.View;

        public void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Can't shoot!");

            _magazine.Take(1);
            _weapon.Shoot();
        }
    }
}