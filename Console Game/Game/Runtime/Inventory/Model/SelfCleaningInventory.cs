using System;
using System.Collections.Generic;

namespace Console_Game
{
    public sealed class SelfCleaningInventory<TItem> : IGameLoopObject, IInventory<TItem>
    {
        private readonly IInventory<TItem> _inventory;

        public SelfCleaningInventory(IInventory<TItem> inventory)
        {
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
        }

        public IReadOnlyList<IInventorySlot<TItem>> Slots => _inventory.Slots;

        public bool CanDrop(IInventorySlot<TItem> slot) => _inventory.CanDrop(slot);

        public void Add(IInventorySlot<TItem> slot) => _inventory.Add(slot);

        public void Drop(IInventorySlot<TItem> slot) => _inventory.Drop(slot);

        public void Update(float deltaTime)
        {
            foreach (var slot in _inventory.Slots)
            {
                if(slot.ItemsCount == 0)
                    Drop(slot);
            }
        }
    }
}