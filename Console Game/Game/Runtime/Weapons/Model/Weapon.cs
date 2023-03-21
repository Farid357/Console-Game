using System;
using System.Numerics;

namespace Console_Game.Weapons
{
    public sealed class Weapon : IWeapon
    {
        private readonly IBulletsFactory _bulletsFactory;
        private readonly Vector2 _right = new Vector2(1, 0);
        
        public Weapon(IBulletsFactory bulletsFactory)
        {
            _bulletsFactory = bulletsFactory ?? throw new ArgumentNullException(nameof(bulletsFactory));
        }

        public bool CanShoot => true;

        public void Shoot()
        {
            IBullet bullet = _bulletsFactory.Create();
            bullet.Throw(_right);
        }
    }
}