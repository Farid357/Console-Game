using System;

namespace Console_Game
{
    public sealed class WeaponInventoryItem<TInput, TWeapon> : IWeaponInventoryItem<TInput, TWeapon> where TInput : IWeaponInput where TWeapon : IWeapon
    {
        private readonly IInventoryItem _item;
        private readonly IPlayerFactory<TWeapon, TInput> _playerFactory;

        public WeaponInventoryItem(IInventoryItem item, TWeapon weapon, TInput weaponInput, IPlayerFactory<TWeapon, TInput> playerFactory)
        {
            _item = item ?? throw new ArgumentNullException(nameof(item));
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
            Weapon = weapon;
            WeaponInput = weaponInput;
        }

        public TWeapon Weapon { get; }

        public TInput WeaponInput { get; }

        public IInventoryItemViewData ViewData => _item.ViewData;

        public bool IsSelected => _item.IsSelected;

        public void Unselect() => _item.Unselect();

        public void Select()
        {
            _playerFactory.Create(WeaponInput, Weapon);
            _item.Select();
        }
    }
}