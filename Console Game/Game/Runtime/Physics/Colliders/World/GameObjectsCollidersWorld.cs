using System;
using System.Collections.Generic;

namespace ConsoleGame.Physics
{
    public sealed class GameObjectsCollidersWorld<TModel> : IGameLoopObject, ICollidersWorld<TModel> where TModel : IGameObject
    {
        private readonly ICollidersWorld<TModel> _world;

        public GameObjectsCollidersWorld(ICollidersWorld<TModel> world)
        {
            _world = world ?? throw new ArgumentNullException(nameof(world));
        }

        public IReadOnlyDictionary<ICollider, TModel> Models => _world.Models;

        public void Add(ICollider collider, TModel model) => _world.Add(collider, model);

        public void Remove(ICollider collider) => _world.Remove(collider);

        public void Update(float deltaTime)
        {
            foreach (var keyPair in _world.Models)
            {
                ICollider collider = keyPair.Key;
                IGameObject gameObject = keyPair.Value;

                if (gameObject.IsActive == false)
                    Remove(collider);
            }
        }
    }
}