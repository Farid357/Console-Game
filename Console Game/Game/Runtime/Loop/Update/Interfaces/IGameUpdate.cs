using System.Collections.Generic;

namespace Console_Game.Loop
{
    public interface IGameUpdate
    {
        IReadOnlyList<IGameLoopObject> LoopObjects { get; }

        void Add(params IGameLoopObject[] loopObjects);

        void Remove(params IGameLoopObject[] loopObjects);
    }
}