using System.Collections.Generic;

namespace Console_Game.Loop
{
    public interface IGameUpdate
    {
        IReadOnlyList<IUpdateable> Updateables { get; }

        void Add(params IUpdateable[] updateables);

        void Remove(params IUpdateable[] updateables);
    }
}