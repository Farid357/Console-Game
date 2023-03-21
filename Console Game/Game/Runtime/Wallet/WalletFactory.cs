using System;
using System.Numerics;
using Console_Game.Save_Storages;
using Console_Game.Save_Storages.Paths;
using Console_Game.UI;

namespace Console_Game
{
    public sealed class WalletFactory : IFactory<IWallet>
    {
        private readonly ISaveStorages _saveStorages;
        private readonly ITextFactory _textFactory;

        public WalletFactory(ISaveStorages saveStorages, ITextFactory textFactory)
        {
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IWallet Create()
        {
            ISaveStorage<IWallet> saveStorage = new BinaryStorage<IWallet>(new Path(nameof(IWallet)));
            IText moneyText = _textFactory.Create(new Transform(new Vector2(75, 120)));
            IWalletView walletView = new WalletView(moneyText);
            IWallet defaultWallet = new Wallet(100, walletView);
            _saveStorages.Add(saveStorage);
            IWallet wallet = saveStorage.HasSave() ? new WalletWithSave(saveStorage.Load(), saveStorage) : new WalletWithSave(defaultWallet, saveStorage);
            walletView.Visualize(wallet.Money);
            return wallet;
        }
    }
}