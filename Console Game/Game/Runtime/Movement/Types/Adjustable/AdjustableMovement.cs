using System;
using System.Numerics;

namespace Console_Game
{
    public sealed class AdjustableMovement : IAdjustableMovement
    {
        private readonly IMovement _movement;

        public AdjustableMovement(IMovement movement)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
        }

        public bool IsActive { get; private set; }

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

        public void Continue()
        {
            if (IsActive)
                throw new InvalidOperationException($"Already can move!");
            
            IsActive = true;
        }

        public void Stop()
        {
            if (IsActive == false)
                throw new InvalidOperationException($"Already stopped!");
            
            IsActive = false;
        }
    }
}