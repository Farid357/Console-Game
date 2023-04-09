namespace ConsoleGame.Physics
{
    public interface IColliderFactory
    {
        ICollider Create(IReadOnlyTransform transform);
    }
}