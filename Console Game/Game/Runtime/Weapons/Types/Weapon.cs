using System;

namespace Console_Game.Weapons
{
    public sealed class Weapon : IWeapon
    {
        private readonly IBulletsFactory _bulletsFactory;

        public Weapon(IBulletsFactory bulletsFactory)
        {
            _bulletsFactory = bulletsFactory ?? throw new ArgumentNullException(nameof(bulletsFactory));
        }

        public bool CanShoot => true;

        public void Shoot()
        {
            IBullet bullet = _bulletsFactory.Create();
            bullet.Throw();
        }
    }
}