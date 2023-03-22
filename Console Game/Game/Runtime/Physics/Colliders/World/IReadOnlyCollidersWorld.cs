using System.Collections.Generic;

namespace Console_Game.Physics
{
    public interface IReadOnlyCollidersWorld<TModel>
    {
        IReadOnlyDictionary<ICollider, TModel> Models { get; }
    }
}