using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ConsoleGame.Physics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class EnemiesWorld : IEnemiesWorld
    {
        private readonly ICollidersWorld<IEnemy> _collidersWorld;
        private readonly Dictionary<IEnemy, EnemyType> _enemies;

        public EnemiesWorld(ICollidersWorld<IEnemy> collidersWorld)
        {
            _collidersWorld = collidersWorld ?? throw new ArgumentNullException(nameof(collidersWorld));
            _enemies = new Dictionary<IEnemy, EnemyType>();
        }

        public IReadOnlyDictionary<IEnemy, EnemyType> Enemies => _enemies;

        public bool EverybodyDied => _enemies.Keys.All(enemy => !enemy.Health.IsAlive);

        public void Add(IEnemy enemy, EnemyType type)
        {
            _enemies.Add(enemy, type);
            ICollider collider = new BoxCollider(new Box(new Vector3(1.5f, 1.5f, 1.5f)), Vector3.One);
            _collidersWorld.Add(enemy, collider);
        }

        public void Clear()
        {
            _enemies.Clear();
            _collidersWorld.Clear();
        }
    }
}