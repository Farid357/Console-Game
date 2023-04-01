using System;

namespace ConsoleGame
{
    public sealed class RandomEnemyFactory : IEnemyFactory
    {
        private readonly IEnemyFactory[] _enemyFactories;
        private readonly Random _random = new Random();

        public RandomEnemyFactory(IEnemyFactory[] enemyFactories)
        {
            _enemyFactories = enemyFactories ?? throw new ArgumentNullException(nameof(enemyFactories));
        }

        public IEnemy Create(ITransform transform)
        {
            IEnemyFactory enemyFactory = _enemyFactories[_random.Next(0, _enemyFactories.Length)];
            return enemyFactory.Create(transform);
        }
    }
}