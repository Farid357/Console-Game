using System.Numerics;

namespace ConsoleGame.Weapons
{
    public interface ILaserView : IWeaponActivityView
    {
        void ShowLaser(Vector3 origin, Vector3 direction);
    }
}