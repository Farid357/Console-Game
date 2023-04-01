using System;
using System.Numerics;

namespace ConsoleGame.Physics
{
    public struct RaycastHit<TTarget>
    {
        private readonly TTarget _target;

        public RaycastHit(TTarget target, Vector3 hitPoint)
        {
            _target = target;
            HitPoint = hitPoint;
        }

        public bool Occurred => _target != null;

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