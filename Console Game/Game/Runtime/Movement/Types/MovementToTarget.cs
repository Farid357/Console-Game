using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class MovementToTarget : IIndependentMovement
    {
        private readonly IMovement _movement;
        private readonly IReadOnlyTransform _target;

        public MovementToTarget(IMovement movement, IReadOnlyTransform target)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _target = target ?? throw new ArgumentNullException(nameof(target));
        }

        public IReadOnlyTransform Transform => _movement.Transform;
        
        public void Move()
        {
            Vector3 moveDirection = Vector3.Normalize(_target.Position - Transform.Position);
            _movement.Move(moveDirection);
        }
    }
}