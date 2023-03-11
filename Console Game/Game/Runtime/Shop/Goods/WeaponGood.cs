using System;
using Console_Game.Save_Storages;

namespace Console_Game.Shop
{
    public sealed class WeaponGood<TInput, TModel> : IGood where TInput : IWeaponInput where TModel : IWeapon
    {
        private readonly ISaveStorage<IWeaponInventoryItem<TInput, TModel>> _saveStorage;
        private readonly IWeaponInventoryItem<TInput, TModel> _item;
        private readonly IGood _good;

        public WeaponGood(IGood good, ISaveStorage<IWeaponInventoryItem<TInput, TModel>> saveStorage, IWeaponInventoryItem<TInput, TModel> item)
        {
            _good = good ?? throw new ArgumentNullException(nameof(good));
            _saveStorage = saveStorage ?? throw new ArgumentNullException(nameof(saveStorage));
            _item = item ?? throw new ArgumentNullException(nameof(item));
        }

        public string Name => _good.Name;

        public int Cost => _good.Cost;

        public void Use()
        {
            _good.Use();
            
            //TODO: Save Weapon Correct
            _saveStorage.Save(_item);
        }
    }
}