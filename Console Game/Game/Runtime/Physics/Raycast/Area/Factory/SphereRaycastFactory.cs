using System;

namespace ConsoleGame.Physics.Factory
{
    public sealed class SphereRaycastFactory<TTarget> : IAreaRaycastFactory<TTarget>
    {
        private readonly IReadOnlyCollidersWorld<TTarget> _collidersWorld;

        public SphereRaycastFactory(IReadOnlyCollidersWorld<TTarget> collidersWorld)
        {
            _collidersWorld = collidersWorld ?? throw new ArgumentNullException(nameof(collidersWorld));
        }

        public IAreaRaycast<TTarget> Create()
        {
            return new SphereRaycast<TTarget>(_collidersWorld);
        }
    }
}