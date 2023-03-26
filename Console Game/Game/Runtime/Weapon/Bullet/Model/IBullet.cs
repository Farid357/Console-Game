using System.Numerics;

namespace ConsoleGame.Weapons
{
    public interface IBullet
    {
        Vector2 Position { get; }
        
        void Throw(Vector2 direction);

        void Destroy();
    }
}