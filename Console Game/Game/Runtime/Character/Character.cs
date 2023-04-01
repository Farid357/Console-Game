using System;
using System.Numerics;
using ConsoleGame.Weapon;

namespace ConsoleGame
{
    public sealed class Character : ICharacter
    {
        private readonly IWeaponsData _weaponsData;
        private IWeapon _weapon;

        public Character(IHealth health, IAdjustableMovement movement, IWeapon weapon, IWeaponsData weaponsData)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            Movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _weaponsData = weaponsData ?? throw new ArgumentNullException(nameof(weaponsData));
        }

        public IWeaponData WeaponData => _weaponsData.DataFor(_weapon);
        
        public IHealth Health { get; }

        public IAdjustableMovement Movement { get; }
        
        public bool IsAlive => Health.IsAlive;
        
        public bool CanShoot => _weapon.CanShoot;

        public void SwitchWeapon(IWeapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }
        
        public void Shoot()
        {
            if (!CanShoot)
                throw new Exception($"Character can't shoot!");
            
            if (_weapon.CanShoot)
                _weapon.Shoot();
            
        }

        public void Move(Vector3 direction)
        {
            if (!IsAlive)
                throw new Exception($"Character isn't alive! You can't move it!");

            Movement.Move(direction);
        }
    }
}