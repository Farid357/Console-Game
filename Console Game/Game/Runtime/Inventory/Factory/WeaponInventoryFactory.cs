using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class WeaponInventoryFactory : IWeaponInventoryFactory
    {
        public IInventory<IWeaponInventoryItem<IWeapon>> CreateStandard()
        {
            var inventoryView = new InventoryView<IWeaponInventoryItem<IWeapon>>();
            var inventory = new Inventory<IWeaponInventoryItem<IWeapon>>(inventoryView);
            return new SelfCleaningInventory<IWeaponInventoryItem<IWeapon>>(inventory);
        }

        public IInventory<IWeaponInventoryItem<IWeaponWithMagazine>> CreateWithMagazine()
        {
            var inventoryView = new InventoryView<IWeaponInventoryItem<IWeaponWithMagazine>>();
            var inventory = new Inventory<IWeaponInventoryItem<IWeaponWithMagazine>>(inventoryView);
            return new SelfCleaningInventory<IWeaponInventoryItem<IWeaponWithMagazine>>(inventory);
        }
    }
}