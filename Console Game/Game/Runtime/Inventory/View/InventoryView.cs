using System;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class InventoryView<TItem> : IInventoryView<TItem> where TItem : IInventoryItem
    {
        private readonly IScrollView _scrollView;

        public void Add(IInventorySlot<TItem> slot)
        {
            throw new NotImplementedException();
        }

        public void Drop(IInventorySlot<TItem> slot)
        {
            throw new NotImplementedException();
        }
    }
}