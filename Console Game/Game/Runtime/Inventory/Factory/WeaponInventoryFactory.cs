namespace Console_Game
{
    public sealed class WeaponInventoryFactory : IWeaponInventoryFactory
    {
        public IInventory<IWeaponInventoryItem> CreateStandard()
        {
            var inventoryView = new InventoryView<IWeaponInventoryItem>();
            var inventory = new Inventory<IWeaponInventoryItem>(inventoryView);
            return new SelfCleaningInventory<IWeaponInventoryItem>(inventory);
        }

        public IInventory<IWeaponInventoryItem> CreateWithMagazine()
        {
            var inventoryView = new InventoryView<IWeaponInventoryItem>();
            var inventory = new Inventory<IWeaponInventoryItem>(inventoryView);
            return new SelfCleaningInventory<IWeaponInventoryItem>(inventory);
        }
    }
}