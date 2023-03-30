namespace ConsoleGame
{
    public interface IShootersSimulation<in TShooter, out TWeapon> : IReadOnlyPlayersSimulation<TWeapon>
    {
        void Add(TShooter shooter);
        
        void DeleteCurrentPlayer();

    }
}