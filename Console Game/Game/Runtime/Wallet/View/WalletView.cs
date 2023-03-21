using System;
using Console_Game.UI;

namespace Console_Game
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