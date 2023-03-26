using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class MoneyReward : IReward
    {
        private readonly IWallet _wallet;
        private readonly int _money;

        public MoneyReward(IWallet wallet, int money)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _money = money.ThrowIfLessThanOrEqualsToZeroException();
        }

        public bool IsApplied { get; private set; }

        public void Apply()
        {
            IsApplied = true;
            _wallet.Put(_money);
        }
    }
}