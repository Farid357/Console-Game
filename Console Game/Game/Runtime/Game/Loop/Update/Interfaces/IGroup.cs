using System.Collections.Generic;

namespace Console_Game.Loop
{
    public interface IGroup<TObject>
    {
        IReadOnlyList<TObject> All { get; }

        void Add(params TObject[] objects);

        void Remove(params TObject[] objects);
    }
}