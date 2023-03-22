using System.Numerics;

namespace Console_Game.Weapons
{
    public interface ILaserWeaponView
    {
        void ShowLaser(Vector2 origin, Vector2 direction);
    }
}