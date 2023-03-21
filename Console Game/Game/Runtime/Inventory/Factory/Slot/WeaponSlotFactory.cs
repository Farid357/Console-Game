using System;
using System.Numerics;
using Console_Game.UI;

namespace Console_Game
{
    public sealed class WeaponSlotFactory<TWeapon, TWeaponInput> : IWeaponSlotFactory<TWeapon, TWeaponInput> where TWeaponInput : IWeaponInput where TWeapon : IWeapon
    {
        private readonly IPlayerFactory<TWeapon, TWeaponInput> _playerFactory;
        private readonly IPlayersSimulation<IPlayer> _simulation;
        private readonly ITextFactory _textFactory;
        private readonly IImageFactory _imageFactory;
        private Vector2 _position = new Vector2(20, 20);
        private readonly Vector2 _offset = new Vector2(45, 45);
        
        public WeaponSlotFactory(IPlayerFactory<TWeapon, TWeaponInput> playerFactory, IPlayersSimulation<IPlayer> simulation, ITextFactory textFactory, IImageFactory imageFactory)
        {
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
            _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
            _imageFactory = imageFactory ?? throw new ArgumentNullException(nameof(imageFactory));
        }
        
        public IInventorySlot<IWeaponInventoryItem> Create(string name, TWeapon weapon, TWeaponInput weaponInput)
        {
            IInventoryItemViewData viewData = new InventoryItemViewData(name, _imageFactory.Create(new Transform(_position)));
            IInventoryItem item = new InventoryItem(viewData);
            var weaponItem = new WeaponInventoryItem<IPlayer>(_simulation, item, _playerFactory.Create(weaponInput, weapon));
            var slotView = new InventorySlotView(_textFactory.Create(new Transform()));
            _position += _offset;
            return new InventorySlot<IWeaponInventoryItem>(weaponItem, slotView);
        }
    }
}