using System;
using System.Drawing;
using System.Numerics;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class WalletViewFactory : IWalletViewFactory
    {
        private readonly ITextFactory _textFactory;

        public WalletViewFactory(ITextFactory textFactory)
        {
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IWalletView Create(int money)
        {
            ITransform transform = new Transform(new Vector2(75, 120));
            IText moneyText = _textFactory.Create(transform, new Font("Arial", 18), Color.Beige);
            IWalletView walletView = new WalletView(moneyText);
            walletView.Visualize(money);
            return walletView;
        }
    }
}