using System;

namespace ConsoleGame
{
    public sealed class WeaponSlotFactory : IWeaponSlotFactory
    {
        private readonly IInventorySlotViewFactory _slotViewFactory;
        private readonly ICharacter _character;

        public WeaponSlotFactory(IInventorySlotViewFactory slotViewFactory, ICharacter character)
        {
            _slotViewFactory = slotViewFactory ?? throw new ArgumentNullException(nameof(slotViewFactory));
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }
        
        public IInventorySlot<IWeaponInventoryItem> Create(IInventoryItemViewData viewData, IWeapon weapon)
        {
            IInventoryItem item = new InventoryItem(viewData);
            IWeaponInventoryItem weaponItem = new WeaponInventoryItem(item, _character, weapon);
            IInventorySlotView slotView = _slotViewFactory.Create();
            return new InventorySlot<IWeaponInventoryItem>(weaponItem, slotView);
        }
    }
}