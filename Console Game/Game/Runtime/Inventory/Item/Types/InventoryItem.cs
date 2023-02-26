using System;

namespace Console_Game
{
    public class InventoryItem : IInventoryItem
    {
        public InventoryItem(IInventoryItemViewData viewData)
        {
            ViewData = viewData ?? throw new ArgumentNullException(nameof(viewData));
        }

        public IInventoryItemViewData ViewData { get; }
    }
}