using System.Collections.Generic;
using System.Numerics;

namespace ConsoleGame.Physics
{
    public interface IAreaRaycast<TTarget>
    {
        bool HasHits { get; }

        IReadOnlyList<RaycastHit<TTarget>> Hits();
        
        void Throw(Vector3 origin);
    }
}