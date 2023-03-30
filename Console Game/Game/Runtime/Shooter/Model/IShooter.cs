namespace ConsoleGame
{
    public interface IShooter<out TWeapon> : IReadOnlyShooter<TWeapon>, IGameLoopObject
    {
     
    }
}