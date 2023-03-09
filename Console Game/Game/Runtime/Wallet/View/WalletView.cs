using System;

namespace Console_Game
{
    [Serializable]
    public sealed class WalletView : IWalletView
    {
        public void Visualize(int money)
        {
            Console.WriteLine($"Money: {money}");
        }
    }
}