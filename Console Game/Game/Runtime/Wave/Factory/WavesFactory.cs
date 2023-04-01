using System.Collections.Generic;

namespace ConsoleGame.Wave
{
    public sealed class WavesFactory : IWavesFactory
    {
        public List<IWave> Create()
        {
            IWave firstWave = new Wave(new List<(EnemyType EnemyType, int EnemiesCount)>()
            {
                (EnemyType.Zombie, 10),
                (EnemyType.Golem, 5)
            });

            IWave secondWave = new Wave(new List<(EnemyType EnemyType, int EnemiesCount)>()
            {
                (EnemyType.Orc, 2),
                (EnemyType.Zombie, 20)
            });

            return new List<IWave>
            {
                firstWave,
                secondWave
            };
        }
    }
}