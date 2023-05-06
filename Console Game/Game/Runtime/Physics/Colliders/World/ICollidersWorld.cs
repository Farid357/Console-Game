namespace ConsoleGame.Physics
{
    public interface ICollidersWorld<TModel> : IReadOnlyCollidersWorld<TModel>
    {
        void Add(TModel model, ICollider collider);

        void Remove(TModel model);
    }
}