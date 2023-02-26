using System;

namespace Console_Game.Weapons
{
    public sealed class WeaponMagazineView : IWeaponMagazineView
    {
        public void Visualize(int bullets, int maxBullets)
        {
            Console.WriteLine($"{bullets}/{maxBullets}");
        }
    }
}