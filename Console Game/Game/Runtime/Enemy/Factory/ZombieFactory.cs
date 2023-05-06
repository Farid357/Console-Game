using ConsoleGame.Physics;
using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class ZombieFactory : IEnemyFactory
    {
        private readonly IReadOnlyCharacter _character;
        private readonly IHealthFactory _healthFactory;
        private readonly IMovementFactory _movementFactory;
        private readonly IEnemiesWorld _enemiesWorld;

        public ZombieFactory(IReadOnlyCharacter character, IHealthFactory healthFactory, IMovementFactory movementFactory, IEnemiesWorld enemiesWorld)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _healthFactory = healthFactory ?? throw new ArgumentNullException(nameof(healthFactory));
            _movementFactory = movementFactory ?? throw new ArgumentNullException(nameof(movementFactory));
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
        }

        public IEnemy Create(ITransform transform)
        {
            IHealth health = _healthFactory.Create();
            IMovement movement = _movementFactory.Create(transform);
            var zombie = new Zombie(health, movement, _character);
            ICollider collider = new BoxCollider(Vector3.One, transform);
            _enemiesWorld.Add(zombie, EnemyType.Zombie);
            _enemiesWorld.PhysicsWorld.Add(zombie, collider);
            _enemiesWorld.GameObjectsGroup.Add(zombie);
            return zombie;
        }
    }
}