using System.Numerics;

namespace Console_Game.Physics
{
    public interface IRaycast<TTarget>
    {
        bool HasHit { get; }
        
        RaycastHit<TTarget> Hit();

        void Throw(Vector3 origin, Vector3 direction);
    }
}