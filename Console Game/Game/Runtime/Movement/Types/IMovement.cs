using System.Numerics;

namespace ConsoleGame
{
    public interface IMovement
    {
        IReadOnlyTransform Transform { get; }
        
        void Move(Vector2 direction);

        void Rotate(Quaternion rotation);
    }
}