using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class WeaponInventoryFactory : IWeaponInventoryFactory
    {
        private readonly IInventoryView<IWeaponInventoryItem<IWeaponInput, IWeapon>> _view;

        public WeaponInventoryFactory()
        {
            _view = new InventoryView<IWeaponInventoryItem<IWeaponInput, IWeapon>>();
        }

        public IInventory<IWeaponInventoryItem<IWeaponInput, IWeapon>> CreateStandard()
        {
            var inventory = new Inventory<IWeaponInventoryItem<IWeaponInput, IWeapon>>(_view);
            return new SelfCleaningInventory<IWeaponInventoryItem<IWeaponInput, IWeapon>>(inventory);
        }

        public IInventory<IWeaponInventoryItem<IWeaponInput, IWeaponWithMagazine>> CreateWithMagazine()
        {
            var inventory = new Inventory<IWeaponInventoryItem<IWeaponInput, IWeaponWithMagazine>>(_view);
            return new SelfCleaningInventory<IWeaponInventoryItem<IWeaponInput, IWeaponWithMagazine>>(inventory);
        }
    }
}