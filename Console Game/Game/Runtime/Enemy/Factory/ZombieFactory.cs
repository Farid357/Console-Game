using System;
using ConsoleGame.GameLoop;

namespace ConsoleGame
{
    public sealed class ZombieFactory : IEnemyFactory
    {
        private readonly IReadOnlyCharacter _character;
        private readonly IHealthFactory _healthFactory;
        private readonly IMovementFactory _movementFactory;
        private readonly IGameObjectsGroup _gameObjects;

        public ZombieFactory(IReadOnlyCharacter character, IHealthFactory healthFactory, IMovementFactory movementFactory, IGameObjectsGroup gameObjects)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _healthFactory = healthFactory ?? throw new ArgumentNullException(nameof(healthFactory));
            _movementFactory = movementFactory ?? throw new ArgumentNullException(nameof(movementFactory));
            _gameObjects = gameObjects ?? throw new ArgumentNullException(nameof(gameObjects));
        }

        public IEnemy Create(ITransform transform)
        {
            IHealth health = _healthFactory.Create();
            IMovement movement = _movementFactory.Create(transform);
            var zombie = new Zombie(health, movement, _character);
            _gameObjects.Add(zombie);
            return zombie;
        }
    }
}