namespace ConsoleGame
{
    public interface IBombFactory
    {
        IBomb Create(ITransform transform);
    }
}