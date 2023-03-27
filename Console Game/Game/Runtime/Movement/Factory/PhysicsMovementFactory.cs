using System;
using ConsoleGame.Loop;

namespace ConsoleGame
{
    public sealed class PhysicsMovementFactory : IMovementFactory
    {
        private readonly IGameLoopObjectsGroup _gameLoop;

        public PhysicsMovementFactory(IGameLoopObjectsGroup gameLoop)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }

        public IMovement Create(ITransform transform)
        {
            var rigidbody = new Rigidbody(1.5f, 9.2f, 2.5f, transform);
            var movement = new PhysicsMovement(rigidbody, transform);
            _gameLoop.Add(movement);
            return movement;
        }
    }
}