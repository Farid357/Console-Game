using Console_Game.Loop;

namespace Console_Game
{
    public sealed class PlayerSimulationFactory : IPlayerSimulationFactory
    {
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;

        public PlayerSimulationFactory(IGroup<IGameLoopObject> gameLoopObjects)
        {
            _gameLoopObjects = gameLoopObjects;
        }

        public IPlayersSimulation<TPlayer> Create<TPlayer>() where TPlayer : IPlayer
        {
            IPlayersSimulation<TPlayer> simulation = new PlayersSimulation<TPlayer>(_gameLoopObjects, new PlayersSimulationView<TPlayer>());
            return new SelfCleaningPlayerSimulation<TPlayer>(simulation);
        }
    }
}