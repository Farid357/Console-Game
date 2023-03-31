using System;

namespace ConsoleGame.Weapons
{
    public sealed class WeaponWithMagazine : IWeapon
    {
        private readonly IWeapon _weapon;

        public WeaponWithMagazine(IWeapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public IWeaponData Data => _weapon.Data;

        private IWeaponMagazine Magazine => Data.Magazine;

        public bool CanShoot => _weapon.CanShoot && Magazine.Bullets > 0;

        public void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Can't shoot!");

            Magazine.Take(1);
            _weapon.Shoot();
        }
    }
}