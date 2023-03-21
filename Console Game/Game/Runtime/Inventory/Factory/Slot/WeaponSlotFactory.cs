using System;
using System.Drawing;

namespace Console_Game
{
    public sealed class WeaponSlotFactory<TWeapon, TWeaponInput> : IWeaponSlotFactory<TWeapon, TWeaponInput> where TWeaponInput : IWeaponInput where TWeapon : IWeapon
    {
        private readonly IPlayerFactory<TWeapon, TWeaponInput> _playerFactory;
        private readonly IPlayersSimulation<IPlayer> _simulation;

        public WeaponSlotFactory(IPlayerFactory<TWeapon, TWeaponInput> playerFactory, IPlayersSimulation<IPlayer> simulation)
        {
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
            _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        }
        
        public IInventorySlot<IWeaponInventoryItem> Create(string name, TWeapon weapon, TWeaponInput weaponInput)
        {
            IInventoryItemViewData viewData = new InventoryItemViewData(name, Graphics.FromHdc(IntPtr.Zero));
            IInventoryItem item = new InventoryItem(viewData);
            var weaponItem = new WeaponInventoryItem<IPlayer>(_simulation, item, _playerFactory.Create(weaponInput, weapon));
            var slotView = new InventorySlotView();
            return new InventorySlot<IWeaponInventoryItem>(weaponItem, slotView);
        }
    }
}