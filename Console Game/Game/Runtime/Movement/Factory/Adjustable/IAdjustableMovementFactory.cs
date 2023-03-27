namespace ConsoleGame
{
    public interface IAdjustableMovementFactory
    {
        IAdjustableMovement Create(ITransform transform);
    }
}