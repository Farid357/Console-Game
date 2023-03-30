using System;
using System.Numerics;
using ConsoleGame.Tools;

namespace ConsoleGame.Weapons
{
    public sealed class CharacterWeapon : IWeapon
    {
        private readonly IBulletFactory _bulletFactory;
        private readonly IReadOnlyMovement _movement;
        private readonly int _bulletDamage;
        
        public CharacterWeapon(IBulletFactory bulletFactory, IReadOnlyMovement movement, int bulletDamage)
        {
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _bulletDamage = bulletDamage.ThrowIfLessThanOrEqualsToZeroException();
        }

        public bool CanShoot => true;

        public void Shoot()
        {
            IBullet bullet = _bulletFactory.Create(_bulletDamage);
            bullet.Throw(_movement.LookDirection);
        }
    }
}