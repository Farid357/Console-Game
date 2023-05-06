using System;
using System.Linq;
using ConsoleGame.Physics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class Bomb : IBomb
    {
        private readonly IBombView _view;
        private readonly IAreaRaycast<IEnemy> _raycast;
        private readonly IReadOnlyTransform _transform;
        private readonly int _damage;
        
        public Bomb(IBombView view, IAreaRaycast<IEnemy> raycast, IReadOnlyTransform transform, int damage)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _raycast = raycast ?? throw new ArgumentNullException(nameof(raycast));
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _damage = damage.ThrowIfLessThanOrEqualsToZeroException();
        }

        public bool IsBlownUp { get; private set; }
        
        public IWeaponActivityView View => _view;

        public void BlowUp()
        {
            if (IsBlownUp)
                throw new Exception("Bomb is already blown up!");
            
            _raycast.Throw(_transform.Position);

            if (_raycast.HasHits)
            {
                foreach (IHealth health in _raycast.Hits().Select(hit => hit.Target))
                {
                    health.TakeDamage(_damage);
                }
            }
            
            _view.BlowUp();
            IsBlownUp = true;
        }
    }
}