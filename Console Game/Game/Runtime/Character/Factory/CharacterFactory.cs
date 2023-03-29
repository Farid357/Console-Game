using System;
using System.Numerics;
using ConsoleGame.GameLoop;

namespace ConsoleGame
{
    public sealed class CharacterFactory : ICharacterFactory
    {
        private readonly IMovementFactory _movementFactory;
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IHealthFactory _healthFactory;

        public CharacterFactory(IMovementFactory movementFactory, IGameLoopObjectsGroup gameLoop, IHealthFactory healthFactory)
        {
            _movementFactory = movementFactory ?? throw new ArgumentNullException(nameof(movementFactory));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _healthFactory = healthFactory ?? throw new ArgumentNullException(nameof(healthFactory));
        }

        public ICharacter Create()
        {
            var movementInput = new CharacterMovementInput();
            _gameLoop.Add(movementInput);
            ITransform transform = new Transform(Vector3.Zero);
            IMovement movement = _movementFactory.Create(transform);
            IHealth health = _healthFactory.Create();
            return new Character(movementInput, movement, health);
        }
    }
}