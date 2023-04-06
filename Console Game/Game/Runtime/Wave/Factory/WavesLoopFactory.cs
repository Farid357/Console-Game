using System;
using System.Collections.Generic;

namespace ConsoleGame.Wave
{
    public sealed class WavesLoopFactory : IGameLoopObject
    {
        private readonly IEnemiesWorld _enemiesWorld;
        private readonly IReadOnlyDictionary<EnemyType, IEnemyFactory> _enemyFactories;
        private readonly IReadOnlyList<IWave> _waves;
        private int _waveIndex;

        public WavesLoopFactory(IEnemiesWorld enemiesWorld, IReadOnlyDictionary<EnemyType, IEnemyFactory> enemyFactories, IReadOnlyList<IWave> waveData)
        {
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _enemyFactories = enemyFactories ?? throw new ArgumentNullException(nameof(enemyFactories));
            _waves = waveData ?? throw new ArgumentNullException(nameof(waveData));
        }

        private IWave CurrentWave => _waves[_waveIndex];

        public void Update(float deltaTime)
        {
            if (_enemiesWorld.EverybodyDied)
            {
                _enemiesWorld.Clear();
                CreateWave();
            }
        }

        private void CreateWave()
        {
            foreach (var (enemyType, enemiesCount) in CurrentWave.Enemies)
            {
                for (var i = 0; i < enemiesCount; i++)
                {
                    IEnemy enemy = _enemyFactories[enemyType].Create(new Transform());
                    _enemiesWorld.Add(enemy, enemyType);
                }
            }

            _waveIndex++;
        }
    }
}