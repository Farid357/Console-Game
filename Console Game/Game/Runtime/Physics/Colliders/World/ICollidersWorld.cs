namespace ConsoleGame.Physics
{
    public interface ICollidersWorld<TModel> : IReadOnlyCollidersWorld<TModel>
    {
        void Add(TModel model, ICollider collider, LayerMask layerMask = LayerMask.Default);

        void Remove(TModel model, LayerMask layerMask = LayerMask.Default);
    }
}