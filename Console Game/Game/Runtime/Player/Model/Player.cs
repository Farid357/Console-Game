using System;

namespace ConsoleGame
{
    public sealed class Player : IPlayer
    {
        public Player(IWeaponInput weaponInput, IWeapon weapon)
        {
            WeaponInput = weaponInput ?? throw new ArgumentNullException(nameof(weaponInput));
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public IWeaponInput WeaponInput { get; }

        public IWeapon Weapon { get; }

        public void Update(float deltaTime)
        {
            if (WeaponInput.IsUsing && Weapon.CanShoot)
                Weapon.Shoot();
        }
    }
}