using System;
using Console_Game.Loop;
using Console_Game.Physics;

namespace Console_Game.Weapons
{
    public sealed class RaycastBulletsFactory : IBulletsFactory
    {
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;
        private readonly IReadOnlyCollidersWorld<IEnemy> _enemiesWorld;
        private readonly ITransform _transform;

        public RaycastBulletsFactory(IReadOnlyCollidersWorld<IEnemy> enemiesWorld, ITransform transform, IGroup<IGameLoopObject> gameLoopObjects)
        {
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
        }

        public IBullet Create(int damage)
        {
            var enemyRaycast = new Raycast<IEnemy>(_enemiesWorld, 2.5f);
            var movement = new SmoothMovement(0.2f, 0.3f, _transform);
            var bullet = new Bullet(movement, new BulletView());
            var raycastBullet = new RaycastBullet(bullet, enemyRaycast, damage);
            _gameLoopObjects.Add(enemyRaycast);
            _gameLoopObjects.Add(movement);
            _gameLoopObjects.Add(bullet);
            _gameLoopObjects.Add(raycastBullet);
            return raycastBullet;
        }
    }
}