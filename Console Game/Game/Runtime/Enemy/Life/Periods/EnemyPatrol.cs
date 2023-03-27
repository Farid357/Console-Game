using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class EnemyPatrol : IGameLoopObject, IEnemyLifePeriod
    {
        private readonly ICircleMovement _movement;
        private readonly IReadOnlyTransform _character;

        public EnemyPatrol(ICircleMovement movement, IReadOnlyTransform character)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }
        
        public bool IsCompleted { get; private set; }

        public void Update(float deltaTime)
        {
            if(IsCompleted)
                return;
            
            _movement.Continue();
            _movement.Move();
            
            float distance = Vector3.Distance(_movement.Transform.Position, _character.Position);

            if (distance <= 2.5f)
            {
                _movement.Stop();
                IsCompleted = true;
            }
        }

    }
}