using System;
using Console_Game.Tools.Extensions;

namespace Console_Game
{
    public sealed class EnemyWithReward : IEnemy, IGameLoopObject
    {
        private readonly IReward _reward;
        private readonly IEnemy _enemy;

        public EnemyWithReward(IReward reward, IEnemy enemy)
        {
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public IHealth Health => _enemy.Health;

        public IEnemyMovement Movement => _enemy.Movement;

        public IEnemyData Data => _enemy.Data;

        public void Update(float deltaTime)
        {
            if (_enemy.Health.IsDied() && _reward.IsApplied == false)
                _reward.Apply();
        }
    }
}