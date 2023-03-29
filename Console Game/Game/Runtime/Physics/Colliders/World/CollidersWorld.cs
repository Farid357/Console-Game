using System.Collections.Generic;

namespace ConsoleGame.Physics
{
    public sealed class CollidersWorld<TModel> : ICollidersWorld<TModel>
    {
        private readonly Dictionary<TModel, ICollider> _colliders;

        public CollidersWorld()
        {
            _colliders = new Dictionary<TModel, ICollider>();
        }
        
        public IReadOnlyDictionary<TModel, ICollider> Colliders => _colliders;

        public void Add(TModel model, ICollider collider)
        {
            _colliders.Add(model, collider);
        }

        public void Remove(TModel model)
        {
            _colliders.Remove(model);
        }
    }
}