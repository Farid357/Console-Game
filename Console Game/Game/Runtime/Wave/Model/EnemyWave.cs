using System;
using System.Collections.Generic;
using System.Numerics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class EnemyWave : IEnemyWave
    {
        private readonly IReadOnlyDictionary<EnemyType, IEnemyFactory> _enemyFactories;
        private readonly IReadOnlyEnemiesWorld _enemiesWorld;
        private readonly IEnemyWaveData _data;

        public EnemyWave(IReadOnlyDictionary<EnemyType, IEnemyFactory> enemyFactories, IReadOnlyEnemiesWorld enemiesWorld, IEnemyWaveData data)
        {
            _enemyFactories = enemyFactories ?? throw new ArgumentNullException(nameof(enemyFactories));
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public bool IsEnded => _enemiesWorld.EverybodyDied;

        public void Start()
        {
            CreateEnemies();
        }

        private void CreateEnemies()
        {
            foreach (var (enemyType, enemiesCount) in _data.Enemies)
            {
                for (var i = 0; i < enemiesCount; i++)
                {
                    Vector3 randomPosition = _data.Positions.GetRandom();
                    ITransform transform = new Transform(randomPosition);
                    IEnemy enemy = _enemyFactories[enemyType].Create(transform);
                }
            }
        }
    }
}