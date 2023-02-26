namespace Console_Game
{
    public interface IEnemyFactory
    {
        IEnemy Create(IReadOnlyTransform transform);
    }
}