using System;
using System.Drawing;

namespace Console_Game
{
    public sealed class WeaponSlotFactory : IWeaponSlotFactory
    {
        private readonly IPlayerFactory<IWeapon, IWeaponInput> _playerFactory;

        public WeaponSlotFactory(IPlayerFactory<IWeapon, IWeaponInput> playerFactory, IGameObject gameObject)
        {
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
        }

        public IInventorySlot<IWeaponInventoryItem<IWeaponInput, IWeapon>> Create(string name, IWeapon weapon, IWeaponInput weaponInput)
        {
            IInventoryItemViewData viewData = new InventoryItemViewData(name, Graphics.FromHdc(IntPtr.Zero));
            IInventoryItem inventoryItem = new InventoryItem(viewData, new GameObject());
            var weaponInventoryItem = new WeaponInventoryItem<IWeaponInput, IWeapon>(inventoryItem, weapon, weaponInput, _playerFactory);
            var slotView = new InventorySlotView<IWeaponInventoryItem<IWeaponInput, IWeapon>>();
            return new InventorySlot<IWeaponInventoryItem<IWeaponInput, IWeapon>>(weaponInventoryItem, slotView);
        }
    }
}