using System;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class Player : IGameLoopObject, IPlayer
    {
        public Player(IWeaponInput weaponInput, IWeaponWithMagazine weapon)
        {
            WeaponInput = weaponInput ?? throw new ArgumentNullException(nameof(weaponInput));
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public IWeaponInput WeaponInput { get; }

        public IWeaponWithMagazine Weapon { get; }

        public void Update(long deltaTime)
        {
            if (WeaponInput.IsUsing && Weapon.CanShoot)
                Weapon.Shoot();

            TryReload();
        }

        private void TryReload()
        {
            if (Weapon.Magazine.IsEmpty)
                Weapon.Reload();
        }
    }
}