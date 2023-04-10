using System;
using ConsoleGame.GameLoop;
using ConsoleGame.Physics;

namespace ConsoleGame.Weapons
{
    public sealed class BulletFactory : IBulletFactory
    {
        private readonly IGameObjectsGroup _gameLoop;
        private readonly IRaycast<IHealth> _raycast;
        private readonly IMovementFactory _movementFactory;
        private readonly Layer? _layerMask;

        public BulletFactory(IReadOnlyCollidersWorld<IHealth> collidersWorld, IMovementFactory movementFactory, IGameObjectsGroup gameLoop, Layer? layerMask)
        {
            _raycast = new Raycast<IHealth>(collidersWorld, 0.2f);
            _movementFactory = movementFactory ?? throw new ArgumentNullException(nameof(movementFactory));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _layerMask = layerMask;
        }

        public IBullet Create(int damage)
        {
            IMovement movement = _movementFactory.Create(new Transform());
            var bullet = new Bullet(movement, _raycast, new BulletView(), _layerMask, damage);
            _gameLoop.Add(bullet);
            return bullet;
        }
    }
}