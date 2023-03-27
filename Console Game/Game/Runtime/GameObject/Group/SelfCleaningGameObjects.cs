using System;
using System.Collections.Generic;

namespace ConsoleGame.Loop
{
    public sealed class SelfCleaningGameObjects : IGameObjects
    {
        private readonly IGameObjects _gameObjectsGroup;
        private readonly List<IGameObject> _gameObjects;

        public SelfCleaningGameObjects(IGameObjects gameObjects)
        {
            _gameObjectsGroup = gameObjects ?? throw new ArgumentNullException(nameof(gameObjects));
            _gameObjects = new List<IGameObject>();
        }

        public bool IsAlive => _gameObjectsGroup.IsAlive;

        public void Add(IGameObject gameObject)
        {
            _gameObjectsGroup.Add(gameObject);
            _gameObjects.Add(gameObject);
        }

        public void Remove(IGameObject gameObject)
        {
            _gameObjectsGroup.Remove(gameObject);
            _gameObjects.Remove(gameObject);
        }

        public void Update(float deltaTime)
        {
            _gameObjectsGroup.Update(deltaTime);
            CleanNotAliveObjects();
        }

        private void CleanNotAliveObjects()
        {
            foreach (var gameObject in _gameObjects)
            {
                if (gameObject.IsAlive == false)
                    _gameObjectsGroup.Remove(gameObject);
            }
        }
    }
}