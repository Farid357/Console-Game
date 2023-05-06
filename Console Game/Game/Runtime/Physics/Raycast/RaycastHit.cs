using System;
using System.Numerics;

namespace ConsoleGame.Physics
{
    public readonly struct RaycastHit<TTarget>
    {
        private readonly TTarget _target;

        public RaycastHit(TTarget target, Vector3 hitPoint, ICollider collider)
        {
            _target = target;
            HitPoint = hitPoint;
            Collider = collider;
        }

        public bool Occurred => _target != null;

        public ICollider Collider { get; }

        public Vector3 HitPoint { get; }

        public TTarget Target
        {
            get
            {
                if (!Occurred)
                    throw new Exception($"There isn't hit target!");

                return _target;
            }
        }
    }
}