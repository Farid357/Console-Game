using System.Collections.Generic;
using System.Numerics;

namespace ConsoleGame.Rendering
{
    public interface IMeshData
    {
        IReadOnlyList<int> Triangles { get; }

        IReadOnlyList<Vector3> Vertices { get; }

        IReadOnlyList<Vector2> Uv { get; }
    }
}