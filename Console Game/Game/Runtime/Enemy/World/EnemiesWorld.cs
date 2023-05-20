using ConsoleGame.GameLoop;
using ConsoleGame.Physics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame
{
    public sealed class EnemiesWorld : IEnemiesWorld
    {
        private readonly Dictionary<IEnemy, EnemyType> _enemies;

        public EnemiesWorld(ICollidersWorld<IEnemy> physicsWorld, IGameObjectsGroup gameObjectsGroup)
        {
            PhysicsWorld = physicsWorld ?? throw new ArgumentNullException(nameof(physicsWorld));
            GameObjectsGroup = gameObjectsGroup ?? throw new ArgumentNullException(nameof(gameObjectsGroup));
            _enemies = new Dictionary<IEnemy, EnemyType>();
        }

        public IReadOnlyDictionary<IEnemy, EnemyType> Enemies => _enemies;

        public ICollidersWorld<IEnemy> PhysicsWorld { get; }

        public IGameObjectsGroup GameObjectsGroup { get; }

        public bool EverybodyDied => _enemies.Keys.All(enemy => !enemy.Health.IsAlive);

        public void Add(IEnemy enemy, EnemyType type)
        {
            if (enemy is null)
                throw new ArgumentNullException(nameof(enemy));

            _enemies.Add(enemy, type);
        }
    }
}