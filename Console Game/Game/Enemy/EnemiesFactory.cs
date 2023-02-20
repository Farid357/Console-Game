using System;
using System.Numerics;
using Console_Game.Tools.Extensions;

namespace Console_Game
{
    public sealed class EnemiesFactory : IFactory<IEnemy>
    {
        private readonly Vector2[] _positions;
        private readonly int _health;
        private int _positionIndex;

        public EnemiesFactory(Vector2[] positions, int health)
        {
            _positions = positions ?? throw new ArgumentNullException(nameof(positions));
            _health = health.ThrowIfLessThanOrEqualsToZeroException();
        }

        public IEnemy Create()
        {
            _positionIndex++;

            if (_positionIndex > _positions.Length)
                _positionIndex = 0;

            IHealth health = new Health(new EnemyHealthView(), _health);
            return new Enemy(health, Vector2.Zero);
        }
    }
}