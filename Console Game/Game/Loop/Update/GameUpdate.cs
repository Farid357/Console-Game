using System;
using System.Collections.Generic;

namespace Console_Game.Loop
{
    public sealed class GameUpdate : IGameUpdate, IGameLoopObject
    {
        private readonly List<IGameLoopObject> _loopObjects;

        public GameUpdate(List<IGameLoopObject> loopObjects)
        {
            _loopObjects = loopObjects ?? throw new ArgumentNullException(nameof(loopObjects));
        }

        public GameUpdate() : this(new List<IGameLoopObject>())
        {
        }

        public IReadOnlyList<IGameLoopObject> LoopObjects => _loopObjects;

        public void Add(params IGameLoopObject[] loopObjects)
        {
            if (loopObjects == null)
                throw new ArgumentNullException(nameof(loopObjects));

            _loopObjects.AddRange(loopObjects);
        }

        public void Remove(params IGameLoopObject[] loopObjects)
        {
            if (loopObjects == null)
                throw new ArgumentNullException(nameof(loopObjects));

            foreach (var updateable in loopObjects)
            {
                _loopObjects.Remove(updateable);
            }
        }

        public void Update(long deltaTime)
        {
            _loopObjects.ForEach(updateable => updateable.Update(deltaTime));
        }
    }
}