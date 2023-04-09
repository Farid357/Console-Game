namespace ConsoleGame.Physics
{
    public interface IAreaRaycastFactory<TTarget>
    {
        IAreaRaycast<TTarget> Create();
    }
}