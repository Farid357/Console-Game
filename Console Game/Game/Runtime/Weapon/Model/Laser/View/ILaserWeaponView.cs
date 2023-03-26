using System.Numerics;

namespace ConsoleGame.Weapons
{
    public interface ILaserWeaponView
    {
        void ShowLaser(Vector2 origin, Vector2 direction);
    }
}