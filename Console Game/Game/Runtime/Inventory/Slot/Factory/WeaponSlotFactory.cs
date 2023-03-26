using System;

namespace ConsoleGame
{
    public sealed class WeaponSlotFactory<TWeapon, TWeaponInput, TPlayer> : IWeaponSlotFactory<TWeapon, TWeaponInput>
        where TWeaponInput : IWeaponInput where TWeapon : IWeapon where TPlayer : IPlayer
    {
        private readonly IPlayerFactory<TWeapon, TWeaponInput, TPlayer> _playerFactory;
        private readonly IPlayersSimulation<TPlayer> _simulation;
        private readonly IInventorySlotViewFactory _viewFactory;
        
        public WeaponSlotFactory(IPlayerFactory<TWeapon, TWeaponInput, TPlayer> playerFactory, IPlayersSimulation<TPlayer> simulation, IInventorySlotViewFactory viewFactory)
        {
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
            _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IInventorySlot<IWeaponInventoryItem> Create(IInventoryItemViewData viewData, TWeapon weapon, TWeaponInput weaponInput)
        {
            IInventoryItem item = new InventoryItem(viewData);
            TPlayer player = _playerFactory.Create(weaponInput, weapon);
            var weaponItem = new WeaponInventoryItem<TPlayer>(_simulation, item, player);
            IInventorySlotView slotView = _viewFactory.Create();
            return new InventorySlot<IWeaponInventoryItem>(weaponItem, slotView);
        }
    }
}