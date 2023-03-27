namespace ConsoleGame
{
    public interface IMovementFactory
    {
        IMovement Create(ITransform transform);
    }
}