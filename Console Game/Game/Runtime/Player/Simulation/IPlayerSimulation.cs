namespace ConsoleGame
{
    public interface IPlayersSimulation<in TPlayer> : IReadOnlyPlayersSimulation where TPlayer : IPlayer
    {
        void DeleteCurrentPlayer();

        void Add(TPlayer player);
    }
}