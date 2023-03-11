using System;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class PlayerWithWeaponMagazine : IPlayerWithWeaponMagazine
    {
        private readonly IWeaponWithMagazine _weapon;

        public PlayerWithWeaponMagazine(IWeaponInput weaponInput, IWeaponWithMagazine weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            WeaponInput = weaponInput ?? throw new ArgumentNullException(nameof(weaponInput));
        }

        public IWeaponInput WeaponInput { get; }

        public IWeapon Weapon => _weapon;

        public IWeaponMagazine Magazine => _weapon.Magazine;

        public void Update(float deltaTime)
        {
            if (WeaponInput.IsUsing && Weapon.CanShoot)
            {
                Weapon.Shoot();
                TryReload();
            }
        }

        private void TryReload()
        {
            if (Magazine.IsEmpty)
                _weapon.Reload();
        }
    }
}