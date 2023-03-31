using System;
using ConsoleGame.Tools;

namespace ConsoleGame.Weapons
{
    public sealed class CharacterWeapon : IWeapon
    {
        private readonly IBulletFactory _bulletFactory;
        private readonly IReadOnlyMovement _movement;
        
        public CharacterWeapon(IBulletFactory bulletFactory, IReadOnlyMovement movement, IWeaponData data)
        {
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public bool CanShoot => Data.View.IsActive;
        
        public IWeaponData Data { get; }

        public void Shoot()
        {
            if (CanShoot == false)
                throw new Exception($"Weapon can't shoot! View is not active!");
            
            IBullet bullet = _bulletFactory.Create(Data.Damage);
            bullet.Throw(_movement.LookDirection);
        }
    }
}