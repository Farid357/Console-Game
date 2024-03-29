using System;
using System.Numerics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class Player : IPlayer, IGameLoopObject
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
                Vector3 moveDirection = _input.MoveDirection();
                _character.Move(moveDirection);
            }

            if (_input.IsShooting && _character.CanShoot && _character.WeaponData().IsBurst == false)
            {
                _character.Shoot();
            }
            
            if (_input.IsShootingBurst && _character.CanShoot && _character.WeaponData().IsBurst)
            {
                _character.Shoot();
            }

            if (_input.IsReloading)
            {
                _character.WeaponData().Magazine.Fill();
            }
        }
    }
}