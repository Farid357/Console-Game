using System;

namespace ConsoleGame.Weapons
{
    public sealed class Weapon : IWeapon
    {
        private readonly IBulletFactory _bulletFactory;
        private readonly IWeaponView _view;
        private readonly IAim _aim;
        private readonly int _damage;
        
        public Weapon(IBulletFactory bulletFactory, IAim aim, IWeaponView view, int damage)
        {
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _aim = aim ?? throw new ArgumentNullException(nameof(aim));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _damage = damage;
        }

        public bool CanShoot => _view.IsActive;
        
        public IWeaponActivityView View => _view;

        public void Shoot()
        {
            if (CanShoot == false)
                throw new Exception($"Weapon can't shoot! View is not active!");
            
            IBullet bullet = _bulletFactory.Create(_damage);
            _view.Shoot();
            bullet.Throw(_aim.Target);
        }
    }
}