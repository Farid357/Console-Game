using System;
using ConsoleGame;

namespace Console_Game
{
    public sealed class InfiniteWeapon : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly IInfiniteWeaponView _view;
        
        public InfiniteWeapon(IWeapon weapon, IInfiniteWeaponView view)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool CanShoot => _weapon.CanShoot;
        
        public IWeaponData Data => _weapon.Data;

        public void Shoot()
        {
            _weapon.Shoot();
            _view.Shoot();
            _view.VisualizeBullets();
        }
    }
}