using System;

namespace ConsoleGame
{
    public sealed class EnemyWavesLoop : IGameLoopObject
    {
        private readonly IEnemyWavesQueue _wavesQueue;
        private IEnemyWave _enemyWave;
        
        public EnemyWavesLoop(IEnemyWavesQueue wavesQueue)
        {
            _wavesQueue = wavesQueue ?? throw new ArgumentNullException(nameof(wavesQueue));
            _enemyWave = _wavesQueue.GetWave();
        }

        public void Update(float deltaTime)
        {
            if (_enemyWave.IsEnded)
                StartNextWave();
        }

        private void StartNextWave()
        {
            _enemyWave = _wavesQueue.GetWave();
            _enemyWave.Start();
        }
    }
}