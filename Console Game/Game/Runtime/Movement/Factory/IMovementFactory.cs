namespace ConsoleGame
{
    public interface IMovementFactory
    {
        IAdjustableMovement Create(ITransform transform);
    }
}