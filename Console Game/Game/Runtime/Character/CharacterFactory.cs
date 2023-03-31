using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class CharacterFactory : ICharacterFactory
    {
        private readonly IAdjustableMovement _movement;
        private readonly IHealthFactory _healthFactory;
        private readonly IWeapon _weapon;

        public CharacterFactory(IAdjustableMovement movement, IHealthFactory healthFactory, IWeapon weapon)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _healthFactory = healthFactory ?? throw new ArgumentNullException(nameof(healthFactory));
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public ICharacter Create()
        {
            ITransform transform = new Transform(Vector3.Zero);
            IHealth health = _healthFactory.Create();
            return new Character(health, _movement, _weapon);
        }
    }
}