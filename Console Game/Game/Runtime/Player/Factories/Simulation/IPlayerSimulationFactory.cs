namespace ConsoleGame
{
    public interface IPlayerSimulationFactory
    {
        IPlayersSimulation<TPlayer> Create<TPlayer>() where TPlayer : IPlayer;
    }
}