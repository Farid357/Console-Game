using System;
using ConsoleGame.Tests;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class WeaponInventoryItem : IWeaponInventoryItem
    {
        private readonly IInventoryItem _item;
        private readonly ICharacter _character;

        public WeaponInventoryItem(IInventoryItem item, ICharacter character, IWeapon weapon)
        {
            _item = item ?? throw new ArgumentNullException(nameof(item));
            _character = character ?? throw new ArgumentNullException(nameof(character));
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public IWeapon Weapon { get; }

        public IInventoryItemViewData ViewData => _item.ViewData;

        public bool IsSelected => _item.IsSelected;

        public void Select()
        {
            Weapon.Enable();
            _character.SwitchWeapon(Weapon);
            _item.Select();
        }

        public void Unselect()
        {
            Weapon.Disable();
            _character.TakeAwayWeapons();
            _item.Unselect();
        }
    }
}