using System;
using System.Linq;
using ConsoleGame.Tools;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class BulletsBonus : IBonus
    {
        private readonly IBonus _bonus;
        private readonly IInventory<IWeaponInventoryItem> _inventory;

        public BulletsBonus(IBonus bonus, IInventory<IWeaponInventoryItem> inventory)
        {
            _bonus = bonus ?? throw new ArgumentNullException(nameof(bonus));
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
        }

        public bool IsAlive => _bonus.IsAlive;

        public void Pick()
        {
            _bonus.Pick();
            AddBullets();
        }

        private void AddBullets()
        {
            foreach (IWeaponParts weaponData in _inventory.Slots.Select(slot => slot.Item.WeaponParts))
            {
                IWeaponMagazine weaponMagazine = weaponData.Magazine;

                if (!weaponMagazine.IsNotFull()) 
                    continue;
                
                int bullets = weaponMagazine.MaxBullets / 2;

                if (weaponMagazine.CanAdd(bullets))
                {
                    weaponMagazine.Add(bullets);
                }
                else
                {
                    weaponMagazine.Add(weaponMagazine.MaxBullets - weaponMagazine.Bullets);
                }
            }
        }
    }
}