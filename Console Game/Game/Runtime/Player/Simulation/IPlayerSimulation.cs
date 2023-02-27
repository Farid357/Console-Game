namespace Console_Game
{
    public interface IPlayersSimulation<TPlayer> : IReadOnlyPlayersSimulation<TPlayer> where TPlayer : IPlayer
    {
        void DeleteCurrentPlayer();

        void Add(TPlayer player);
    }
}