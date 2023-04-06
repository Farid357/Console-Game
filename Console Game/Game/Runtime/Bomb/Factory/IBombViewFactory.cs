namespace ConsoleGame
{
    public interface IBombViewFactory
    {
        IBombView Create(ITransform transform);
    }
}