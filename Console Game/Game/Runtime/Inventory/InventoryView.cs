using System.Collections.Generic;

namespace Console_Game
{
    public sealed class InventoryView<TItem> : IInventoryView<TItem> where TItem : IInventoryItem
    {
        public void Visualize(IEnumerable<IInventorySlot<TItem>> slots)
        {
            //visualize
        }
    }
}