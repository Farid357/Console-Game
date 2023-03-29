using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class EnemyWithReward : IEnemy, IGameObject
    {
        private readonly IReward _reward;
        private readonly IEnemy _enemy;

        public EnemyWithReward(IReward reward, IEnemy enemy)
        {
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public IHealth Health => _enemy.Health;
        
        public IAdjustableMovement Movement => _enemy.Movement;

        public bool IsAlive => _enemy.Health.IsAlive;

        public void Update(float deltaTime)
        {
            if (!IsAlive)
                throw new Exception();
            
            if (_enemy.Health.IsDied() && _reward.IsApplied == false)
                _reward.Apply();
        }
    }
}