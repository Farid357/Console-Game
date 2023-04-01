namespace ConsoleGame
{
    public sealed class EnemyMovementFactory : IMovementFactory
    {
        public IAdjustableMovement Create(ITransform transform)
        {
            var rigidbody = new Rigidbody(1.5f, 9.2f, 2.5f, transform);
            var physicsMovement = new PhysicsMovement(rigidbody);
            return new AdjustableMovement(physicsMovement, 2f);
        }
    }
}