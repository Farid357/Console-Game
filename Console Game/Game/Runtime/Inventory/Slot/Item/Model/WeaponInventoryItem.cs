using System;
using ConsoleGame.Tests;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class WeaponInventoryItem<TWeapon> : IWeaponInventoryItem<TWeapon> where TWeapon : IWeapon
    {
        private readonly IInventoryItem _item;
        private readonly ICharacter _character;
        private readonly IWeaponView _weaponView;
        private readonly IWeapon _fakeWeapon;

        public WeaponInventoryItem(IInventoryItem item, ICharacter character, TWeapon weapon, IWeaponView weaponView)
        {
            _item = item ?? throw new ArgumentNullException(nameof(item));
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));
            Weapon = weapon;
            _fakeWeapon = new DummyWeapon();
        }

        public TWeapon Weapon { get; }

        public IInventoryItemViewData ViewData => _item.ViewData;

        public bool IsSelected => _item.IsSelected;

        public void Select()
        {
            _character.SwitchWeapons(_fakeWeapon, Weapon);
            _weaponView.Enable();
            _item.Select();
        }

        public void Unselect()
        {
            _character.TakeAwayWeapons();
            _weaponView.Disable();
            _item.Unselect();
        }
    }
}