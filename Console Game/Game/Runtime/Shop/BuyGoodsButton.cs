using System;
using Console_Game.UI;

namespace Console_Game.Shop
{
    public sealed class BuyGoodsButton : IPressOnlyButton
    {
        private readonly IPressOnlyButton _button;
        private readonly INotEnoughMoneyView _notEnoughMoneyView;
        private readonly IClient _client;

        public BuyGoodsButton(IClient client, IPressOnlyButton button, INotEnoughMoneyView notEnoughMoneyView)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _button = button ?? throw new ArgumentNullException(nameof(button));
            _notEnoughMoneyView = notEnoughMoneyView ?? throw new ArgumentNullException(nameof(notEnoughMoneyView));
        }

        public void Press()
        {
            if (_client.HasGoods && _client.EnoughMoney)
            {
                _client.BuyGoods();
                _button.Press();
            }

            else
            {
                _notEnoughMoneyView.Enable();
            }
        }
    }
}