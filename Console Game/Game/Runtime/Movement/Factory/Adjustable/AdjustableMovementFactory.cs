using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class AdjustableMovementFactory : IAdjustableMovementFactory
    {
        private readonly IMovementFactory _movementFactory;
        private readonly float _speed;

        public AdjustableMovementFactory(IMovementFactory movementFactory, float speed)
        {
            _movementFactory = movementFactory ?? throw new ArgumentNullException(nameof(movementFactory));
            _speed = speed.ThrowIfLessOrEqualsToZeroException();
        }

        public IAdjustableMovement Create(ITransform transform)
        {
            return new AdjustableMovement(_movementFactory.Create(transform), _speed);
        }
    }
}