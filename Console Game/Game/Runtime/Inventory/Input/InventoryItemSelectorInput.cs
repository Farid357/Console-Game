using System;
using System.Collections.Generic;
using System.Linq;
using Console_Game.Tools;

namespace Console_Game.Inventory
{
    public sealed class InventoryItemSelectorInput<TItem> : IGameLoopObject where TItem : IInventoryItem
    {
        private readonly List<INumpadKey> _keys;
        private readonly IReadOnlyInventory<TItem> _inventory;
        private TItem _lastSelectedItem;
        
        public InventoryItemSelectorInput(IReadOnlyList<INumpadKey> keys, IReadOnlyInventory<TItem> inventory)
        {
            _keys = keys.ToList();
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
            _lastSelectedItem = _inventory.Slots.First().Item;
        }

        public void Update(float deltaTime)
        {
            INumpadKey pressedKey = _keys.Find(key => key.IsPressed());

            if (pressedKey != null && _inventory.ContainsSlot(pressedKey.Number))
            {
                _lastSelectedItem?.Unselect();
                TItem inputItem = _inventory.Slots[pressedKey.Number].Item;
                inputItem.Select();
                _lastSelectedItem = inputItem;
            }
        }
    }
}