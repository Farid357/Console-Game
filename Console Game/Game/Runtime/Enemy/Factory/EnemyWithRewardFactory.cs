using System;
using ConsoleGame.Loop;

namespace ConsoleGame
{
    public sealed class EnemyWithRewardFactory : IEnemyFactory
    {
        private readonly IReward _reward;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;

        public EnemyWithRewardFactory(IReward reward, IEnemyFactory enemyFactory, IGroup<IGameLoopObject> gameLoopObjects)
        {
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
            _enemyFactory = enemyFactory ?? throw new ArgumentNullException(nameof(enemyFactory));
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
        }
        
        public IEnemy Create(ITransform transform)
        {
            var enemy = new EnemyWithReward(_reward, _enemyFactory.Create(transform));
            _gameLoopObjects.Add(enemy);
            return enemy;
        }
    }
}