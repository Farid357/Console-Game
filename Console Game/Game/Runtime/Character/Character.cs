using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class Character : ICharacter
    {
        public Character(IHealth health, IAdjustableMovement movement)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            Movement = movement ?? throw new ArgumentNullException(nameof(movement));
        }

        public IHealth Health { get; }

        public IAdjustableMovement Movement { get; }
        
        public bool IsAlive => Health.IsAlive;

        public bool CanShoot => FirstWeapon.CanShoot || SecondWeapon.CanShoot;
        
        public IWeapon FirstWeapon { get; private set; }

        public IWeapon SecondWeapon { get; private set; }
        
        public void SwitchWeapons(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            if (!IsAlive)
                throw new Exception($"Character isn't alive! You can't switch his weapons!");

            FirstWeapon = firstWeapon ?? throw new ArgumentNullException(nameof(firstWeapon));
            SecondWeapon = secondWeapon ?? throw new ArgumentNullException(nameof(secondWeapon));
        }
        
        public void Shoot()
        {
            if (!CanShoot)
                throw new Exception($"Character can't shoot!");
            
            if (FirstWeapon.CanShoot)
                FirstWeapon.Shoot();
            
            if (SecondWeapon.CanShoot)
                SecondWeapon.Shoot();
        }

        public void Move(Vector3 direction)
        {
            if (!IsAlive)
                throw new Exception($"Character isn't alive! You can't move it!");

            Movement.Move(direction);
        }
    }
}