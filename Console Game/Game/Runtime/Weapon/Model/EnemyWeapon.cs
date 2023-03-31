using System;
using System.Numerics;

namespace ConsoleGame.Weapons
{
    public sealed class EnemyWeapon : IWeapon
    {
        private readonly IReadOnlyCharacter _character;
        private readonly IReadOnlyTransform _transform;
        private readonly IBulletFactory _bulletFactory;

        public EnemyWeapon(IReadOnlyCharacter character, IReadOnlyTransform transform, IBulletFactory bulletFactory, IWeaponData data)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public bool CanShoot => Data.View.IsActive;
        
        public IWeaponData Data { get; }

        public void Shoot()
        {
            if (CanShoot == false)
                throw new Exception($"Weapon can't shoot! View is not active!");
            
            IBullet bullet = _bulletFactory.Create(Data.Damage);
            Vector3 shootDirection = Vector3.Normalize(_character.Movement.Transform.Position - _transform.Position);
            bullet.Throw(shootDirection);
        }
    }
}