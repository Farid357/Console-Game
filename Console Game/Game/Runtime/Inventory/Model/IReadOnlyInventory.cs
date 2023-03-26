using System.Collections.Generic;

namespace ConsoleGame
{
    public interface IReadOnlyInventory<TItem>
    {
        IReadOnlyList<IInventorySlot<TItem>> Slots { get; }

        bool CanDrop(IInventorySlot<TItem> slot);
    }
}