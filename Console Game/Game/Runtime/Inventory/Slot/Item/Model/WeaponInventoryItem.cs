using System;

namespace ConsoleGame
{
    public sealed class WeaponInventoryItem : IWeaponInventoryItem
    {
        private readonly IInventoryItem _item;

        public WeaponInventoryItem(IInventoryItem item, IWeapon weapon, IWeaponPartsData data)
        {
            _item = item ?? throw new ArgumentNullException(nameof(item));
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            WeaponPartsData = data ?? throw new ArgumentNullException(nameof(data));
        }

        public IWeapon Weapon { get; }

        public IWeaponPartsData WeaponPartsData { get; }

        public IInventoryItemViewData ViewData => _item.ViewData;

        public bool IsSelected => _item.IsSelected;

        public void Select()
        {
            Weapon.View.Enable();
            _item.Select();
        }

        public void Unselect()
        {
            Weapon.View.Disable();
            _item.Unselect();
        }
    }
}