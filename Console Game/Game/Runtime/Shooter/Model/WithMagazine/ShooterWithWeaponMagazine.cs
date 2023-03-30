using System;
using System.Threading.Tasks;
using ConsoleGame.Tools;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class ShooterWithWeaponMagazine : IShooterWithWeaponMagazine
    {
        private readonly IWeaponInput _weaponInput;

        public ShooterWithWeaponMagazine(IWeaponInput weaponInput, IWeaponWithMagazine weapon)
        {
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _weaponInput = weaponInput ?? throw new ArgumentNullException(nameof(weaponInput));
        }

        public IWeaponWithMagazine Weapon { get; }

        public async void Update(float deltaTime)
        {
            if (_weaponInput.IsUsing && Weapon.CanShoot)
            {
                Weapon.Shoot();
                await TryReload();
            }
        }

        private async Task TryReload()
        {
            if (Weapon.MagazineIsEmpty())
                await Weapon.Reload();
        }
    }
}