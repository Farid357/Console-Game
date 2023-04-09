using System.Numerics;

namespace ConsoleGame.Physics
{
    public sealed class BoxColliderFactory : IColliderFactory
    {
        private readonly Vector3 _size;

        public BoxColliderFactory(Vector3 size)
        {
            _size = size;
        }

        public ICollider Create(IReadOnlyTransform transform)
        {
            ICollider collider = new BoxCollider(_size, transform);
            return collider;
        }
    }
}