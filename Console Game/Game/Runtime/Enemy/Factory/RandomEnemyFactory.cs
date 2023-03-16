using System;
using System.Numerics;

namespace Console_Game
{
    public sealed class RandomEnemyFactory : IFactory<IEnemy>
    {
        private readonly IEnemyFactory[] _enemyFactories;
        private readonly Vector2[] _positions;
        private readonly Random _random = new Random();
        private int _positionIndex;

        public RandomEnemyFactory(Vector2[] positions, IEnemyFactory[] enemyFactories)
        {
            _positions = positions ?? throw new ArgumentNullException(nameof(positions));
            _enemyFactories = enemyFactories ?? throw new ArgumentNullException(nameof(enemyFactories));
        }

        public IEnemy Create()
        {
            _positionIndex++;

            if (_positionIndex > _positions.Length)
                _positionIndex = 0;

            Vector2 position = _positions[_positionIndex];
            IEnemyFactory enemyFactory = _enemyFactories[_random.Next(0, _enemyFactories.Length)];
            return enemyFactory.Create(new ReadOnlyTransform(position));
        }
    }
}