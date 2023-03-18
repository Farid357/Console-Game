using System.Numerics;

namespace Console_Game.Tests
{
    public sealed class DummyMovement : IMovement
    {
        public IReadOnlyTransform Transform { get; } = new Transform();
        
        public void Move(Vector2 direction)
        {
            
        }

        public void Rotate(Quaternion rotation)
        {
        }
    }
}