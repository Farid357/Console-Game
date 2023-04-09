using System;
using System.Collections.Generic;
using ConsoleGame.Tools;

namespace ConsoleGame.Physics
{
    public sealed class GameObjectsCollidersWorld<TModel> : IGameObjectsCollidersWorld<TModel> where TModel : IReadOnlyGameObject
    {
        private readonly ICollidersWorld<TModel> _collidersWorld;

        public GameObjectsCollidersWorld(ICollidersWorld<TModel> collidersWorld)
        {
            _collidersWorld = collidersWorld ?? throw new ArgumentNullException(nameof(collidersWorld));
        }

        public GameObjectsCollidersWorld() : this(new CollidersWorld<TModel>())
        {
        }

        public IReadOnlyDictionary<TModel, ICollider> AllColliders => _collidersWorld.AllColliders;

        public IReadOnlyDictionary<TModel, ICollider> Colliders(Layer layer)
        {
            return _collidersWorld.Colliders(layer);
        }

        public void Add(TModel model, ICollider collider, Layer layer = Layer.Default)
        {
            _collidersWorld.Add(model, collider, layer);
        }

        public void Remove(TModel model)
        {
            _collidersWorld.Remove(model);
        }

        public void Update(float deltaTime)
        {
            foreach (var collider in _collidersWorld.AllColliders)
            {
                TModel gameObject = collider.Key;
                
                if(gameObject.IsDied())
                    _collidersWorld.Remove(gameObject);
            }
        }
    }
}