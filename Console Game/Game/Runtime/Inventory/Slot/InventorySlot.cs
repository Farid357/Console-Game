using System;
using Console_Game.Tools;

namespace Console_Game
{
    public sealed class InventorySlot<TItem> : IInventorySlot<TItem> where TItem : IInventoryItem
    {
        private readonly IInventorySlotView<TItem> _view;
        private readonly int _maxItemsCount;

        public InventorySlot(TItem item, IInventorySlotView<TItem> view, int itemsCount = 1)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            Item = item;
            _maxItemsCount = itemsCount.ThrowIfLessThanOrEqualsToZeroException();
            ItemsCount = _maxItemsCount;
        }

        public TItem Item { get; }

        public int ItemsCount { get; private set; }

        public bool CanAdd(int itemsCount) => ItemsCount + itemsCount <= _maxItemsCount;

        public void Add(int itemsCount)
        {
            itemsCount.ThrowIfLessThanOrEqualsToZeroException();

            if (CanAdd(itemsCount) == false)
                throw new InvalidOperationException($"Can't add {itemsCount}");

            ItemsCount += itemsCount;
            _view.Visualize(Item, itemsCount);
        }
    }
}