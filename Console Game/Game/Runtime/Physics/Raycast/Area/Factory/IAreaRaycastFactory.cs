namespace ConsoleGame.Physics.Factory
{
    public interface IAreaRaycastFactory<TTarget>
    {
        IAreaRaycast<TTarget> Create();
    }
}