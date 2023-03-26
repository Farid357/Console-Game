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

        public bool IsActive => _gameObjectsGroup.IsActive;

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
            CleanNotActiveObjects();
        }

        private void CleanNotActiveObjects()
        {
            foreach (var gameObject in _gameObjects)
            {
                if (gameObject.IsActive == false)
                    _gameObjectsGroup.Remove(gameObject);
            }
        }
    }
}