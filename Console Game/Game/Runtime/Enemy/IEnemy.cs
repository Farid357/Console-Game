namespace ConsoleGame
{
    public interface IEnemy : IAlive
    {
        IHealth Health { get; }
    }
}