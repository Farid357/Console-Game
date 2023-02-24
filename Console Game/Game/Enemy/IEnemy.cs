namespace Console_Game
{
    public interface IEnemy
    {
        IHealth Health { get; }
        
        IMovement Movement { get; }
        
        IEnemyData Data { get; }
    }
}