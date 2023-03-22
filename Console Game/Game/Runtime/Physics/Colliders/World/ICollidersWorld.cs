namespace Console_Game.Physics
{
    public interface ICollidersWorld<TModel> : IReadOnlyCollidersWorld<TModel>
    {
        void Add(ICollider collider, TModel model);

        void Remove(ICollider collider);
    }
}