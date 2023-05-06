using System;
using System.Numerics;
using ConsoleGame.Physics;

namespace ConsoleGame.Weapons
{
    public sealed class Bullet : IBullet, IGameObject
    {
        private readonly IMovement _movement;
        private readonly IRaycast<IEnemy> _raycast;
        private readonly IBulletView _view;
        private readonly int _damage;
        private bool _isThrowing;
        private Vector3 _direction;

        public Bullet(IMovement movement, IRaycast<IEnemy> raycast, IBulletView view, int damage)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _raycast = raycast ?? throw new ArgumentNullException(nameof(raycast));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _damage = damage;
        }

        public bool IsAlive { get; private set; } = true;

        public void Throw(Vector3 direction)
        {
            if (IsAlive == false)
                throw new InvalidOperationException($"Bullet is not active!");

            _direction = direction;
            _isThrowing = true;
        }

        public void Update(float deltaTime)
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Bullet is destroyed!");

            if (!_isThrowing)
                return;

            _movement.Move(_direction);
            RaycastHit<IEnemy> hit = _raycast.Throw(_movement.Transform.Position, _direction);

            if (hit.Occurred)
                Attack(hit.Target.Health);
        }

        private void Attack(IHealth health)
        {
            if (health.IsAlive)
                health.TakeDamage(_damage);

            IsAlive = false;
            _view.Destroy();
        }
    }
}