using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Game
{
    public sealed class GameObjects : IGameObjects
    {
        private readonly List<IGameObject> _gameObjects;

        public GameObjects(List<IGameObject> gameObjects)
        {
            _gameObjects = gameObjects ?? throw new ArgumentNullException(nameof(gameObjects));
        }

        public GameObjects() : this(new List<IGameObject>())
        {
            
        }
        
        public bool IsActive => _gameObjects.All(gameObject => gameObject.IsActive);

        public IReadOnlyList<IGameObject> All => _gameObjects;
     
        public void Enable()
        {
            _gameObjects.ForEach(gameObject => gameObject.Enable());
        }

        public void Disable()
        {
            _gameObjects.ForEach(gameObject => gameObject.Disable());
        }

        public void Destroy()
        {
            _gameObjects.ForEach(gameObject => gameObject.Destroy());
        }

        
        public void Add(IGameObject instance) => _gameObjects.Add(instance);

        public void Remove(IGameObject instance) => _gameObjects.Remove(instance);
        
    }
}