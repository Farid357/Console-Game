using System.Numerics;

namespace ConsoleGame
{
    public interface IReadOnlyTransform
    {
        Vector3 Position { get; }

        Quaternion Rotation { get; }
    }
}