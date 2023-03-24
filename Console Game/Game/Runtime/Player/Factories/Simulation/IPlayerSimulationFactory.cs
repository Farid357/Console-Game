namespace Console_Game
{
    public interface IPlayerSimulationFactory
    {
        IPlayersSimulation<TPlayer> Create<TPlayer>() where TPlayer : IPlayer;
    }
}