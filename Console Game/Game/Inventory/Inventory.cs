using System.Collections.Generic;

namespace Console_Game
{
    public sealed class Inventory<TItem> : IInventory<TItem> where TItem : IInventoryItem
    {
        private readonly List<IInventorySlot<TItem>> _slots = new();
        
        public IEnumerable<IInventorySlot<TItem>> Slots => _slots;

        public void Add(IInventoryItem item)
        {
            IInventorySlot<TItem> slot = _slots.Find(slot => slot.IsCrowded == false && slot.CanAddItem(item));

            if (slot is null)
            {
                IInventorySlot<TItem> newSlot = new InventorySlot<TItem>(1);
            }
        }
    }
}