using System.Numerics;

namespace Console_Game
{
    public interface IReadOnlyTransform
    {
        Vector2 Position { get; }

        Quaternion Rotation { get; }
    }
}