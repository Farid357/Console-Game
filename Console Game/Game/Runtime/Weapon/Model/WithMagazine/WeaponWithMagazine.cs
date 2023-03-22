using System;
using System.Threading.Tasks;

namespace Console_Game.Weapons
{
    public sealed class WeaponWithMagazine : IWeaponWithMagazine
    {
        private readonly IWeapon _weapon;
        private readonly IWeaponWithMagazineView _view;

        public WeaponWithMagazine(IWeaponMagazine magazine, IWeapon weapon, IWeaponWithMagazineView view)
        {
            Magazine = magazine ?? throw new ArgumentNullException(nameof(magazine));
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public IWeaponMagazine Magazine { get; }

        public bool CanShoot => _weapon.CanShoot && !_view.IsReloading && !Magazine.IsEmpty;

        public bool CanReload() => Magazine.Bullets < Magazine.MaxBullets;

        public async Task Reload()
        {
            if (CanReload() == false)
                throw new InvalidOperationException($"Can't reload, it's full!");
            
            await _view.Reload();
            Magazine.Add(Magazine.MaxBullets - Magazine.Bullets);
        }
        
        public void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Can't shoot!");

            Magazine.Take(1);
            _weapon.Shoot();
        }
    }
}