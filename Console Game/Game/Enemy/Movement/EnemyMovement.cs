using System;
using System.Numerics;

namespace Console_Game
{
    public sealed class EnemyMovement : IEnemyMovement
    {
        private readonly IEnemyMovementView _view;
        
        public EnemyMovement(Vector2 position, IEnemyMovementView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            Position = position;
        }

        public bool CanMove { get; private set; }
        
        public Vector2 Position { get; private set; }
        
        public Vector2 MoveDirection { get; private set; }

        public void Continue()
        {
            if (CanMove)
                throw new InvalidOperationException($"Already can move!");
            
            CanMove = true;
        }

        public void Stop()
        {
            if (CanMove == false)
                throw new InvalidOperationException($"Already stopped!");
            
            CanMove = false;
        }

        public void TeleportTo(Vector2 point)
        {
            if (Position == point)
                throw new InvalidOperationException($"Enemy already in {point}");

            Position = point;
            _view.Visualize(Position);
        }

        public void Move(Vector2 direction)
        {
            if (CanMove == false)
                throw new InvalidOperationException($"Can't move!");

            MoveDirection = direction;
            Position = Vector2.Lerp(Position, Position + MoveDirection, 0.1f);
            _view.Visualize(Position);
        }
    }
}