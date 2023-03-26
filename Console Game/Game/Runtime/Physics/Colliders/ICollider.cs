using System.Numerics;

namespace ConsoleGame.Physics
{
    public interface ICollider
    {
        Vector3 Center { get; }
        
        bool Contains(Vector3 point);
    }
}