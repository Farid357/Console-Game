using System.Numerics;

namespace ConsoleGame
{
    public interface IMovement : IReadOnlyMovement
    {
        void Move(Vector3 direction);
    }
}