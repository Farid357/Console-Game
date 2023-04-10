using System;
using System.Collections.Generic;

namespace ConsoleGame.GameLoop
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
        
        public void Add(IGameLoopObject instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            _loopObjects.Add(instance);
        }

        public void Update(float deltaTime)
        {
            _loopObjects.ForEach(updateable => updateable.Update(deltaTime));
        }
    }
}