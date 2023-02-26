using System.Numerics;

namespace Console_Game
{
    public interface ITransformView
    {
        void Teleport(Vector2 position);

        void Rotate(Quaternion rotation);
    }
}