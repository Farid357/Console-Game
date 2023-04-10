namespace ConsoleGame
{
    public interface IEnemy : IReadOnlyGameObject
    {
        IHealth Health { get; }
    }
}