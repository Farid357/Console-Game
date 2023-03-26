namespace ConsoleGame
{
    public interface IEnemyFactory
    {
        IEnemy Create(ITransform transform);
    }
}