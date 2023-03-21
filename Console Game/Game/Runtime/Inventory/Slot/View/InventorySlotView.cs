using System;

namespace Console_Game
{
    public sealed class InventorySlotView : IInventorySlotView
    {
        public void Visualize(IInventoryItemViewData viewData, int count)
        {
            if (count > 1)
            {
                Console.WriteLine($"item: {viewData.Name}  has count: {count}");
            }
            
            else
            {
                Console.WriteLine($"item: {viewData.Name}");
            }
        }
    }
}