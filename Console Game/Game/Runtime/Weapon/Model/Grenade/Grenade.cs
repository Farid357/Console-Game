using System;
using System.Numerics;
using System.Threading.Tasks;
using ConsoleGame.Physics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class Grenade : IWeapon
    {
        private readonly IBomb _bomb;
        private readonly IRigidbody _rigidbody;
        private readonly float _secondsToBlowUp;

        public Grenade(IBomb bomb, IRigidbody rigidbody, float secondsToBlowUp = 1.5f)
        {
            _bomb = bomb ?? throw new ArgumentNullException(nameof(bomb));
            _rigidbody = rigidbody ?? throw new ArgumentNullException(nameof(rigidbody));
            _secondsToBlowUp = secondsToBlowUp.ThrowIfLessThanZeroException();
        }
        
        public bool CanShoot { get; private set; }

        public IWeaponActivityView View => _bomb.View;
        
        public async void Shoot()
        {
            if (CanShoot == false)
                throw new Exception($"Weapon can't shoot!");
            
            CanShoot = false;
            _rigidbody.AddForce(new Vector3(0.5f, 0.5f, 0), 500);
            await Task.Delay(TimeSpan.FromSeconds(_secondsToBlowUp));
            _bomb.BlowUp();
        }
    }
}