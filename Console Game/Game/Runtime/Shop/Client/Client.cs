using System;
using ConsoleGame.Tools;

namespace ConsoleGame.Shop
{
    public sealed class Client : IClient
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IWallet _wallet;

        public Client(IWallet wallet, IShoppingCart shoppingCart)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
        }

        public bool EnoughMoney => _wallet.CanTake(_shoppingCart.TotalCost());
        
        public bool HasGoods => !_shoppingCart.IsEmpty();
        
        public void BuyGoods()
        {
            if (!HasGoods)
                throw new InvalidOperationException($"Client doesn't have goods!");

            if (!HasGoods)
                throw new InvalidOperationException($"Client doesn't have money for {_shoppingCart.Goods}!");
            
            _wallet.Take(_shoppingCart.TotalCost());

            foreach (var good in _shoppingCart.Goods)
            {
                good.Use();
            }
            
            _shoppingCart.Clear();
        }
    }
}