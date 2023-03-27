using System;
using System.Numerics;
using ConsoleGame.Physics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly int _health;
        private readonly ICollidersWorld<IEnemy> _collidersWorld;

        public EnemyFactory(int health, ICollidersWorld<IEnemy> collidersWorld)
        {
            _collidersWorld = collidersWorld ?? throw new ArgumentNullException(nameof(collidersWorld));
            _health = health.ThrowIfLessThanOrEqualsToZeroException();
        }

        public IEnemy Create()
        {
            IHealth health = new Health(_health);
            var enemy = new Enemy(health);
            ICollider collider = new BoxCollider(new Box(new Vector3(1.5f, 1.5f, 1.5f)), Vector3.One);
            _collidersWorld.Add(collider, enemy);
            return enemy;
        }
    }
}