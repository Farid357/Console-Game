using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class InventorySlot<TItem> : IInventorySlot<TItem> where TItem : IInventoryItem
    {
        private readonly IInventorySlotView _view;
        private readonly int _maxItemsCount;

        public InventorySlot(TItem item, IInventorySlotView view, int itemsCount = 1)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            Item = item;
            _maxItemsCount = itemsCount.ThrowIfLessThanOrEqualsToZeroException();
            ItemsCount = _maxItemsCount;
        }

        public TItem Item { get; }

        public int ItemsCount { get; private set; }

        public bool CanTake(int itemsCount) => ItemsCount - itemsCount >= 0;

        public bool CanAdd(int itemsCount) => ItemsCount + itemsCount <= _maxItemsCount;

        public void Add(int itemsCount)
        {
            if (CanAdd(itemsCount) == false)
                throw new InvalidOperationException($"Can't add {itemsCount}");

            ItemsCount += itemsCount.ThrowIfLessThanZeroException();
            _view.Visualize(Item.ViewData, ItemsCount);
        }

        public void Take(int itemsCount)
        {
            if (CanTake(itemsCount) == false)
                throw new InvalidOperationException();
            
            ItemsCount -= itemsCount.ThrowIfLessThanZeroException();
            _view.Visualize(Item.ViewData, ItemsCount);
        }
    }
}