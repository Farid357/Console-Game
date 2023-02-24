using System;
using System.Numerics;
using Console_Game.Tools;

namespace Console_Game
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly int _healthCount;
        private readonly IEnemyData _data;

        public EnemyFactory(int healthCount, IEnemyData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _healthCount = healthCount.ThrowIfLessThanOrEqualsToZeroException();
        }

        public IEnemy Create(Vector2 position)
        {
            IHealth health = new Health(new HealthView(), _healthCount);
            IMovement movement = new SmoothMovement(0.1f, 0.1f, new Transform());
            return new Enemy(health, new AdjustableMovement(movement), _data);
        }
    }
}