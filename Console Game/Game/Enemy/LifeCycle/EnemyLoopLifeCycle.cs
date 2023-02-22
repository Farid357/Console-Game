using System;

namespace Console_Game
{
    public sealed class EnemyLoopLifeCycle : IEnemyLifeCycle, IGameLoopObject
    {
        private readonly IEnemyLifeCycle _enemyLifeCycle;

        public EnemyLoopLifeCycle(IEnemyLifeCycle enemyLifeCycle)
        {
            _enemyLifeCycle = enemyLifeCycle ?? throw new ArgumentNullException(nameof(enemyLifeCycle));
        }

        public bool IsCompleted => false;

        public IEnemyLifeCyclePeriod CurrentPeriod => _enemyLifeCycle.CurrentPeriod;
        
        public void Continue() => _enemyLifeCycle.Continue();

        public void Restart() => _enemyLifeCycle.Restart();

        public void Stop() => _enemyLifeCycle.Stop();

        public void Update(float deltaTime)
        {
            if(_enemyLifeCycle.IsCompleted)
                _enemyLifeCycle.Restart();
        }
    }
}