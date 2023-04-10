using System;
using ConsoleGame.GameLoop;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class ShooterEnemyFactory : IEnemyFactory
    {
        private readonly IWeaponFactory _weaponFactory;
        private readonly IReadOnlyCharacter _character;
        private readonly IHealthFactory _healthFactory;
        private readonly IMovementFactory _movementFactory;
        private readonly IGameObjectsGroup _gameObjects;

        public ShooterEnemyFactory(IWeaponFactory weaponFactory, IReadOnlyCharacter character,
            IHealthFactory healthFactory, IMovementFactory movementFactory, IGameObjectsGroup gameObjects)
        {
            _weaponFactory = weaponFactory ?? throw new ArgumentNullException(nameof(weaponFactory));
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _healthFactory = healthFactory ?? throw new ArgumentNullException(nameof(healthFactory));
            _movementFactory = movementFactory ?? throw new ArgumentNullException(nameof(movementFactory));
            _gameObjects = gameObjects ?? throw new ArgumentNullException(nameof(gameObjects));
        }

        public IEnemy Create(ITransform transform)
        {
            IHealth health = _healthFactory.Create();
            IMovement movement = _movementFactory.Create(transform);
            IAim aim = new EnemyAim(transform, _character.Transform);
            IWeapon weapon = _weaponFactory.Create(aim).Weapon;
            var enemy = new ShooterEnemy(health, movement, weapon, _character);
            _gameObjects.Add(enemy);
            return enemy;
        }
    }
}