using System;

namespace Console_Game
{
    public sealed class InventorySlotView<TItem> : IInventorySlotView<TItem> where TItem : IInventoryItem
    {
        public void Visualize(TItem item, int count)
        {
            if (count > 1)
            {
                Console.WriteLine($"item: {item.ViewData.Name}  has count: {count}");
            }
            
            else
            {
                Console.WriteLine($"item: {item.ViewData.Name}");
            }
        }
    }
}