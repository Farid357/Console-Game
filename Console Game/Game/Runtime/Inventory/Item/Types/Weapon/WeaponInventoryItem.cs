using System;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class WeaponInventoryItem : IWeaponInventoryItem
    {
        public WeaponInventoryItem(IInventoryItemViewData viewData, IWeaponWithMagazine weapon, IWeaponInput weaponInput)
        {
            ViewData = viewData ?? throw new ArgumentNullException(nameof(viewData));
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            WeaponInput = weaponInput ?? throw new ArgumentNullException(nameof(weaponInput));
        }

        public IWeaponWithMagazine Weapon { get; }
        
        public IWeaponInput WeaponInput { get; }
        
        public IInventoryItemViewData ViewData { get; }
    }
}