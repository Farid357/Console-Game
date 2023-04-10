using System;
using System.Collections.Generic;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class EnemyWavesFactory : IEnemyWavesFactory
    {
        private readonly IReadOnlyDictionary<EnemyType, IEnemyFactory> _factories;
        private readonly IEnemiesWorld _enemiesWorld;

        public EnemyWavesFactory(IReadOnlyDictionary<EnemyType, IEnemyFactory> factories, IEnemiesWorld enemiesWorld)
        {
            _factories = factories ?? throw new ArgumentNullException(nameof(factories));
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
        }

        public IEnemyWavesQueue Create()
        {
            IReadOnlyList<Vector3> positions = new List<Vector3>
            {
                new Vector3(0, 0, 50),
                new Vector3(10, 0, 50),
                new Vector3(20, 0, 50),
                new Vector3(30, 0, 50),
                new Vector3(40, 0, 50),
                new Vector3(50, 0, 50),
                new Vector3(60, 0, 50),
            };

            IEnemyWave firstEnemyWave = new EnemyWave(_factories, _enemiesWorld, new EnemyWaveData(
                new List<(EnemyType EnemyType, int EnemiesCount)>
                {
                    (EnemyType.Zombie, 10),
                    (EnemyType.Skeleton, 5)
                }, positions));


            IEnemyWave secondEnemyWave = new EnemyWave(_factories, _enemiesWorld, new EnemyWaveData(
                new List<(EnemyType EnemyType, int EnemiesCount)>
                {
                    (EnemyType.Zombie, 15),
                    (EnemyType.Skeleton, 10)
                }, positions));
            
            return new EnemyWavesQueue(new Queue<IEnemyWave>(new List<IEnemyWave>
            {
                firstEnemyWave,
                secondEnemyWave
            }));
        }
    }
}