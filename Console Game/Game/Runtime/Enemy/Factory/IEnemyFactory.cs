namespace Console_Game
{
    public interface IEnemyFactory
    {
        IEnemy Create(ITransform transform);
    }
}