using System;

namespace ConsoleGame
{
    public sealed class WeaponSlotFactory<TWeapon, TShooter> : IWeaponSlotFactory<TWeapon, TShooter> where TWeapon : IWeapon where TShooter : IShooter<TWeapon>
    {
        private readonly IShootersSimulation<TShooter, TWeapon> _simulation;
        private readonly IInventorySlotViewFactory _viewFactory;
        
        public WeaponSlotFactory(IShootersSimulation<TShooter, TWeapon> simulation, IInventorySlotViewFactory viewFactory)
        {
            _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IInventorySlot<IWeaponInventoryItem<TWeapon>> Create(IInventoryItemViewData viewData, TShooter shooter)
        {
            IInventoryItem item = new InventoryItem(viewData);
            var weaponItem = new WeaponInventoryItem<TShooter, TWeapon>(_simulation, item, shooter);
            IInventorySlotView slotView = _viewFactory.Create();
            return new InventorySlot<IWeaponInventoryItem<TWeapon>>(weaponItem, slotView);
        }
    }
}