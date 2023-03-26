using System.Numerics;

namespace ConsoleGame.Physics
{
    public sealed class BoxCollider : ICollider
    {
        private readonly Box _box;

        public BoxCollider(Box box, Vector3 center)
        {
            _box = box;
            Center = center;
        }

        public Vector3 Center { get; }

        public bool Contains(Vector3 point)
        {
            return Vector3.Distance(Center, point) <= Vector3.Distance(Center, _box.Size);
        }
    }
}