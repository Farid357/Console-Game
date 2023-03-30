using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class CharacterFactory : ICharacterFactory
    {
        private readonly IMovementFactory _movementFactory;
        private readonly IHealthFactory _healthFactory;

        public CharacterFactory(IMovementFactory movementFactory, IHealthFactory healthFactory)
        {
            _movementFactory = movementFactory ?? throw new ArgumentNullException(nameof(movementFactory));
            _healthFactory = healthFactory ?? throw new ArgumentNullException(nameof(healthFactory));
        }

        public ICharacter Create()
        {
            ITransform transform = new Transform(Vector3.Zero);
            IAdjustableMovement movement = _movementFactory.Create(transform);
            IHealth health = _healthFactory.Create();
            return new Character(health, movement);
        }
    }
}