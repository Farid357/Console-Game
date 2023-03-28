using System;
using System.Collections.Generic;
using System.Numerics;

namespace ConsoleGame.Physics
{
    public sealed class SphereRaycast<TTarget> : IAreaRaycast<TTarget>
    {
        private readonly List<RaycastHit<TTarget>> _hits;
        private readonly IReadOnlyCollidersWorld<TTarget> _collidersWorld;
        
        public SphereRaycast(IReadOnlyCollidersWorld<TTarget> collidersWorld)
        {
            _collidersWorld = collidersWorld ?? throw new ArgumentNullException(nameof(collidersWorld));
            _hits = new List<RaycastHit<TTarget>>();
        }

        public bool HasHits { get; }
        
        public IReadOnlyList<RaycastHit<TTarget>> Hits()
        {
            if (HasHits == false)
                throw new Exception($"Raycast doesn't have hits!");

            return _hits;
        }

        public void Throw(Vector3 origin)
        {
            //TODO
        }
    }
}