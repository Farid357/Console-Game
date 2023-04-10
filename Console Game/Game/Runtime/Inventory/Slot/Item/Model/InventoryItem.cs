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
            if (IsSelected)
                throw new Exception($"Item is already selected!");
            
            IsSelected = true;
        }

        public void Unselect()
        {
            if (IsSelected == false)
                throw new Exception($"Item is already unselected!");
            
            IsSelected = false;
        }
    }
}