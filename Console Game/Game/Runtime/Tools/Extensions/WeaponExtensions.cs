using ConsoleGame.Weapons;

namespace ConsoleGame.Tools
{
    public static class WeaponExtensions
    {
        public static bool MagazineIsEmpty(this IWeaponWithMagazine weapon)
        {
            return weapon.Magazine.Bullets == 0;
        }
    }
}