using System;
using System.Numerics;

namespace Console_Game
{
    public sealed class AdjustableMovement : IAdjustableMovement
    {
        private readonly IMovement _movement;
        private readonly IGamePause _gamePause;

        public AdjustableMovement(IMovement movement, IGamePause gamePause)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _gamePause = gamePause ?? throw new ArgumentNullException(nameof(gamePause));
        }

        public bool IsActive => _gamePause.IsActive;

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

        public void Continue() => _gamePause.Enable();

        public void Stop() => _gamePause.Disable();
        
    }
}