using System.Collections.Generic;

namespace ConsoleGame.Physics
{
    public interface IReadOnlyCollidersWorld<TModel>
    {
        IReadOnlyDictionary<TModel, ICollider> Colliders(Layer layer);
        
        IReadOnlyDictionary<TModel, ICollider> AllColliders { get; }
    }
}