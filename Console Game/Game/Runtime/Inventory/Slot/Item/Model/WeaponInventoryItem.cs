using System;

namespace ConsoleGame
{
    public sealed class WeaponInventoryItem : IWeaponInventoryItem
    {
        private readonly IInventoryItem _item;

        public WeaponInventoryItem(IInventoryItem item, IWeapon weapon, IWeaponParts data)
        {
            _item = item ?? throw new ArgumentNullException(nameof(item));
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            WeaponParts = data ?? throw new ArgumentNullException(nameof(data));
        }

        public IWeapon Weapon { get; }

        public IWeaponParts WeaponParts { get; }

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