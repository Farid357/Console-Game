using System.Numerics;

namespace Console_Game
{
    public interface IMovement
    {
        IReadOnlyTransform Transform { get; }
        
        void Move(Vector2 direction);

        void Rotate(Quaternion rotation);
    }
}