using System.Collections.Generic;

namespace Console_Game.Loop
{
    public interface IGroup<TObject>
    {
        IReadOnlyList<TObject> All { get; }

        void Add(TObject instance);

        void Remove(TObject instance);
    }
}