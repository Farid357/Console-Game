using System;
using System.Linq;

namespace ConsoleGame
{
    public sealed class WeaponWithDroppingFromInventory : IWeapon
    {
        private readonly IInventory<IWeaponInventoryItem> _inventory;
        private readonly IWeapon _weapon;
        private bool _canShoot = true;
        
        public WeaponWithDroppingFromInventory(IWeapon weapon, IInventory<IWeaponInventoryItem> inventory)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
        }

        public bool CanShoot => _weapon.CanShoot && _canShoot;
        
        public IWeaponActivityView View => _weapon.View;

        public void Shoot()
        {
            if (CanShoot == false)
                throw new InvalidOperationException($"Can't shoot!");

            _weapon.Shoot();
            var slotWithWeapon = _inventory.Slots.First(slot => slot.Item.Weapon.Equals(_weapon));
            slotWithWeapon.Take(itemsCount: 1);
            _canShoot = false;
        }
    }
}