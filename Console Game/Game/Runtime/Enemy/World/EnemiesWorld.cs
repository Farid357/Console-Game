using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class EnemiesWorld : IEnemiesWorld
    {
        private readonly Dictionary<IEnemy, EnemyType> _enemies;

        public EnemiesWorld()
        {
            _enemies = new Dictionary<IEnemy, EnemyType>();
        }

        public IReadOnlyDictionary<IEnemy, EnemyType> Enemies => _enemies;

        public bool EverybodyDied => _enemies.Keys.All(enemy => !enemy.Health.IsAlive);

        public void Add(IEnemy enemy, EnemyType type)
        {
            _enemies.Add(enemy, type);
        }

        public void Clear()
        {
            _enemies.Clear();
        }
    }
}