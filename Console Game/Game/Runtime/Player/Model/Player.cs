using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class Player : IPlayer
    {
        private readonly IPlayerInput _input;
        private readonly ICharacter _character;

        public Player(IPlayerInput input, ICharacter character)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }
        
        public void Update(float deltaTime)
        {
            if (!_character.IsAlive)
                return;
            
            if (_input.IsMoving)
            {
                Vector3 moveDirection = _input.Direction();
                _character.Move(moveDirection);
            }

            if (_input.IsShooting && _character.CanShoot)
            {
                _character.Shoot();
            }
        }
    }
}