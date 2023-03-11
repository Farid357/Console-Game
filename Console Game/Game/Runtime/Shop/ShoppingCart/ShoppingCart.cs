using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Game.Shop
{
    public sealed class ShoppingCart : IShoppingCart
    {
        private readonly List<IGood> _goods;
        private readonly IShoppingCartView _view;

        public ShoppingCart(IShoppingCartView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _goods = new List<IGood>();
        }

        public IReadOnlyList<IGood> Goods => _goods;

        public int TotalCost() => Goods.Sum(good => good.Cost);

        public void Add(IGood good)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            _goods.Add(good);
            _view.Add(good);
            _view.Visualize(TotalCost());
        }

        public void Remove(IGood good)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            _goods.Remove(good);
            _view.Remove(good);
            _view.Visualize(TotalCost());
        }
    }
}