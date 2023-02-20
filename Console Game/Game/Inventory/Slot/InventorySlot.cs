using System;

namespace Console_Game
{
    public sealed class InventorySlot<TItem> : IInventorySlot<TItem> where TItem : IInventoryItem
    {
        private readonly int _maxItemsCount;

        public InventorySlot(int itemsCount)
        {
            if (itemsCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(itemsCount));

            ItemsCount = itemsCount;
            _maxItemsCount = ItemsCount;
        }

        public int ItemsCount { get; }

        public bool IsCrowded => ItemsCount == _maxItemsCount;

        public bool CanAddItem(IInventoryItem item)
        {
            if (IsCrowded)
                return false;
            
            return typeof(TItem) == item.GetType();
        }

        public void AddItems(int count)
        {
          //  ItemsCount +=
        }
    }
}