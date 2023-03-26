using System;
using System.Numerics;
using ConsoleGame.Tools;
using ConsoleGame.Physics;

namespace ConsoleGame.Weapons
{
    public sealed class RaycastBullet : IBullet
    {
        private readonly IBullet _bullet;
        private readonly IRaycast<IEnemy> _raycast;
        private readonly int _damage;
        private Vector2 _direction;

        public RaycastBullet(IBullet bullet, IRaycast<IEnemy> raycast, int damage)
        {
            _bullet = bullet ?? throw new ArgumentNullException(nameof(bullet));
            _raycast = raycast ?? throw new ArgumentNullException(nameof(raycast));
            _damage = damage;
        }

        public Vector2 Position => _bullet.Position;

        public void Throw(Vector2 direction)
        {
            _bullet.Throw(direction);
            _direction = direction;
        }

        public void Destroy() => _bullet.Destroy();

        public void Update(float deltaTime)
        {
            _raycast.Throw(Position, _direction);

            if (_raycast.HasHit)
            {
                Attack(_raycast.HitTarget().Health);
                Destroy();
            }
        }

        private void Attack(IHealth enemyHealth)
        {
            if (enemyHealth.IsAlive)
                enemyHealth.TakeDamage(_damage);
        }
    }
}