namespace ConsoleGame.Physics
{
    public interface ICollidersWorld<TModel> : IReadOnlyCollidersWorld<TModel>
    {
        void Add(ICollider collider, TModel model);

        void Remove(ICollider collider);
    }
}