using System;
using ConsoleGame.GameLoop;
using ConsoleGame.Physics;

namespace ConsoleGame.Weapons
{
    public sealed class BulletFactory : IBulletFactory
    {
        private readonly IGameObjectsGroup _gameLoop;
        private readonly IRaycast<IEnemy> _raycast;
        private readonly IMovementFactory _movementFactory;

        public BulletFactory(IReadOnlyCollidersWorld<IEnemy> collidersWorld, IMovementFactory movementFactory, IGameObjectsGroup gameLoop)
        {
            _raycast = new Raycast<IEnemy>(collidersWorld, 0.2f);
            _movementFactory = movementFactory ?? throw new ArgumentNullException(nameof(movementFactory));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }

        public IBullet Create(int damage)
        {
            IMovement movement = _movementFactory.Create(new Transform());
            var bullet = new Bullet(movement, _raycast, new BulletView(), damage);
            _gameLoop.Add(bullet);
            return bullet;
        }
    }
}