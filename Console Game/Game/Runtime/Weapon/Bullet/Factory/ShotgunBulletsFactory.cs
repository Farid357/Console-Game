using System;
using System.Collections.Generic;
using Console_Game.Tools;

namespace Console_Game.Weapons
{
    public sealed class ShotgunBulletsFactory : IBulletsFactory
    {
        private readonly IBulletsFactory _bulletsFactory;
        private readonly int _bulletsCount;

        public ShotgunBulletsFactory(IBulletsFactory bulletsFactory, int bulletsCount)
        {
            _bulletsFactory = bulletsFactory ?? throw new ArgumentNullException(nameof(bulletsFactory));
            _bulletsCount = bulletsCount.ThrowIfLessThanOrEqualsToZeroException();
        }

        public IBullet Create(int damage)
        {
            var bullets = new List<IBullet>(_bulletsCount);
            
            for (var i = 0; i < _bulletsCount; i++)
            {
                IBullet bullet = _bulletsFactory.Create(damage);
                bullets.Add(bullet);
            }

            return new Bullets(bullets);
        }
    }
}