using System;
using System.Numerics;

namespace ConsoleGame.Weapons
{
    public sealed class LaserWeaponView : ILaserWeaponView
    {
        public void ShowLaser(Vector3 origin, Vector3 direction)
        {
            Console.WriteLine($"Laser from origin: {origin}, to direction: {direction}");
        }
    }
}