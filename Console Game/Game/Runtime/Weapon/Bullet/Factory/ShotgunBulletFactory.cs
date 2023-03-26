using System;
using System.Collections.Generic;
using ConsoleGame.Tools;

namespace ConsoleGame.Weapons
{
    public sealed class ShotgunBulletFactory : IBulletFactory
    {
        private readonly IBulletFactory _bulletFactory;
        private readonly int _bulletsCount;

        public ShotgunBulletFactory(IBulletFactory bulletFactory, int bulletsCount)
        {
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _bulletsCount = bulletsCount.ThrowIfLessThanOrEqualsToZeroException();
        }

        public IBullet Create(int damage)
        {
            var bullets = new List<IBullet>(_bulletsCount);
            
            for (var i = 0; i < _bulletsCount; i++)
            {
                IBullet bullet = _bulletFactory.Create(damage);
                bullets.Add(bullet);
            }

            return new Bullets(bullets);
        }
    }
}