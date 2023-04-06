using System;

namespace ConsoleGame
{
    public sealed class WeaponWithRateOfShot : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly ITimer _rateOfShootTimer;

        public WeaponWithRateOfShot(IWeapon weapon, ITimer rateOfShootTimer)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _rateOfShootTimer = rateOfShootTimer;
        }
        
        public bool CanShoot => _rateOfShootTimer.IsEnded && _weapon.CanShoot;
        
        public IWeaponActivityView View => _weapon.View;

        public void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Weapon can't shoot!");
            
            _weapon.Shoot();
            _rateOfShootTimer.ResetTime();
        }
    }
}