using System.Numerics;

namespace Console_Game.Physics
{
    public interface ICollider
    {
        Vector3 Center { get; }
        
        bool Contains(Vector3 point);
    }
}