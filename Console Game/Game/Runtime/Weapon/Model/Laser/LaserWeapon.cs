using System;
using System.Numerics;
using ConsoleGame.Tools;
using ConsoleGame.Physics;

namespace ConsoleGame.Weapons
{
    public sealed class LaserWeapon : IWeapon
    {
        private readonly IRaycast<IEnemy> _raycast;
        private readonly ILaserWeaponView _view;
        private readonly Vector2 _position;
        private readonly Vector2 _shootDirection = new Vector2(1, 0);
        private readonly int _damage;

        public LaserWeapon(IRaycast<IEnemy> raycast, Vector2 position, ILaserWeaponView view, int damage)
        {
            _raycast = raycast ?? throw new ArgumentNullException(nameof(raycast));
            _position = position;
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _damage = damage.ThrowIfLessThanZeroException();
        }

        public bool CanShoot => true;
        
        public void Shoot()
        {
            _raycast.Throw(_position, _shootDirection);
            _view.ShowLaser(_position, _shootDirection);
            
            if (_raycast.HasHit)
            {
                IHealth enemy = _raycast.HitTarget().Health;
                enemy.TakeDamage(_damage);
            }
        }
    }
}