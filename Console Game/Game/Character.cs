using System.Numerics;

namespace Console_Game
{
    public sealed class Character
    {
    }

    public sealed class CharacterMovement
    {
        public bool IsActive { get; }
        public Vector2 Position { get; }

        public void Continue()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }

        public void TeleportTo(Vector2 point)
        {
            throw new System.NotImplementedException();
        }

        public void Move(Vector2 direction)
        {
            throw new System.NotImplementedException();
        }
    }
}