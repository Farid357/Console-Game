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

        public bool IsAlive { get; private set; } = true;

        public bool CanShoot => IsAlive;

        public async void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Can't shoot!");
            
            _rigidbody.AddForce(new Vector3(0.5f, 0.5f, 0), 500);
            _explosionTimer.ResetTime();
            await _explosionTimer.End();
            _view.Destroy();
            IsAlive = false;
        }

        public void Update(float deltaTime)
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Grenade isn't active!");
            
        }
    }
}