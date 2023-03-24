using System.Collections.Generic;

namespace Console_Game
{
    public interface ITransformParent : ITransform
    {
        IReadOnlyList<ITransform> Children { get; }
        
        void Add(ITransform child);

        void Remove(ITransform child);
    }
}