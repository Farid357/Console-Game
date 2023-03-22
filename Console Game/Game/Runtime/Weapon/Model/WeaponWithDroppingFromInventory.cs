using System;
using System.Linq;

namespace Console_Game
{
    public sealed class WeaponWithDroppingFromInventory : IWeapon
    {
        private readonly IInventory<IWeaponInventoryItem> _inventory;
        private readonly IWeapon _weapon;

        public WeaponWithDroppingFromInventory(IWeapon weapon, IInventory<IWeaponInventoryItem> inventory)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
        }

        public bool CanShoot { get; private set; }

        public void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Can't shoot!");

            _weapon.Shoot();
            var slotWithWeapon = _inventory.Slots.First(slot => slot.Item.Weapon == _weapon);
            slotWithWeapon.Take(itemsCount: 1);
            CanShoot = false;
        }
    }
}