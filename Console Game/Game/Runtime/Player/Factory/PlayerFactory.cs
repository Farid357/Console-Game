using System;
using ConsoleGame.GameLoop;

namespace ConsoleGame
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly ICharacter _character;
        private readonly IWeapon _weapon;

        public PlayerFactory(IGameLoopObjectsGroup gameLoop, ICharacter character, IWeapon weapon)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public IPlayer Create()
        {
            var input = new PlayerInput();
            _gameLoop.Add(input);
            IPlayer player = new Player(input, _character);
            _gameLoop.Add(player);
            return player;
        }
    }
}