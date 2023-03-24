using System.Numerics;

namespace Console_Game.Weapons
{
    public interface IBullet : IGameObject
    {
        Vector2 Position { get; }
        
        void Throw(Vector2 direction);

        void Destroy();
    }
}