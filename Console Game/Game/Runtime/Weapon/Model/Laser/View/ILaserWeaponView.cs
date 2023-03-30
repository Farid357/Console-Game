using System.Numerics;

namespace ConsoleGame.Weapons
{
    public interface ILaserWeaponView
    {
        void ShowLaser(Vector3 origin, Vector3 direction);
    }
}