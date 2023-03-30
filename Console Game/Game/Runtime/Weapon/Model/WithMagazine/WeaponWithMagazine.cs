using System;
using System.Threading.Tasks;

namespace ConsoleGame.Weapons
{
    public sealed class WeaponWithMagazine : IWeaponWithMagazine
    {
        private readonly IWeapon _weapon;

        public WeaponWithMagazine(IWeaponMagazine magazine, IWeapon weapon, IWeaponWithReloadingView view)
        {
            Magazine = magazine ?? throw new ArgumentNullException(nameof(magazine));
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public IWeaponMagazine Magazine { get; }

        public bool CanShoot => _weapon.CanShoot && Magazine.Bullets > 0;

        
        public void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Can't shoot!");

            Magazine.Take(1);
            _weapon.Shoot();
        }
    }

    public interface IWeaponWithReloading : IWeapon
    {
        bool CanReload { get; }
        
        Task Reload();
    }
}