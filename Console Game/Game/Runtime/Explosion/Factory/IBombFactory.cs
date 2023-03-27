using System.Numerics;

namespace ConsoleGame.Explosion
{
    public interface IBombFactory
    {
        IBomb Create(Vector3 position);
    }
}