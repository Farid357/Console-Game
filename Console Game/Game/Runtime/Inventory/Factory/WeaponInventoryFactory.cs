using System;

namespace ConsoleGame
{
    public sealed class WeaponInventoryFactory : IWeaponInventoryFactory
    {
        private readonly IInventoryViewFactory<IWeaponInventoryItem> _viewFactory;

        public WeaponInventoryFactory(IInventoryViewFactory<IWeaponInventoryItem> viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IInventory<IWeaponInventoryItem> Create()
        {
            IInventoryView<IWeaponInventoryItem> view = _viewFactory.Create();
            var inventory = new Inventory<IWeaponInventoryItem>(view);
            return new SelfCleaningInventory<IWeaponInventoryItem>(inventory);
        }
    }
}