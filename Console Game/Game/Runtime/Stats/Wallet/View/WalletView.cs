using System;
using ConsoleGame.UI;

namespace ConsoleGame
{
    [Serializable]
    public sealed class WalletView : IWalletView
    {
        private readonly IText _text;

        public WalletView(IText text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public void Visualize(int money)
        {
            _text.Visualize($"Money: {money}");
        }
    }
}