using System;
using System.Linq;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class Character : ICharacter
    {
        private readonly IReadOnlyInventory<IWeaponInventoryItem> _inventory;
        private readonly IAdjustableMovement _movement;

        public Character(IHealth health, IReadOnlyInventory<IWeaponInventoryItem> inventory, IAdjustableMovement movement)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
        }
        
        public IHealth Health { get; }

        private IWeapon Weapon => SelectedWeaponItem.Weapon;
        
        public IReadOnlyTransform Transform => _movement.Transform;

        public IWeaponInventoryItem SelectedWeaponItem => _inventory.Slots.First(slot => slot.Item.IsSelected).Item;

        public bool IsAlive => Health.IsAlive;
        
        public bool CanShoot => Weapon.CanShoot && IsAlive;

        public void Shoot()
        {
            if (!IsAlive)
                throw new Exception($"Character isn't alive! He can't shoot!");
            
            if (!CanShoot)
                throw new Exception($"Character can't shoot!");

            Weapon.Shoot();
        }

        public void Move(Vector3 direction)
        {
            if (!IsAlive)
                throw new Exception($"Character isn't alive! You can't move it!");

            _movement.Move(direction);
        }
    }
}