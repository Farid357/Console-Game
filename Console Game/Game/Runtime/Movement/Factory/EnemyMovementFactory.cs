using ConsoleGame.Physics;

namespace ConsoleGame
{
    public sealed class EnemyMovementFactory : IMovementFactory
    {
        public IAdjustableMovement Create(ITransform transform)
        {
            IRigidbody rigidbody = new Rigidbody(1.5f, 9.2f, 2.5f, transform);
            IMovement physicsMovement = new PhysicsMovement(rigidbody);
            return new AdjustableMovement(physicsMovement, 2f);
        }
    }
}