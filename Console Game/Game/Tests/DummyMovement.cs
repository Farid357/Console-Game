using System.Numerics;

namespace ConsoleGame.Tests
{
    public sealed class DummyMovement : IMovement
    {
        public IReadOnlyTransform Transform { get; } = new Transform();

        public void Move(Vector3 direction)
        {
            
        }

    }
}