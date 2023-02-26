using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Game.Inventory
{
    public sealed class InventoryItemSelectorInput<TItem> : IGameLoopObject where TItem : IInventoryItem
    {
        private readonly List<IKey> _keys;
        private readonly IReadOnlyInventory<TItem> _inventory;
        private readonly IInventoryItemSelector<TItem> _selector;
        
        public InventoryItemSelectorInput(IReadOnlyList<IKey> keys, IReadOnlyInventory<TItem> inventory, IInventoryItemSelector<TItem> selector)
        {
            _keys = keys.ToList();
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));
        }

        public void Update(long deltaTime)
        {
            IKey pressedKey = _keys.Find(key => key.IsPressed());
            
            if (pressedKey != null)
            {
                TItem selectedItem = _inventory.Slots.ElementAt(_keys.IndexOf(pressedKey)).Item;
                _selector.Select(selectedItem);
            }
        }
    }
}