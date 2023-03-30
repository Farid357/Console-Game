namespace ConsoleGame
{
    public interface IShootersSimulationFactory
    {
        IShootersSimulation<TShooter, TWeapon> Create<TShooter, TWeapon>() where TShooter : IShooter<TWeapon>;
    }
}