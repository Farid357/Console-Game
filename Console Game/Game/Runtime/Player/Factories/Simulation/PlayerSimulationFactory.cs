using System;
using ConsoleGame.GameLoop;

namespace ConsoleGame
{
    public sealed class PlayerSimulationFactory : IPlayerSimulationFactory
    {
        private readonly IGameLoopObjectsGroup _gameLoop;

        public PlayerSimulationFactory(IGameLoopObjectsGroup gameLoop)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }

        public IPlayersSimulation<TPlayer> Create<TPlayer>() where TPlayer : IPlayer
        {
            IPlayersSimulation<TPlayer> simulation = new PlayersSimulation<TPlayer>(_gameLoop);
            return new SelfCleaningPlayerSimulation<TPlayer>(simulation);
        }
    }
}