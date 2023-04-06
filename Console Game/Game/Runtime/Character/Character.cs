using System;
using System.Numerics;
using ConsoleGame.Weapon;

namespace ConsoleGame
{
    public sealed class Character : ICharacter
    {
        private readonly IAdjustableMovement _movement;
        private readonly IWeaponsData _weaponsData;
        private readonly IHealth _health;
        private IWeapon _weapon;

        public Character(IHealth health, IAdjustableMovement movement, IWeapon weapon, IWeaponsData weaponsData)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _weaponsData = weaponsData ?? throw new ArgumentNullException(nameof(weaponsData));
        }

        public IWeaponData WeaponData => _weaponsData.DataFor(_weapon);

        public bool IsAlive => _health.IsAlive;
        
        public bool CanShoot => _weapon.CanShoot && IsAlive;

        public void SwitchWeapon(IWeapon weapon)
        {
            if (!IsAlive)
                throw new Exception($"Character isn't alive! He can't switch weapon!");
            
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }
        
        public void Shoot()
        {
            if (!IsAlive)
                throw new Exception($"Character isn't alive! He can't shoot!");
            
            if (!CanShoot)
                throw new Exception($"Character can't shoot!");
            
            if (_weapon.CanShoot)
                _weapon.Shoot();
        }

        public void Move(Vector3 direction)
        {
            if (!IsAlive)
                throw new Exception($"Character isn't alive! You can't move it!");

            _movement.Move(direction);
        }
    }
}