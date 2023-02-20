using System.Numerics;

namespace Console_Game
{
    public interface IEnemy
    {
        IHealth Health { get; }
        
        Vector2 Position { get; }
    }
}