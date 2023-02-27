using System;

namespace Console_Game
{
    public sealed class InventoryItem : IInventoryItem
    {
        public InventoryItem(IInventoryItemViewData viewData)
        {
            ViewData = viewData ?? throw new ArgumentNullException(nameof(viewData));
        }

        public IInventoryItemViewData ViewData { get; }
        
        public bool IsSelected { get; private set; }
        
        public void Unselect()
        {
            if (IsSelected == false)
                throw new InvalidOperationException($"Already unselected!");

            IsSelected = false;
        }

        public void Select()
        {
            if (IsSelected)
                throw new InvalidOperationException($"Already selected!");

            IsSelected = true;
        }
    }
}