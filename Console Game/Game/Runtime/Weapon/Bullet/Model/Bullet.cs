using System;
using System.Numerics;

namespace Console_Game.Weapons
{
    public sealed class Bullet : IBullet
    {
        private readonly IMovement _movement;
        private readonly IBulletView _view;
        private bool _isThrowing;
        private Vector2 _direction;

        public Bullet(IMovement movement, IBulletView view)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool IsActive { get; private set; }

        public Vector2 Position => _movement.Transform.Position;

        public void Throw(Vector2 direction)
        {
            if (IsActive == false)
                throw new InvalidOperationException($"Bullet is not active!");

            _direction = direction;
            _isThrowing = true;
        }

        public void Destroy()
        {
            IsActive = false;
            _view.Destroy();
        }

        public void Update(float deltaTime)
        {
            if (!_isThrowing)
                return;

            if (IsActive == false)
                throw new InvalidOperationException($"You mustn't update not active bullet!");

            _movement.Move(_direction);
        }
    }
}