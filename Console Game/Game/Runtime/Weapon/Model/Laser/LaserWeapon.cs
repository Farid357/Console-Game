using System;
using System.Numerics;
using ConsoleGame.Tools;
using ConsoleGame.Physics;

namespace ConsoleGame.Weapons
{
    public sealed class LaserWeapon : IWeapon
    {
        private readonly IRaycast<IEnemy> _raycast;
        private readonly ITransform _transform;
        private readonly ILaserWeaponView _view;
        private readonly Vector3 _shootDirection = new Vector3(1, 0, 1);
        private readonly int _damage;

        public LaserWeapon(IRaycast<IEnemy> raycast, ITransform transform, ILaserWeaponView view, int damage)
        {
            _raycast = raycast ?? throw new ArgumentNullException(nameof(raycast));
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _damage = damage.ThrowIfLessThanZeroException();
        }

        public bool CanShoot => true;
        
        public void Shoot()
        {
            _raycast.Throw(_transform.Position, _shootDirection);
            _view.ShowLaser(_transform.Position, _shootDirection);
            
            if (_raycast.HasHit)
            {
                IHealth enemy = _raycast.HitTarget().Health;
                enemy.TakeDamage(_damage);
            }
        }
    }
}