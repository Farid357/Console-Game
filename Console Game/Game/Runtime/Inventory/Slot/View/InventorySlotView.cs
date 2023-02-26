using System;

namespace Console_Game
{
    public sealed class InventorySlotView<TItem> : IInventorySlotView<TItem> where TItem : IInventoryItem
    {
        public void Visualize(TItem item, int count)
        {
            Console.WriteLine($"item: {item.ViewData.Name}  has count: {count}");
        }
    }
}