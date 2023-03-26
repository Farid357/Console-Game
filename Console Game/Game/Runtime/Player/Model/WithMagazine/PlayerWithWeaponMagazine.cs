using System;
using System.Threading.Tasks;
using ConsoleGame.Weapons;

namespace ConsoleGame
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

        public async void Update(float deltaTime)
        {
            if (WeaponInput.IsUsing && Weapon.CanShoot)
            {
                Weapon.Shoot();
            }

            await TryReload();
        }

        private async Task TryReload()
        {
            if (Magazine.Bullets == 0)
                await _weapon.Reload();
        }
    }
}