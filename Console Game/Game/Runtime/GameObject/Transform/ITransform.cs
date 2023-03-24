using System.Numerics;

namespace Console_Game
{
    public interface ITransform : IReadOnlyTransform
    {
        void Teleport(Vector2 position);

        void Rotate(Quaternion rotation);
    }
}