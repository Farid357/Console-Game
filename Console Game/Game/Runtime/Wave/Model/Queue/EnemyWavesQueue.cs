using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame
{
    public sealed class EnemyWavesQueue : IEnemyWavesQueue
    {
        private readonly Queue<IEnemyWave> _waves;
        private readonly IEnemyWave _lastEnemyWave;

        public EnemyWavesQueue(Queue<IEnemyWave> waves)
        {
            _waves = waves;
            _lastEnemyWave = _waves.Last();
        }


        public IEnemyWave GetWave()
        {
            return _waves.Count == 0 ? _lastEnemyWave : _waves.Dequeue();
        }
    }
}