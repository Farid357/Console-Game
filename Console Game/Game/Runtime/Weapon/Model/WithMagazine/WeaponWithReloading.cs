using System;
using System.Threading.Tasks;
using ConsoleGame.Tools;

namespace ConsoleGame.Weapons
{
    public sealed class WeaponWithReloading : IWeaponWithReloading
    {
        private readonly IWeaponWithMagazine _weapon;
        private readonly IWeaponWithReloadingView _view;

        public WeaponWithReloading(IWeaponWithMagazine weapon, IWeaponWithReloadingView view)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool CanShoot => _weapon.CanShoot && !_view.IsReloading;
        
        public bool CanReload => Magazine.IsNotFull();

        private IWeaponMagazine Magazine => _weapon.Magazine;
        
        public void Shoot()
        {
            if (CanShoot == false)
                throw new Exception($"Weapon can't shoot!");
            
            _weapon.Shoot();
        }

        public async Task Reload()
        {
            if (CanReload == false)
                throw new InvalidOperationException($"Can't reload, it's full!");
            
            await _view.Reload();
            Magazine.Fill();
        }
    }
}