using System;
using System.Collections.Generic;

namespace ConsoleGame.Wave
{
    public sealed class WaveFactory : IGameLoopObject
    {
        private readonly IEnemiesWorld _enemiesWorld;
        private readonly IReadOnlyDictionary<EnemyType, IEnemyFactory> _enemyFactories;
        private readonly IReadOnlyList<IWaveData> _waveData;
        private int _waveIndex;

        public WaveFactory(IEnemiesWorld enemiesWorld, IReadOnlyDictionary<EnemyType, IEnemyFactory> enemyFactories, IReadOnlyList<IWaveData> waveData)
        {
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _enemyFactories = enemyFactories ?? throw new ArgumentNullException(nameof(enemyFactories));
            _waveData = waveData ?? throw new ArgumentNullException(nameof(waveData));
        }

        private IWaveData CurrentWaveData => _waveData[_waveIndex];

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
            foreach (var (enemyType, enemiesCount) in CurrentWaveData.Enemies)
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