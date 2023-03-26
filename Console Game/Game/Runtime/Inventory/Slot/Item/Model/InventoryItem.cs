using System;

namespace ConsoleGame
{
    public sealed class InventoryItem : IInventoryItem
    {
        public InventoryItem(IInventoryItemViewData viewData)
        {
            ViewData = viewData ?? throw new ArgumentNullException(nameof(viewData));
        }

        public IInventoryItemViewData ViewData { get; }
        
        public bool IsSelected { get; private set; }
        
        public void Select()
        {
            IsSelected = true;
        }

        public void Unselect()
        {
            IsSelected = false;
        }
    }
}