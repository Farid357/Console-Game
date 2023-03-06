using System;
using System.Collections.Generic;

namespace Console_Game
{
    public sealed class InventoryView<TItem> : IInventoryView<TItem> where TItem : IInventoryItem
    {
        public void Visualize(IEnumerable<IInventorySlot<TItem>> slots)
        {
            foreach (var slot in slots)
            {
                Console.WriteLine($"Slot - {slot.Item.ViewData.Name}, has items - {slot.ItemsCount}");
                Console.WriteLine();
            }
        }
    }
}