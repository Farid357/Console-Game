using System;

namespace ConsoleGame
{
    public sealed class WeaponWithShootWaiting : IWeapon
    {
        private readonly IWeapon _weapon;

        public WeaponWithShootWaiting(IWeapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }
        
        public IWeaponData Data => _weapon.Data;
        
        public bool CanShoot
        {
            get
            {
                Console.WriteLine($"{CooldownTimer.IsEnded}  {_weapon.CanShoot}");
                return CooldownTimer.IsEnded && _weapon.CanShoot;
            }
        }

        private ITimer CooldownTimer => Data.CooldownTimer;

        public void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Weapon can't shoot!");
            
            _weapon.Shoot();
            CooldownTimer.ResetTime();
        }
    }
}