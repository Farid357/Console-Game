namespace Console_Game
{
    public interface IPlayersSimulationView<in TPlayer> where TPlayer : IPlayer
    {
        void DeletePlayer(TPlayer player);
        
        void CreatePlayer(TPlayer player);
    }
}