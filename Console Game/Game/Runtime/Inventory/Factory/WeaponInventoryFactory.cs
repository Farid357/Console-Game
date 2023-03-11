using System;
using System.Drawing;
using Console_Game.Weapons;

namespace Console_Game.Inventory.Factory
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


    public interface IWeaponSlotFactory
    {
        IInventorySlot<IWeaponInventoryItem<IWeaponInput, IWeapon>> Create(string name, IWeapon weapon, IWeaponInput weaponInput);
    }

    public sealed class WeaponSlotFactory : IWeaponSlotFactory
    {
        private readonly IPlayerFactory<IWeapon, IWeaponInput> _playerFactory;

        public WeaponSlotFactory(IPlayerFactory<IWeapon, IWeaponInput> playerFactory)
        {
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
        }

        public IInventorySlot<IWeaponInventoryItem<IWeaponInput, IWeapon>> Create(string name, IWeapon weapon, IWeaponInput weaponInput)
        {
            IInventoryItem inventoryItem = new InventoryItem(new InventoryItemViewData(name, Graphics.FromHdc(IntPtr.Zero)));
            var weaponInventoryItem = new WeaponInventoryItem<IWeaponInput, IWeapon>(inventoryItem, weapon, weaponInput, _playerFactory);
            var slotView = new InventorySlotView<IWeaponInventoryItem<IWeaponInput, IWeapon>>();
            return new InventorySlot<IWeaponInventoryItem<IWeaponInput, IWeapon>>(weaponInventoryItem, slotView);
        }
    }
}