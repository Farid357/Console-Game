using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class EnemyWithReward : IEnemy
    {
        private readonly IReward _reward;
        private readonly IEnemy _enemy;

        public EnemyWithReward(IReward reward, IEnemy enemy)
        {
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public IHealth Health => _enemy.Health;
        
        public bool IsAlive => _enemy.IsAlive;

        public void Update(float deltaTime)
        {
            if (_enemy.Health.IsDied() && _reward.IsApplied == false)
                _reward.Apply();
        }
    }
}