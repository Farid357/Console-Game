using System;
using System.Numerics;

namespace ConsoleGame.Physics
{
    public sealed class Raycast<TTarget> : IRaycast<TTarget>
    {
        private readonly IReadOnlyCollidersWorld<TTarget> _collidersWorld;
        private readonly float _maxDistance;

        public Raycast(IReadOnlyCollidersWorld<TTarget> collidersWorld, float maxDistance = 1000)
        {
            _collidersWorld = collidersWorld ?? throw new ArgumentNullException(nameof(collidersWorld));
            _maxDistance = maxDistance;
        }

        public RaycastHit<TTarget> Throw(Vector3 origin, Vector3 direction)
        {
            Vector3 lastPoint = origin + direction * _maxDistance;
            Vector3 currentPosition = origin;
            
            while (true)
            {
                currentPosition += direction / 100f;
                
                foreach (var models in _collidersWorld.Colliders)
                {
                    ICollider collider = models.Value;
                    TTarget target = models.Key;

                    if (collider.Contains(currentPosition))
                    {
                        return new RaycastHit<TTarget>(target, currentPosition);
                    }
                }

                if (currentPosition.X > lastPoint.X || currentPosition.Y > lastPoint.Y)
                    return new RaycastHit<TTarget>();
                
            }
        }
    }
}