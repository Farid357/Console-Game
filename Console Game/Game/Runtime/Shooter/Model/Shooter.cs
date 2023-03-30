using System;

namespace ConsoleGame
{
    public sealed class Shooter : IShooter<IWeapon>
    {
        private readonly IWeaponInput _weaponInput;
        
        public Shooter(IWeaponInput weaponInput, IWeapon weapon)
        {
            _weaponInput = weaponInput ?? throw new ArgumentNullException(nameof(weaponInput));
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public IWeapon Weapon { get; }

        public void Update(float deltaTime)
        {
            if (_weaponInput.IsUsing && Weapon.CanShoot)
                Weapon.Shoot();
        }
    }
}