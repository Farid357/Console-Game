using System;
using System.Linq;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class WeaponWithDroppingFromInventory<TWeapon> : IWeapon where TWeapon : IWeapon
    {
        private readonly IInventory<IWeaponInventoryItem<TWeapon>> _inventory;
        private readonly TWeapon _weapon;

        public WeaponWithDroppingFromInventory(TWeapon weapon, IInventory<IWeaponInventoryItem<TWeapon>> inventory)
        {
            _weapon = weapon;
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
        }

        public bool CanShoot { get; private set; }

        public void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Can't shoot!");

            _weapon.Shoot();
            var slotWithWeapon = _inventory.Slots.First(slot => slot.Item.Weapon.Equals(_weapon));
            slotWithWeapon.Take(itemsCount: 1);
            CanShoot = false;
        }
    }
}