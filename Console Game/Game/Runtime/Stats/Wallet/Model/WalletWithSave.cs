using System;
using ConsoleGame.SaveSystem;

namespace ConsoleGame
{
    public sealed class WalletWithSave : IWallet
    {
        private readonly IWallet _wallet;
        private readonly ISaveStorage<int> _moneyStorage;

        public WalletWithSave(IWallet wallet, ISaveStorage<int> moneyStorage)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _moneyStorage = moneyStorage ?? throw new ArgumentNullException(nameof(moneyStorage));
        }

        public int Money => _wallet.Money;

        public bool CanTake(int money) => _wallet.CanTake(money);

        public void Put(int money)
        {
            _wallet.Put(money);
            _moneyStorage.Save(_wallet.Money);
        }

        public void Take(int money)
        {
            _wallet.Take(money);
            _moneyStorage.Save(_wallet.Money);
        }
    }
}