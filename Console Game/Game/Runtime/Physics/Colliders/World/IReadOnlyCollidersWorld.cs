using System.Collections.Generic;

namespace ConsoleGame.Physics
{
    public interface IReadOnlyCollidersWorld<TModel>
    {   
        IReadOnlyDictionary<TModel, ICollider> AllColliders { get; }
    }
}