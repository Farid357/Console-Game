using System;
using System.Collections.Generic;
using System.Numerics;

namespace ConsoleGame.Rendering
{
    public sealed class MeshData : IMeshData
    {
        public MeshData(IReadOnlyList<int> triangles, IReadOnlyList<Vector3> vertices, IReadOnlyList<Vector2> uv)
        {
            if (uv.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(uv));

            if (triangles.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(triangles));

            if (vertices.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(vertices));

            Triangles = triangles ?? throw new ArgumentNullException(nameof(triangles));
            Vertices = vertices ?? throw new ArgumentNullException(nameof(vertices));
            Uv = uv ?? throw new ArgumentNullException(nameof(uv));
        }
        
        public IReadOnlyList<int> Triangles { get; }

        public IReadOnlyList<Vector3> Vertices { get; }

        public IReadOnlyList<Vector2> Uv { get; }
    }
}