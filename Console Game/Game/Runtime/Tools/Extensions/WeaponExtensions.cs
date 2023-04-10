using System;
using ConsoleGame.Weapons;

namespace ConsoleGame.Tools
{
    public static class WeaponExtensions
    {
        public static bool IsEmpty(this IWeaponMagazine magazine)
        {
            return magazine.Bullets == 0;
        }
        
        public static bool IsNotEmpty(this IWeaponMagazine magazine)
        {
            return !IsEmpty(magazine);
        }
        
        public static bool IsNotFull(this IWeaponMagazine weaponMagazine)
        {
            return weaponMagazine.Bullets < weaponMagazine.MaxBullets;
        }
        
        public static bool CanAdd(this IWeaponMagazine weaponMagazine, int bullets)
        {
            if (bullets <= 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            return weaponMagazine.Bullets + bullets <= weaponMagazine.MaxBullets;
        }
    }
}