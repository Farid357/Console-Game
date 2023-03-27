using System;

namespace ConsoleGame
{
    public sealed class EnemyWithRewardFactory : IEnemyFactory
    {
        private readonly IRewardFactory _rewardFactory;
        private readonly IEnemyFactory _enemyFactory;

        public EnemyWithRewardFactory(IRewardFactory rewardFactory, IEnemyFactory enemyFactory)
        {
            _rewardFactory = rewardFactory ?? throw new ArgumentNullException(nameof(rewardFactory));
            _enemyFactory = enemyFactory ?? throw new ArgumentNullException(nameof(enemyFactory));
        }
        
        public IEnemy Create()
        {
            var enemy = new EnemyWithReward(_rewardFactory.Create(), _enemyFactory.Create());
            return enemy;
        }
    }
}