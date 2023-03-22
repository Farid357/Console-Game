namespace Console_Game
{
    public interface IPlayersSimulation<in TPlayer> : IReadOnlyPlayersSimulation where TPlayer : IPlayer
    {
        void DeleteCurrentPlayer();

        void Add(TPlayer player);
    }
}