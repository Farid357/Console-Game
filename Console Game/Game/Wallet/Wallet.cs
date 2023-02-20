using System;
using Console_Game.Tools.Extensions;

namespace Console_Game
{
    public sealed class Wallet : IWallet
    {
        private readonly IWalletView _walletView;

        public Wallet(int money, IWalletView walletView)
        {
            _walletView = walletView ?? throw new ArgumentNullException(nameof(walletView));
            Money = money.ThrowIfLessThanOrEqualsToZeroException();
        }

        public int Money { get; private set; }

        public bool CanTake(int money) => Money - money >= 0;

        public void Put(int money)
        {
            Money += money.ThrowIfLessThanOrEqualsToZeroException();
        }

        public void Take(int money)
        {
            if (CanTake(money) == false)
                throw new InvalidOperationException($"You can't take {money} from wallet!");

            Money -= money.ThrowIfLessThanOrEqualsToZeroException();
        }
    }
}