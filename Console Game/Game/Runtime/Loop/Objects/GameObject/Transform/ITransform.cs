using System.Numerics;

namespace ConsoleGame
{
    public interface ITransform : IReadOnlyTransform
    {
        void Teleport(Vector2 position);

        void Rotate(Quaternion rotation);
    }
}