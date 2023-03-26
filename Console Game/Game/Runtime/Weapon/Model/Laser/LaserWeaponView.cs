using System;
using System.Numerics;

namespace ConsoleGame.Weapons
{
    public sealed class LaserWeaponView : ILaserWeaponView
    {
        public void ShowLaser(Vector2 origin, Vector2 direction)
        {
            Console.WriteLine($"Laser from origin: {origin}, to direction: {direction}");
        }
    }
}