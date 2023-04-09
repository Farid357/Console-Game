using System;
using ConsoleGame.GameLoop;

namespace ConsoleGame
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly ICharacter _character;

        public PlayerFactory(IGameLoopObjectsGroup gameLoop, ICharacter character)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }

        public IPlayer Create()
        {
            var input = new PlayerInput();
            var player = new Player(input, _character);
            _gameLoop.Add(input);
            _gameLoop.Add(player);
            return player;
        }
    }
}