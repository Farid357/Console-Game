using System;

namespace Console_Game.Weapons
{
    public sealed class WeaponWithMagazine : IWeaponWithMagazine
    {
        private readonly IWeapon _weapon;

        public WeaponWithMagazine(IWeaponMagazine magazine, IWeapon weapon)
        {
            Magazine = magazine ?? throw new ArgumentNullException(nameof(magazine));
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public IWeaponMagazine Magazine { get; }

        public bool CanShoot => _weapon.CanShoot && Magazine.IsEmpty == false;

        public void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Can't shoot!");

            Magazine.Take(1);
            _weapon.Shoot();
        }
    }
}