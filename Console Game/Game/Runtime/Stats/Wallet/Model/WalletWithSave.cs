using System;
using ConsoleGame.Save_Storages;

namespace ConsoleGame
{
    public sealed class WalletWithSave : IWallet
    {
        private readonly IWallet _wallet;
        private readonly ISaveStorage<IWallet> _saveStorage;

        public WalletWithSave(IWallet wallet, ISaveStorage<IWallet> saveStorage)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _saveStorage = saveStorage ?? throw new ArgumentNullException(nameof(saveStorage));
        }

        public int Money => _wallet.Money;

        public bool CanTake(int money) => _wallet.CanTake(money);

        public void Put(int money)
        {
            _wallet.Put(money);
            _saveStorage.Save(_wallet);
        }

        public void Take(int money)
        {
            _wallet.Take(money);
            _saveStorage.Save(_wallet);
        }
    }
}