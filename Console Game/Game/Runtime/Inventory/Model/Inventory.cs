using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public sealed class Inventory<TItem> : IInventory<TItem> where TItem : IInventoryItem
    {
        private readonly List<IInventorySlot<TItem>> _slots = new List<IInventorySlot<TItem>>();
        private readonly IInventoryView<TItem> _view;

        public Inventory(IInventoryView<TItem> view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public IReadOnlyList<IInventorySlot<TItem>> Slots => _slots;

        public bool CanDrop(IInventorySlot<TItem> slot) => slot.ItemsCount == 0 && _slots.Contains(slot);

        public void Add(IInventorySlot<TItem> slot)
        {
            if (slot == null) 
                throw new ArgumentNullException(nameof(slot));
            
            _slots.Add(slot);
            _view.Add(slot);
        }

        public void Drop(IInventorySlot<TItem> slot)
        {
            if (slot == null) 
                throw new ArgumentNullException(nameof(slot));

            if (CanDrop(slot) == false)
                throw new InvalidOperationException($"Can't remove {slot}");

            _slots.Remove(slot);
            _view.Drop(slot);
        }
    }
}