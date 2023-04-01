using System.Numerics;

namespace ConsoleGame
{
    public interface ITransform : IReadOnlyTransform
    {
        void Teleport(Vector3 position);

        void Rotate(Quaternion rotation);
    }
}