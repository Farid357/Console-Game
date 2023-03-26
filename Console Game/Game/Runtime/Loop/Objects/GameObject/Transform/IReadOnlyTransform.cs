using System.Numerics;

namespace ConsoleGame
{
    public interface IReadOnlyTransform
    {
        Vector2 Position { get; }

        Quaternion Rotation { get; }
    }
}