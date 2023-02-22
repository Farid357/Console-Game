namespace Console_Game
{
    public interface IEnemy
    {
        IHealth Health { get; }
        
        IEnemyMovement Movement { get; }
        
        IEnemyData Data { get; }
    }
}