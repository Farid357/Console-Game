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
    }
}