using System;

namespace ConsoleGame
{
    public sealed class Character : IGameObject, ICharacter
    {
        private readonly ICharacterMovementInput _movementInput;
        private readonly IMovement _movement;

        public Character(ICharacterMovementInput movementInput, IMovement movement, IHealth health)
        {
            _movementInput = movementInput ?? throw new ArgumentNullException(nameof(movementInput));
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            Health = health ?? throw new ArgumentNullException(nameof(health));
        }

        public IHealth Health { get; }
        
        public IReadOnlyTransform Transform => _movement.Transform;

        public bool IsAlive => Health.IsAlive;

        public void Update(float deltaTime)
        {
            if (!IsAlive)
                throw new Exception($"Character is died, you can't update it!");

            if (_movementInput.IsUsing)
                _movement.Move(_movementInput.Direction());
        }
    }
}