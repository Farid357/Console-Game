namespace ConsoleGame
{
    public interface IEnemiesWorld : IReadOnlyEnemiesWorld
    {
        void Add(IEnemy enemy, EnemyType type);

        void Clear();
    }
}