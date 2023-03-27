using System.Numerics;

namespace ConsoleGame.Weapons
{
    public interface IBullet
    {
        void Throw(Vector3 direction);
    }
}