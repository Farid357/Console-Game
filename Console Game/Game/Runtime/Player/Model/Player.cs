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
            if (_input.IsUsing && _character.IsAlive)
            {
                Vector3 moveDirection = _input.Direction();
                _character.Move(moveDirection);
            }
        }
    }
}