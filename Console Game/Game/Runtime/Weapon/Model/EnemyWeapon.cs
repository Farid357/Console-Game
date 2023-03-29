using System;
using System.Numerics;

namespace ConsoleGame.Weapons
{
    public sealed class EnemyWeapon : IWeapon
    {
        private readonly ICharacter _character;
        private readonly IReadOnlyTransform _transform;
        private readonly IBulletFactory _bulletFactory;
        private readonly int _damage;

        public EnemyWeapon(ICharacter character, IReadOnlyTransform transform, IBulletFactory bulletFactory, int damage)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _damage = damage;
        }
        
        public bool CanShoot => true;
        
        public void Shoot()
        {
            IBullet bullet = _bulletFactory.Create(_damage);
            Vector3 shootDirection = Vector3.Normalize(_character.Transform.Position - _transform.Position);
            bullet.Throw(shootDirection);
        }
    }
}