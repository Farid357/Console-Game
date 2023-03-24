using System;
using System.Collections.Generic;

namespace Console_Game.Tools
{
    public sealed class Pool<TItem> : IPool<TItem>
    {
        private readonly IFactory<TItem> _factory;
        private readonly List<TItem> _allCreatedItems;
        private readonly Stack<TItem> _availableItems;

        public Pool(IFactory<TItem> factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _availableItems = new Stack<TItem>();
            _allCreatedItems = new List<TItem>();
        }

        public Pool(IFactory<TItem> factory, int prewarm) : this(factory)
        {
            for (var i = 0; i < prewarm; i++)
            {
                _availableItems.Push(Create());
            }
        }

        public TItem Get()
        {
            TItem item = _availableItems.Count > 0 ? _availableItems.Pop() : Create();
            return item;
        }

        public void Return(TItem item)
        {
            if (_allCreatedItems.Contains(item) == false)
                throw new ArgumentOutOfRangeException($"Pool doesn't contain this item! {item}");
            
            _availableItems.Push(item);
        }

        private TItem Create()
        {
            TItem item = _factory.Create();
            _allCreatedItems.Add(item);
            return item;
        }
    }
}