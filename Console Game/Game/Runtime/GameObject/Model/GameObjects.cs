using System;
using System.Collections.Generic;

namespace Console_Game
{
    public sealed class GameObjects : IGameObjects
    {
        private readonly List<IGameObject> _gameObjects;

        public GameObjects(List<IGameObject> gameObjects)
        {
            _gameObjects = gameObjects ?? throw new ArgumentNullException(nameof(gameObjects));
        }

        public bool IsActive { get; private set; }

        public IReadOnlyList<IGameObject> All => _gameObjects;
     
        // public void Enable()
        // {
        //     _gameObjects.ForEach(gameObject => gameObject.Enable());
        // }
        //
        // public void Disable()
        // {
        //     _gameObjects.ForEach(gameObject => gameObject.Disable());
        // }

        public void Destroy()
        {
            IsActive = false;
            _gameObjects.ForEach(gameObject => gameObject.Destroy());
        }
        
        public void Add(IGameObject instance) => _gameObjects.Add(instance);

        public void Remove(IGameObject instance) => _gameObjects.Remove(instance);

        public void Update(float deltaTime)
        {
            foreach (var gameObject in _gameObjects)
            {
                if (gameObject.IsActive)
                    gameObject.Update(deltaTime);
            }
        }
    }
}