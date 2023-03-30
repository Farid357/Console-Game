using System;

namespace ConsoleGame.Shop
{
    public sealed class WeaponGood<TWeapon> : IGood where TWeapon : IWeapon
    {
        private readonly ICollectionSaveStorage<IWeaponInventoryItem<TWeapon>> _weaponsStorage;
        private readonly IWeaponInventoryItem<TWeapon> _item;
        private readonly IGood _good;

        public WeaponGood(IGood good, ICollectionSaveStorage<IWeaponInventoryItem<TWeapon>> weaponsStorage, IWeaponInventoryItem<TWeapon> item)
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