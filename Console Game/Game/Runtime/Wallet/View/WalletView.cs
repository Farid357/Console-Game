using System;

namespace Console_Game
{
    public sealed class WalletView : IWalletView
    {
        public void Visualize(int money)
        {
            Console.WriteLine($"Money: {money}");
        }
    }
}