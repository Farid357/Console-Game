using System;

namespace ConsoleGame
{
    public sealed class WeaponSlotFactory : IWeaponSlotFactory
    {
        private readonly IInventorySlotViewFactory _slotViewFactory;

        public WeaponSlotFactory(IInventorySlotViewFactory slotViewFactory)
        {
            _slotViewFactory = slotViewFactory ?? throw new ArgumentNullException(nameof(slotViewFactory));
        }
        
        public IInventorySlot<IWeaponInventoryItem> Create(IInventoryItemViewData viewData, IWeapon weapon, IWeaponParts weaponParts)
        {
            IInventoryItem item = new InventoryItem(viewData);
            IWeaponInventoryItem weaponItem = new WeaponInventoryItem(item, weapon, weaponParts);
            IInventorySlotView slotView = _slotViewFactory.Create();
            return new InventorySlot<IWeaponInventoryItem>(weaponItem, slotView);
        }
    }
}