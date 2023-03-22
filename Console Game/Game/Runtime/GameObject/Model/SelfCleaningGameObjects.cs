using System;
using System.Collections.Generic;

namespace Console_Game
{
    public sealed class SelfCleaningGameObjects : IGameObjects
    {
        private readonly IGameObjects _gameObjects;

        public SelfCleaningGameObjects(IGameObjects gameObjects)
        {
            _gameObjects = gameObjects ?? throw new ArgumentNullException(nameof(gameObjects));
        }
        
        public bool IsActive => _gameObjects.IsActive;

        public IReadOnlyList<IGameObject> All => _gameObjects.All;

        public void Add(IGameObject instance)
        {
            _gameObjects.Add(instance);
        }

        public void Remove(IGameObject instance)
        {
            _gameObjects.Remove(instance);
        }

        public void Update(float deltaTime)
        {
            _gameObjects.Update(deltaTime);
            CleanNotActiveObjects();
        }

        private void CleanNotActiveObjects()
        {
            foreach (var gameObject in All)
            {
                if (gameObject.IsActive == false)
                    _gameObjects.Remove(gameObject);
            }
        }

        public void Destroy()
        {
            _gameObjects.Destroy();
        }
    }
}