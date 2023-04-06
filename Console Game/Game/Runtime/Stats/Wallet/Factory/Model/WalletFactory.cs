using System;
using ConsoleGame.SaveSystem;

namespace ConsoleGame
{
    public sealed class WalletFactory : IWalletFactory
    {
        private readonly ISaveStorages _saveStorages;
        private readonly IWalletViewFactory _viewFactory;

        public WalletFactory(ISaveStorages saveStorages, IWalletViewFactory viewFactory)
        {
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IWallet Create()
        {
            ISaveStorage<int> moneyStorage = new BinaryStorage<int>(new Path(nameof(IWallet) + "M"));
            int money = moneyStorage.HasSave() ? moneyStorage.Load() : 100;
            IWalletView walletView = _viewFactory.Create(money);
            _saveStorages.Add(moneyStorage);
            return new WalletWithSave(new Wallet(money, walletView), moneyStorage);
        }
    }
}