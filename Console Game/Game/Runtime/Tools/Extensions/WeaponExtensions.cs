using ConsoleGame.Weapons;

namespace ConsoleGame.Tools
{
    public static class WeaponExtensions
    {
        public static bool MagazineIsEmpty(this IWeaponWithMagazine weapon)
        {
            return weapon.Magazine.Bullets == 0;
        }
        
        public static bool IsNotFull(this IWeaponMagazine weaponMagazine)
        {
            return weaponMagazine.Bullets < weaponMagazine.MaxBullets;
        }
        
        public static void Fill(this IWeaponMagazine weaponMagazine)
        {
            weaponMagazine.Add(weaponMagazine.MaxBullets - weaponMagazine.Bullets);
        }
    }
}