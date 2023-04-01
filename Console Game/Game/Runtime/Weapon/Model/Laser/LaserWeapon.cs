using System;
using ConsoleGame.Tools;
using ConsoleGame.Physics;

namespace ConsoleGame.Weapons
{
    public sealed class LaserWeapon : IWeapon
    {
        private readonly IRaycast<IEnemy> _raycast;
        private readonly IAim _aim;
        private readonly ILaserWeaponView _view;
        private readonly int _damage;

        public LaserWeapon(IRaycast<IEnemy> raycast, IAim aim, ILaserWeaponView view, int damage)
        {
            _raycast = raycast ?? throw new ArgumentNullException(nameof(raycast));
            _aim = aim ?? throw new ArgumentNullException(nameof(aim));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _damage = damage.ThrowIfLessThanZeroException();
        }

        public bool CanShoot => View.IsActive;
        
        public IWeaponActivityView View => _view;

        public void Shoot()
        {
            if (CanShoot == false)
                throw new Exception($"Weapon can't shoot! View is not active!");
            
            RaycastHit<IEnemy> hit = _raycast.Throw(_aim.Position, _aim.Target);
            _view.ShowLaser(_aim.Position, _aim.Target);
            
            if (hit.Occurred)
            {
                IHealth enemy = hit.Target.Health;
                enemy.TakeDamage(_damage);
            }
        }
    }
}