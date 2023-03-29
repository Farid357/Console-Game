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
        
        public IEnemy Create(ITransform transform)
        {
            var enemy = new EnemyWithReward(_rewardFactory.Create(), _enemyFactory.Create(transform));
            return enemy;
        }
    }
}