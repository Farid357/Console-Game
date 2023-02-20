using System;
using Console_Game.Save_Storages;
using Console_Game.Save_Storages.Paths;

namespace Console_Game
{
    public sealed class WalletFactory : IFactory<IWallet>
    {
        private readonly ISaveStorages _saveStorages;

        public WalletFactory(ISaveStorages saveStorages)
        {
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
        }

        public IWallet Create()
        {
            ISaveStorage<IWallet> saveStorage = new BinaryStorage<IWallet>(new Path(nameof(IWallet)));
            IWallet defaultWallet = new Wallet(100, new WalletView());
            _saveStorages.Add(saveStorage);
            return saveStorage.HasSave() ? new WalletWithSave(saveStorage) : new WalletWithSave(defaultWallet, saveStorage);
        }
    }
}