using System;

namespace Console_Game
{
    public sealed class EnemyWithLifeCycle : IEnemy, IGameLoopObject
    {
        private readonly IEnemyLifeCycle _lifeCycle;
        private readonly IEnemy _enemy;

        public EnemyWithLifeCycle(IEnemyLifeCycle lifeCycle, IEnemy enemy)
        {
            _lifeCycle = lifeCycle ?? throw new ArgumentNullException(nameof(lifeCycle));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public IHealth Health => _enemy.Health;

        public IEnemyMovement Movement => _enemy.Movement;

        public IEnemyData Data => _enemy.Data;

        public void Update(float deltaTime)
        {
            _lifeCycle.Update(deltaTime);
        }
    }
}