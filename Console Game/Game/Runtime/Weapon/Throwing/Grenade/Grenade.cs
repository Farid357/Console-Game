using System;
using System.Numerics;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public sealed class Grenade : IThrowingWeapon
    {
        private readonly IBombFactory _bombFactory;
        private readonly IRigidbody _rigidbody;
        private readonly IGrenadeView _view;

        public Grenade(IBombFactory bombFactory, IRigidbody rigidbody, IGrenadeView view)
        {
            _bombFactory = bombFactory ?? throw new ArgumentNullException(nameof(bombFactory));
            _rigidbody = rigidbody ?? throw new ArgumentNullException(nameof(rigidbody));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async void Throw()
        {
            _rigidbody.AddForce(new Vector3(0.5f, 0.5f, 0), 500);
            IBomb bomb = _bombFactory.Create(_rigidbody);

            while (!bomb.IsBlownUp)
                await Task.Yield();

            _view.Destroy();
        }
    }
}