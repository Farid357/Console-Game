using System;
using System.Numerics;

namespace ConsoleGame.Physics
{
    //TODO Raycast
    public sealed class Raycast<TTarget> : IGameLoopObject, IRaycast<TTarget>
    {
        private readonly IReadOnlyCollidersWorld<TTarget> _collidersWorld;
        private readonly float _maxDistance;
        private RaycastHit<TTarget> _hit;
        private Vector3 _position;

        public Raycast(IReadOnlyCollidersWorld<TTarget> collidersWorld, float maxDistance = 1000)
        {
            _collidersWorld = collidersWorld ?? throw new ArgumentNullException(nameof(collidersWorld));
            _maxDistance = maxDistance;
            _hit = new RaycastHit<TTarget>();
        }

        public bool HasHit => _hit.Target != null;

        public RaycastHit<TTarget> Hit()
        {
            if (HasHit == false)
                throw new InvalidOperationException($"Raycast hasn't hit");

            return _hit;
        }

        public void Throw(Vector3 origin, Vector3 direction)
        {
            _position = CalculateNextPosition(origin, direction);

            foreach (var models in _collidersWorld.Colliders)
            {
                ICollider collider = models.Value;
                TTarget target = models.Key;

                if (collider.Contains(_position))
                {
                    _hit = new RaycastHit<TTarget>(target, _position);
                }
            }
        }

        public void Update(float deltaTime)
        {
        }

        private Vector3 CalculateNextPosition(Vector3 origin, Vector3 direction)
        {
            Vector3 nextPosition;
            
            if (Vector3.Distance(origin, _position) <= _maxDistance)
            {
                nextPosition = origin;
            }

            else
            {
                nextPosition = _position + direction;
            }

            return nextPosition;
        }
    }
}