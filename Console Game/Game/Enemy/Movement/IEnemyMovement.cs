using System.Numerics;

namespace Console_Game
{
    public interface IEnemyMovement
    {
        bool CanMove { get; }
        
        Vector2 Position { get; }
        
        Vector2 MoveDirection { get; }

        void Continue();

        void Stop();
        
        void TeleportTo(Vector2 point);

        void Move(Vector2 direction);
    }
}