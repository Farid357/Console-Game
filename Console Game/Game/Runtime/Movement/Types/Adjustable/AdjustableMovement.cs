using System;
using System.Numerics;

namespace Console_Game
{
    public sealed class AdjustableMovement : IAdjustableMovement
    {
        private readonly IMovement _movement;
        private readonly IPause _pause;

        public AdjustableMovement(IMovement movement, IPause pause)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _pause = pause ?? throw new ArgumentNullException(nameof(pause));
        }

        public bool IsActive => _pause.IsActive;

        public IReadOnlyTransform Transform => _movement.Transform;

        public void Move(Vector2 direction)
        {
            if (IsActive == false)
                throw new InvalidOperationException($"is not active, so you can't move it!");
            
            _movement.Move(direction);
        }

        public void Rotate(Quaternion rotation)
        {
            if (IsActive == false)
                throw new InvalidOperationException($"is not active, so you can't rotate it!");
            
            _movement.Rotate(rotation);
        }

        public void Continue() => _pause.Enable();

        public void Stop() => _pause.Disable();
        
    }
}