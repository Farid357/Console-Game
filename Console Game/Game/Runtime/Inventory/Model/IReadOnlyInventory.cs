using System.Collections.Generic;

namespace Console_Game
{
    public interface IReadOnlyInventory<TItem> where TItem : IInventoryItem
    {
        IReadOnlyList<IInventorySlot<TItem>> Slots { get; }

        bool CanDrop(IInventorySlot<TItem> slot);
    }
}