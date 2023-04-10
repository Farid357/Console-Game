using System;
using ConsoleGame.Physics;

namespace ConsoleGame.Weapons
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

        public (IWeapon Weapon, IWeaponParts PartsData) Create(IAim aim)
        {
            IBomb bomb = _bombFactory.Create(_transform);
            IRigidbody rigidbody = new Rigidbody(1.5f, 9.2f, 1.5f, _transform);
            IWeapon grenade = new Grenade(bomb, rigidbody);
            IWeaponParts parts = new WeaponParts(isBurst: false);
            return (grenade, parts);
        }
    }
}