using System.Collections.Generic;

namespace ConsoleGame.Physics
{
    public sealed class CollidersWorld<TModel> : ICollidersWorld<TModel>
    {
        private readonly Dictionary<ICollider, TModel> _models;

        public CollidersWorld()
        {
            _models = new Dictionary<ICollider, TModel>();
        }
        
        public IReadOnlyDictionary<ICollider, TModel> Models => _models;

        public void Add(ICollider collider, TModel model)
        {
            _models.Add(collider, model);
        }

        public void Remove(ICollider collider)
        {
            _models.Remove(collider);
        }
    }
}