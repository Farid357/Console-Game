using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly int _healthCount;
        private readonly IGroup<IGameObject> _gameObjects;

        public EnemyFactory(int healthCount, IGroup<IGameObject> gameObjects)
        {
            _gameObjects = gameObjects ?? throw new ArgumentNullException(nameof(gameObjects));
            _healthCount = healthCount.ThrowIfLessThanOrEqualsToZeroException();
        }

        public IEnemy Create(ITransform transform)
        {
            IHealth health = new Health(new HealthView(), _healthCount);
            var enemy = new Enemy(health);
            _gameObjects.Add(enemy);
            return enemy;
        }
    }
}