namespace ConsoleGame
{
    public interface IEnemy 
    {
        IHealth Health { get; }
        
        IAdjustableMovement Movement { get; }
    }
}