using System;
using System.Numerics;
using ConsoleGame.Physics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly IHealthViewFactory _viewFactory;
        private readonly ICollidersWorld<IEnemy> _collidersWorld;
        private readonly int _health;

        public EnemyFactory(int health, IHealthViewFactory viewFactory, ICollidersWorld<IEnemy> collidersWorld)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _collidersWorld = collidersWorld ?? throw new ArgumentNullException(nameof(collidersWorld));
            _health = health.ThrowIfLessThanOrEqualsToZeroException();
        }

        public IEnemy Create()
        {
            IHealth health = new Health(_viewFactory.Create(), _health);
            var enemy = new Enemy(health);
            ICollider collider = new BoxCollider(new Box(new Vector3(1.5f, 1.5f, 1.5f)), Vector3.One);
            _collidersWorld.Add(collider, enemy);
            return enemy;
        }
    }
}