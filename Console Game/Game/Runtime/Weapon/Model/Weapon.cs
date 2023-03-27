using System;
using System.Numerics;
using ConsoleGame.Tools;

namespace ConsoleGame.Weapons
{
    public sealed class Weapon : IWeapon
    {
        private readonly IBulletFactory _bulletFactory;
        private readonly int _bulletDamage;
        private readonly Vector3 _shootDirection = new Vector3(1, 0, 0);
        
        public Weapon(IBulletFactory bulletFactory, int bulletDamage)
        {
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _bulletDamage = bulletDamage.ThrowIfLessThanOrEqualsToZeroException();
        }

        public bool CanShoot => true;

        public void Shoot()
        {
            IBullet bullet = _bulletFactory.Create(_bulletDamage);
            bullet.Throw(_shootDirection);
        }
    }
}