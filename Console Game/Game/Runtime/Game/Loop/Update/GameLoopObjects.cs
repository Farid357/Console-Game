using System;
using System.Collections.Generic;

namespace Console_Game.Loop
{
    public sealed class GameLoopObjects : IGameLoopObjects
    {
        private readonly List<IGameLoopObject> _loopObjects;

        public GameLoopObjects(List<IGameLoopObject> loopObjects)
        {
            _loopObjects = loopObjects ?? throw new ArgumentNullException(nameof(loopObjects));
        }

        public GameLoopObjects() : this(new List<IGameLoopObject>())
        {
        }

        public IReadOnlyList<IGameLoopObject> All => _loopObjects;

        public void Add(params IGameLoopObject[] objects)
        {
            if (objects == null)
                throw new ArgumentNullException(nameof(objects));

            _loopObjects.AddRange(objects);
        }

        public void Remove(params IGameLoopObject[] objects)
        {
            if (objects == null)
                throw new ArgumentNullException(nameof(objects));

            foreach (var updateable in objects)
            {
                _loopObjects.Remove(updateable);
            }
        }

        public void Update(float deltaTime)
        {
            _loopObjects.ForEach(updateable => updateable.Update(deltaTime));
        }
    }
}