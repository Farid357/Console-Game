using System;

namespace ConsoleGame
{
    public sealed class WeaponWithRateOfShot : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly ITimer _cooldownTimer;

        public WeaponWithRateOfShot(IWeapon weapon, ITimer cooldownTimer)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _cooldownTimer = cooldownTimer;
        }
        
        public bool CanShoot => _cooldownTimer.IsEnded && _weapon.CanShoot;
        
        public IWeaponActivityView View => _weapon.View;

        public void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Weapon can't shoot!");
            
            _weapon.Shoot();
            _cooldownTimer.ResetTime();
        }
    }
}