using System;
using Console_Game.Loop;

namespace Console_Game
{
    public sealed class EnemyWithRewardFactory : IEnemyFactory
    {
        private readonly IReward _reward;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IGameUpdate _gameUpdate;

        public EnemyWithRewardFactory(IReward reward, IEnemyFactory enemyFactory, IGameUpdate gameUpdate)
        {
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
            _enemyFactory = enemyFactory ?? throw new ArgumentNullException(nameof(enemyFactory));
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
        }
        

        public IEnemy Create(IReadOnlyTransform transform)
        {
            var enemy = new EnemyWithReward(_reward, _enemyFactory.Create(transform));
            _gameUpdate.Add(enemy);
            return enemy;
        }
    }
}