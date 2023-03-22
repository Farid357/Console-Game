using System;
using System.Numerics;
using Console_Game.Tools;

namespace Console_Game.Weapons
{
    public sealed class Weapon : IWeapon
    {
        private readonly IBulletsFactory _bulletsFactory;
        private readonly int _bulletDamage;
        private readonly Vector2 _shootDirection = new Vector2(1, 0);
        
        public Weapon(IBulletsFactory bulletsFactory, int bulletDamage)
        {
            _bulletsFactory = bulletsFactory ?? throw new ArgumentNullException(nameof(bulletsFactory));
            _bulletDamage = bulletDamage.ThrowIfLessThanOrEqualsToZeroException();
        }

        public bool CanShoot => true;

        public void Shoot()
        {
            IBullet bullet = _bulletsFactory.Create(_bulletDamage);
            bullet.Throw(_shootDirection);
        }
    }
}