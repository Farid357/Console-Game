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
            ISaveStorage<IWallet> saveStorage = new BinaryStorage<IWallet>(new Path(nameof(IWallet)));
            IWalletView walletView = _viewFactory.Create();
            IWallet defaultWallet = new Wallet(100, walletView);
            _saveStorages.Add(saveStorage);
            IWallet wallet = saveStorage.HasSave() ? new WalletWithSave(saveStorage.Load(), saveStorage) : new WalletWithSave(defaultWallet, saveStorage);
            walletView.Visualize(wallet.Money);
            return wallet;
        }
    }
}