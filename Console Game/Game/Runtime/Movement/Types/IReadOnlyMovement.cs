using System.Numerics;

namespace ConsoleGame
{
    public interface IReadOnlyMovement
    {
        IReadOnlyTransform Transform { get; }
        
        Vector3 LookDirection { get; }
    }
}