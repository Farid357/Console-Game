using System;
using ConsoleGame.Physics;
using ConsoleGame.Weapon;

namespace ConsoleGame
{
    public sealed class GrenadeFactory : IWeaponFactory
    {
        private readonly IBombFactory _bombFactory;
        private readonly ITransform _transform;

        public GrenadeFactory(IBombFactory bombFactory, ITransform transform)
        {
            _bombFactory = bombFactory ?? throw new ArgumentNullException(nameof(bombFactory));
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public IWeapon Create(IAim aim, IWeaponsData weaponsData)
        {
            IBomb bomb = _bombFactory.Create(_transform);
            IRigidbody rigidbody = new Rigidbody(1.5f, 9.2f, 1.5f, _transform);
            IWeapon grenade = new Grenade(bomb, rigidbody);
            IWeaponData weaponData = new WeaponData(isBurst: false);
            weaponsData.Add(grenade, weaponData);
            return grenade;
        }
    }
}