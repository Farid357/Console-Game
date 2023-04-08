using System.Collections.Generic;

namespace ConsoleGame.Physics
{
    public sealed class CollidersWorld<TModel> : ICollidersWorld<TModel>
    {
        private readonly Dictionary<LayerMask, Dictionary<TModel, ICollider>> _colliders;

        public CollidersWorld()
        {
            _colliders = new Dictionary<LayerMask, Dictionary<TModel, ICollider>>();
        }

        public void Add(TModel model, ICollider collider, LayerMask layerMask)
        {
            if (_colliders.ContainsKey(layerMask))
            {
                _colliders[layerMask].Add(model, collider);
            }

            else
            {
                _colliders.Add(layerMask, new Dictionary<TModel, ICollider>
                {
                    { model, collider }
                });
            }
        }

        public void Remove(TModel model, LayerMask layerMask)
        {
            _colliders[layerMask].Remove(model);
        }

        public IReadOnlyDictionary<TModel, ICollider> Colliders(LayerMask layerMask)
        {
            return _colliders[layerMask];
        }
    }
}