using System;
using System.Threading.Tasks;

namespace Console_Game
{
    public sealed class Grenade : IWeapon
    {
        private readonly ITimer _explosionTimer;
        private readonly IGrenadeMovement _movement;
        private readonly IGameObjectView _view;

        public Grenade(ITimer explosionTimer, IGrenadeMovement movement, IGameObjectView view)
        {
            _explosionTimer = explosionTimer ?? throw new ArgumentNullException(nameof(explosionTimer));
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool CanShoot { get; private set; }

        public async void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Can't shoot!");
            
            CanShoot = false;
            _movement.Throw();
            _explosionTimer.Play();
            
            while (_explosionTimer.IsEnded == false)
                await Task.Yield();

            _view.Destroy();
        }
    }
}