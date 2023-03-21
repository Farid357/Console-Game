using System;
using System.Collections.Generic;
using System.Linq;
using Console_Game.Tools;

namespace Console_Game.Inventory
{
    public sealed class InventoryItemSelectingInput<TItem> : IGameLoopObject, IInventoryItemSelectingInput<TItem> where TItem : IInventoryItem
    {
        private readonly List<INumpadKey> _keys;
        private readonly IReadOnlyInventory<TItem> _inventory;
        private INumpadKey _pressedKey;
        
        public InventoryItemSelectingInput(IEnumerable<INumpadKey> keys, IReadOnlyInventory<TItem> inventory)
        {
            _keys = keys.ToList();
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
            InputItem = _inventory.Slots.First().Item;
        }
        
        public TItem InputItem { get; private set; }

        public bool IsUsing()
        {
            return _pressedKey != null && _inventory.ContainsSlot(_pressedKey.Number);
        }

        public void Update(float deltaTime)
        {
            _pressedKey = _keys.Find(key => key.IsPressed());

            if (IsUsing())
            {
                InputItem?.Unselect();
                InputItem = _inventory.Slots[_pressedKey.Number].Item;
                InputItem.Select();
            }
        }
    }
}