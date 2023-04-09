namespace ConsoleGame.Physics
{
    public interface ICollidersWorld<TModel> : IReadOnlyCollidersWorld<TModel>
    {
        void Add(TModel model, ICollider collider, Layer layer = Layer.Default);

        void Remove(TModel model);
    }
}