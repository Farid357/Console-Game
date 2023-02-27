using System;

namespace Console_Game
{
    public sealed class WeaponInventoryItem<TWeaponInput, TWeapon> : IInventoryItem
        where TWeaponInput : IWeaponInput where TWeapon : IWeapon
    {
        private readonly IInventoryItem _item;
        private readonly IPlayerFactory<TWeapon, TWeaponInput> _playerFactory;
        private readonly TWeapon _weapon;
        private readonly TWeaponInput _weaponInput;

        public WeaponInventoryItem(IInventoryItem item, TWeapon weapon, TWeaponInput weaponInput, IPlayerFactory<TWeapon, TWeaponInput> playerFactory)
        {
            _item = item ?? throw new ArgumentNullException(nameof(item));
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
            _weapon = weapon;
            _weaponInput = weaponInput;
        }

        public IInventoryItemViewData ViewData => _item.ViewData;

        public bool IsSelected => _item.IsSelected;

        public void Unselect() => _item.Unselect();

        public void Select()
        {
            _playerFactory.Create(_weaponInput, _weapon);
        }
    }
}