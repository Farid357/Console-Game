using System;
using Console_Game.UI;

namespace Console_Game.Shop
{
    public sealed class BuyGoodsButton : IButton
    {
        private readonly IClient _client;
        private readonly IButton _button;

        public BuyGoodsButton(IClient client, IButton button)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _button = button ?? throw new ArgumentNullException(nameof(button));
        }
        
        public ITransform Transform => _button.Transform;

        public bool IsEnabled => _button.IsEnabled;

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
            
            _button.Press();
        }

        public void Enable() => _button.Enable();

        public void Disable() => _button.Disable();
    }
}