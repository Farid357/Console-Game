using System;
using Console_Game.UI;

namespace Console_Game
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