using System.Numerics;

namespace Console_Game.Physics
{
    public struct RaycastHit<TTarget>
    {
        public RaycastHit(TTarget target, Vector3 hitPoint)
        {
            Target = target;
            HitPoint = hitPoint;
        }

        public TTarget Target { get; }
        
        public Vector3 HitPoint { get; }

    }
}