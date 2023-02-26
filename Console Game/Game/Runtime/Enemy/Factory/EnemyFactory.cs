using System;
using Console_Game.Loop;
using Console_Game.Tools;

namespace Console_Game
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly int _healthCount;
        private readonly IEnemyData _data;
        private readonly IGameUpdate _gameUpdate;

        public EnemyFactory(int healthCount, IEnemyData data, IGameUpdate gameUpdate)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
            _healthCount = healthCount.ThrowIfLessThanOrEqualsToZeroException();
        }

        public IEnemy Create(IReadOnlyTransform transform)
        {
            IHealth health = new Health(new HealthView(), _healthCount);
            var movement = new SmoothMovement(0.1f, 0.1f, new Transform(transform));
            _gameUpdate.Add(movement);
            return new Enemy(health, new AdjustableMovement(movement), _data);
        }
    }
}