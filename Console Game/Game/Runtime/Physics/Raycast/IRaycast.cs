using System.Numerics;

namespace ConsoleGame.Physics
{
    public interface IRaycast<TTarget>
    {
        RaycastHit<TTarget> Throw(Vector3 origin, Vector3 direction, Layer? layerMask = null);
        
    }
}