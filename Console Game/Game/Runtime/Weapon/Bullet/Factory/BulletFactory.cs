using System;
using ConsoleGame.GameLoop;
using ConsoleGame.Physics;

namespace ConsoleGame.Weapons
{
    public sealed class RaycastBulletFactory : IBulletFactory
    {
        private readonly IGameObjectsGroup _gameLoop;
        private readonly IRaycast<IEnemy> _enemyRaycast;
        private readonly IMovementFactory _movementFactory;

        public RaycastBulletFactory(IRaycast<IEnemy> enemyRaycast, IMovementFactory movementFactory, IGameObjectsGroup gameLoop)
        {
            _enemyRaycast = enemyRaycast ?? throw new ArgumentNullException(nameof(enemyRaycast));
            _movementFactory = movementFactory ?? throw new ArgumentNullException(nameof(movementFactory));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }

        public IBullet Create(int damage)
        {
            IMovement movement = _movementFactory.Create(new Transform());
            var bullet = new Bullet(movement, _enemyRaycast, new BulletView(), damage);
            _gameLoop.Add(bullet);
            return bullet;
        }
    }
}