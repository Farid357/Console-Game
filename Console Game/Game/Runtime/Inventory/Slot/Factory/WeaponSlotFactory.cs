using System;

namespace ConsoleGame
{
    public sealed class WeaponSlotFactory<TWeapon> : IWeaponSlotFactory<TWeapon> where TWeapon : IWeapon
    {
        private readonly IWeaponViewFactory _weaponViewFactory;
        private readonly IInventorySlotViewFactory _slotViewFactory;
        private readonly ICharacter _character;

        public WeaponSlotFactory(IWeaponViewFactory weaponViewFactory, IInventorySlotViewFactory slotViewFactory, ICharacter character)
        {
            _weaponViewFactory = weaponViewFactory ?? throw new ArgumentNullException(nameof(weaponViewFactory));
            _slotViewFactory = slotViewFactory ?? throw new ArgumentNullException(nameof(slotViewFactory));
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }
        
        public IInventorySlot<IWeaponInventoryItem<TWeapon>> Create(IInventoryItemViewData viewData, TWeapon weapon)
        {
            IInventoryItem item = new InventoryItem(viewData);
            IWeaponView weaponView = _weaponViewFactory.Create(viewData.Icon);
            var weaponItem = new WeaponInventoryItem<TWeapon>(item, _character, weapon, weaponView);
            IInventorySlotView slotView = _slotViewFactory.Create();
            return new InventorySlot<IWeaponInventoryItem<TWeapon>>(weaponItem, slotView);
        }
    }
}