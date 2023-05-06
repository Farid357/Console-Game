using ConsoleGame.Physics;

namespace ConsoleGame
{
    public class BulletMovementFactory : IMovementFactory
    {
        public IAdjustableMovement Create(ITransform transform)
        {
            IRigidbody rigidbody = new Rigidbody(1f, 9.2f, 5f, transform);
            IMovement physicsMovement = new PhysicsMovement(rigidbody);
            return new AdjustableMovement(physicsMovement, 10f);
        }
    }
}