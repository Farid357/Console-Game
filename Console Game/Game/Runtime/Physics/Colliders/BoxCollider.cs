using System.Numerics;

namespace ConsoleGame.Physics
{
    public sealed class BoxCollider : ICollider
    {
        private readonly Vector3 _size;

        public BoxCollider(Vector3 size, Vector3 center)
        {
            _size = size;
            Center = center;
        }

        public Vector3 Center { get; }

        public bool Contains(Vector3 point)
        {
            return Vector3.Distance(Center, point) <= Vector3.Distance(Center, _size);
        }
    }
}