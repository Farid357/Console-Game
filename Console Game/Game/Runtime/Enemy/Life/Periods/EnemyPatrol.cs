using System;
using System.Numerics;

namespace Console_Game
{
    public sealed class EnemyPatrol : IGameLoopObject, IEnemyLifePeriod
    {
        private readonly ICircleMovement _enemyMovement;
        private readonly IReadOnlyTransform _character;

        public EnemyPatrol(ICircleMovement enemyMovement, IReadOnlyTransform character)
        {
            _enemyMovement = enemyMovement ?? throw new ArgumentNullException(nameof(enemyMovement));
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }
        
        public bool IsCompleted { get; private set; }

        public void Update(float deltaTime)
        {
            float distance = Vector2.Distance(_enemyMovement.Transform.Position, _character.Position);

            if (distance <= 2.5f)
            {
                _enemyMovement.Stop();
                IsCompleted = true;
            }
        }

    }
}