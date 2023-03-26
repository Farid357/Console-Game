using System.Collections.Generic;

namespace ConsoleGame.Physics
{
    public interface IReadOnlyCollidersWorld<TModel>
    {
        IReadOnlyDictionary<ICollider, TModel> Models { get; }
    }
}