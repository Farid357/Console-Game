using System;
using System.Numerics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class AdjustableMovement : IAdjustableMovement
    {
        private readonly IMovement _movement;

        public AdjustableMovement(IMovement movement, float speed)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            Speed = speed.ThrowIfLessOrEqualsToZeroException();
        }
        
        public float Speed { get; private set; }

        public IReadOnlyTransform Transform => _movement.Transform;
        
        public Vector3 LookDirection { get; private set; }

        public void Move(Vector3 direction)
        {
            LookDirection = direction;
            _movement.Move(direction * Speed);
        }

        public void IncreaseSpeed(float speed)
        {
            Speed += speed.ThrowIfLessThanZeroException();
        }

        public void DecreaseSpeed(float speed)
        {
            if (Speed - speed < 0)
                throw new ArgumentOutOfRangeException(nameof(speed));
            
            Speed -= speed.ThrowIfLessThanZeroException();
        }
    }
}