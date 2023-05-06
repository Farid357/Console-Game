using System;
using System.Numerics;
using ConsoleGame.Physics;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class ShooterEnemyFactory : IEnemyFactory
    {
        private readonly IWeaponFactory _weaponFactory;
        private readonly IReadOnlyCharacter _character;
        private readonly IHealthFactory _healthFactory;
        private readonly IMovementFactory _movementFactory;
        private readonly IEnemiesWorld _enemiesWorld;

        public ShooterEnemyFactory(IWeaponFactory weaponFactory, IReadOnlyCharacter character,
            IHealthFactory healthFactory, IMovementFactory movementFactory, IEnemiesWorld enemiesWorld)
        {
            _weaponFactory = weaponFactory ?? throw new ArgumentNullException(nameof(weaponFactory));
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _healthFactory = healthFactory ?? throw new ArgumentNullException(nameof(healthFactory));
            _movementFactory = movementFactory ?? throw new ArgumentNullException(nameof(movementFactory));
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
        }

        public IEnemy Create(ITransform transform)
        {
            IHealth health = _healthFactory.Create();
            IMovement movement = _movementFactory.Create(transform);
            IAim aim = new EnemyAim(transform, _character.Transform);
            IWeapon weapon = _weaponFactory.Create(aim).Weapon;
            var enemy = new ShooterEnemy(health, movement, weapon, _character);
            ICollider collider = new BoxCollider(Vector3.One, transform);
            _enemiesWorld.Add(enemy, EnemyType.Shooter);
            _enemiesWorld.GameObjectsGroup.Add(enemy);
            _enemiesWorld.PhysicsWorld.Add(enemy, collider);
            return enemy;
        }
    }
}