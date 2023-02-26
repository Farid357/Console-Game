using System.Collections.Generic;

namespace Console_Game
{
    public interface IInventoryView<in TItem> where TItem : IInventoryItem
    {
        void Visualize(IEnumerable<IInventorySlot<TItem>> slots);
    }
}