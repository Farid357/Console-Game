using System;
using System.Collections.Generic;

namespace ConsoleGame.GameLoop
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

        public void Add(IGameObject gameObject) => _gameObjects.Add(gameObject);

        public void Remove(IGameObject gameObject) => _gameObjects.Remove(gameObject);

        public void Update(float deltaTime)
        {
            foreach (var gameObject in _gameObjects)
            {
                if (gameObject.IsAlive)
                    gameObject.Update(deltaTime);
            }
        }
    }
}