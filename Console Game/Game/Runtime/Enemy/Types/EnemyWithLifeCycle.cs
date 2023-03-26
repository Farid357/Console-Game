using System;

namespace ConsoleGame
{
    public sealed class EnemyWithLifeCycle : IEnemy, IGameLoopObject
    {
        private readonly IEnemyLife _life;
        private readonly IEnemy _enemy;

        public EnemyWithLifeCycle(IEnemyLife life, IEnemy enemy)
        {
            _life = life ?? throw new ArgumentNullException(nameof(life));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public IHealth Health => _enemy.Health;

        public void Update(float deltaTime)
        {
            if (_life.IsCompleted)
            {
                _life.Restart();
            }
        }
    }
}