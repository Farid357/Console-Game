using System;
using System.Numerics;

namespace ConsoleGame.Physics
{
    public sealed class BoxCollider : ICollider
    {
        private readonly Vector3 _size;

        public BoxCollider(Vector3 size, IReadOnlyTransform transform)
        {
            _size = size;
            Transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public IReadOnlyTransform Transform { get; }

        public bool Contains(Vector3 point)
        {
            return Vector3.Distance(Transform.Position, point) <= Vector3.Distance(Transform.Position, _size);
        }
    }
}