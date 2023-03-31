using System;
using ConsoleGame;
using ConsoleGame.Weapons;

namespace Console_Game
{
    public sealed class WeaponWithBattery : IWeapon
    {
        private readonly IBulletFactory _bulletFactory;
        private readonly IReadOnlyMovement _movement;

        public WeaponWithBattery(IBulletFactory bulletFactory, IReadOnlyMovement movement, IWeaponData data)
        {
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public bool CanShoot => true;

        public IWeaponData Data { get; }

        private IBattery Battery => Data.Battery;

        public void Shoot()
        {
            float damage = Battery.IsDischarged ? Data.Damage : Battery.Amount * 100;
            IBullet bullet = _bulletFactory.Create((int)damage);
            bullet.Throw(_movement.LookDirection);
        }
    }
}