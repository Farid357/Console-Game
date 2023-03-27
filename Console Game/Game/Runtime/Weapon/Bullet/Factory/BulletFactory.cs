using System;
using ConsoleGame.Loop;
using ConsoleGame.Physics;

namespace ConsoleGame.Weapons
{
    public sealed class RaycastBulletFactory : IBulletFactory
    {
        private readonly IGameObjectsGroup _gameLoop;
        private readonly IRaycastFactory<IEnemy> _raycastFactory;
        private readonly IMovementFactory _movementFactory;

        public RaycastBulletFactory(IRaycastFactory<IEnemy> raycastFactory, IMovementFactory movementFactory, IGameObjectsGroup gameLoop)
        {
            _raycastFactory = raycastFactory ?? throw new ArgumentNullException(nameof(raycastFactory));
            _movementFactory = movementFactory ?? throw new ArgumentNullException(nameof(movementFactory));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }

        public IBullet Create(int damage)
        {
            IRaycast<IEnemy> enemyRaycast = _raycastFactory.Create();
            IMovement movement = _movementFactory.Create(new Transform());
            var bullet = new Bullet(movement, enemyRaycast, new BulletView(), damage);
            _gameLoop.Add(bullet);
            return bullet;
        }
    }
}