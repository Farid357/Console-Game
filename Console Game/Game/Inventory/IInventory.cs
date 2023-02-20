using System.Collections.Generic;

namespace Console_Game
{
    public interface IInventory<TItem> where TItem : IInventoryItem
    {
        IEnumerable<IInventorySlot<TItem>> Slots { get; }

        void Add(IInventoryItem item);
    }
}