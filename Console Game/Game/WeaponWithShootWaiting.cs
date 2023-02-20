using System;

namespace Console_Game
{
    public sealed class WeaponWithShootWaiting : IWeapon
    {
        private readonly ITimer _cooldownTimer;
        private readonly IWeapon _weapon;

        public WeaponWithShootWaiting(ITimer cooldownTimer, IWeapon weapon)
        {
            _cooldownTimer = cooldownTimer ?? throw new ArgumentNullException(nameof(cooldownTimer));
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public bool CanShoot => _cooldownTimer.FinishedCountdown && _weapon.CanShoot;
        
        public void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Weapon can't shoot!");
            
            _weapon.Shoot();
            _cooldownTimer.Play();
        }
    }
}