using System;
using ConsoleGame.GameLoop;
using ConsoleGame.Physics;

namespace ConsoleGame.Weapons
{
    public sealed class RaycastBulletFactory : IBulletFactory
    {
        private readonly IGameObjectsGroup _gameLoop;
        private readonly IRaycast<IHealth> _raycast;
        private readonly IMovementFactory _movementFactory;

        public RaycastBulletFactory(IRaycast<IHealth> raycast, IMovementFactory movementFactory, IGameObjectsGroup gameLoop)
        {
            _raycast = raycast ?? throw new ArgumentNullException(nameof(raycast));
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