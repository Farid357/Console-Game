using System;
using System.Numerics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class Grenade : IWeapon, IGameObject
    {
        private readonly ITimer _explosionTimer;
        private readonly IRigidbody _rigidbody;
        private readonly IGrenadeView _view;

        public Grenade(ITimer explosionTimer, IRigidbody rigidbody, IGrenadeView view)
        {
            _explosionTimer = explosionTimer ?? throw new ArgumentNullException(nameof(explosionTimer));
            _rigidbody = rigidbody ?? throw new ArgumentNullException(nameof(rigidbody));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool IsActive { get; private set; } = true;

        public bool CanShoot => IsActive;

        public async void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Can't shoot!");
            
            _rigidbody.AddForce(new Vector3(0.5f, 0.5f, 0), 500);
            _explosionTimer.ResetTime();
            await _explosionTimer.End();
            Destroy();
            IsActive = false;
        }

        public void Update(float deltaTime)
        {
            if (!IsActive)
                throw new InvalidOperationException($"Grenade isn't active!");
            
        }

        public void Destroy()
        {
            if (!IsActive)
                throw new InvalidOperationException($"Grenade isn't active to destroy!");
            
            _view.Destroy();
        }
    }
}