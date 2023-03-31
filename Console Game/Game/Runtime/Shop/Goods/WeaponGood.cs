using System;

namespace ConsoleGame.Shop
{
    public sealed class WeaponGood : IGood
    {
        private readonly ICollectionSaveStorage<IWeaponInventoryItem> _weaponsStorage;
        private readonly IWeaponInventoryItem _item;
        private readonly IGood _good;

        public WeaponGood(IGood good, ICollectionSaveStorage<IWeaponInventoryItem> weaponsStorage, IWeaponInventoryItem item)
        {
            _good = good ?? throw new ArgumentNullException(nameof(good));
            _weaponsStorage = weaponsStorage ?? throw new ArgumentNullException(nameof(weaponsStorage));
            _item = item ?? throw new ArgumentNullException(nameof(item));
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