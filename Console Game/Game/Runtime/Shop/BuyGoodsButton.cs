using System;

namespace Console_Game.Shop
{
    public sealed class BuyGoodsButton : IButton
    {
        private readonly IClient _client;

        public BuyGoodsButton(IClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public void Press()
        {
            if (_client.HasGoods && _client.EnoughMoney)
            {
                _client.BuyGoods();
            }
            
            else
            {
                Console.WriteLine($"Not enough money!");
            }
        }
    }
}