using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Game.Inventory
{
    public sealed class InventoryItemSelectorInput<TItem> : IGameLoopObject where TItem : IInventoryItem
    {
        private readonly List<INumpadKey> _keys;
        private readonly IReadOnlyInventory<TItem> _inventory;

        public InventoryItemSelectorInput(IReadOnlyList<INumpadKey> keys, IReadOnlyInventory<TItem> inventory)
        {
            _keys = keys.ToList();
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
        }

        public void Update(float deltaTime)
        {
            INumpadKey pressedKey = _keys.Find(key => key.IsPressed());

            if (pressedKey != null)
            {
                TItem inputItem = _inventory.Slots.ElementAt(pressedKey.Number).Item;
                inputItem.Select();
            }
        }
    }
}