using System;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class Player : IUpdateable, IPlayer
    {
        public Player(IWeaponInput weaponInput, IWeaponWithMagazine weapon)
        {
            WeaponInput = weaponInput ?? throw new ArgumentNullException(nameof(weaponInput));
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public IWeaponInput WeaponInput { get; }
        
        public IWeaponWithMagazine Weapon { get; }

        public void Update(float deltaTime)
        {
            if (WeaponInput.IsUsing && Weapon.CanShoot)
            {
                Weapon.Shoot();
            }
        }
    }
}