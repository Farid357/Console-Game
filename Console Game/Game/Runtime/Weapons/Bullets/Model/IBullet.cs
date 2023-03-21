using System.Numerics;

namespace Console_Game.Weapons
{
    public interface IBullet
    {
        void Throw(Vector2 direction);

        void Destroy();
    }
}