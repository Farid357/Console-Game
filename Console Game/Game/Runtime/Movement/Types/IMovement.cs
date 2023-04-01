using System.Numerics;

namespace ConsoleGame
{
    public interface IMovement 
    {
        IReadOnlyTransform Transform { get; }

        void Move(Vector3 direction);

    }
}