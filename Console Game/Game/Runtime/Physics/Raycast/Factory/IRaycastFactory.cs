namespace ConsoleGame.Physics
{
    public interface IRaycastFactory<T>
    {
        IRaycast<T> Create();
    }
}