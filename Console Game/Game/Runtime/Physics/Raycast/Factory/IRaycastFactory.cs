namespace ConsoleGame.Physics
{
    public interface IRaycastFactory<TTarget>
    {
        IRaycast<TTarget> Create();
    }
}