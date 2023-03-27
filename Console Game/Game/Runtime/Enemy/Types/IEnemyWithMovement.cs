namespace ConsoleGame
{
    public interface IEnemyWithMovement : IEnemy
    {
        IAdjustableMovement Movement { get; }
    }
}