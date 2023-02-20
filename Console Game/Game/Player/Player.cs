using System;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class Player : IUpdateable
    {
        private readonly IWeaponInput _weaponInput;
        private readonly IWeaponWithMagazine _weapon;

        public Player(IWeaponInput weaponInput, IWeaponWithMagazine weapon)
        {
            _weaponInput = weaponInput ?? throw new ArgumentNullException(nameof(weaponInput));
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public void Update(float deltaTime)
        {
            if (_weaponInput.IsUsing && _weapon.CanShoot)
            {
                _weapon.Shoot();
            }
        }
    }
}