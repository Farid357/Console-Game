using System.Numerics;

namespace ConsoleGame.Physics
{
    public interface ICollider
    {
        IReadOnlyTransform Transform { get; }
        
        bool Contains(Vector3 point);
    }
}