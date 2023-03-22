using System;

namespace Console_Game.Shop
{
    public sealed class WeaponGood : IGood
    {
        private readonly ICollectionSaveStorage<IWeaponInventoryItem> _weaponsStorage;
        private readonly IWeaponInventoryItem _item;
        private readonly IGood _good;

        public WeaponGood(IGood good, IWeaponInventoryItem item, ICollectionSaveStorage<IWeaponInventoryItem> saveStorage)
        {
            _good = good ?? throw new ArgumentNullException(nameof(good));
            _item = item ?? throw new ArgumentNullException(nameof(item));
            _weaponsStorage = saveStorage ?? throw new ArgumentNullException(nameof(saveStorage));
        }

        public string Name => _good.Name;

        public int Cost => _good.Cost;

        public void Use()
        {
            _good.Use();
            _weaponsStorage.Add(_item);
        }
    }
}