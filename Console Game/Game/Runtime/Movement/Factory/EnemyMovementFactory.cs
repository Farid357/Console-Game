using System;
using ConsoleGame.GameLoop;

namespace ConsoleGame
{
    public sealed class EnemyMovementFactory : IMovementFactory
    {
        private readonly IGameLoopObjectsGroup _physicsGameLoop;

        public EnemyMovementFactory(IGameLoopObjectsGroup physicsGameLoop)
        {
            _physicsGameLoop = physicsGameLoop ?? throw new ArgumentNullException(nameof(physicsGameLoop));
        }

        public IAdjustableMovement Create(ITransform transform)
        {
            var rigidbody = new Rigidbody(1.5f, 9.2f, 2.5f, transform);
            var physicsMovement = new PhysicsMovement(rigidbody, transform);
            _physicsGameLoop.Add(physicsMovement);
            return new AdjustableMovement(physicsMovement, 2f);
        }
    }
}