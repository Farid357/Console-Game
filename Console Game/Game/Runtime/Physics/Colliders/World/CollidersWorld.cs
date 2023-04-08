using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame.Physics
{
    public sealed class CollidersWorld<TModel> : ICollidersWorld<TModel>
    {
        private readonly Dictionary<LayerMask, Dictionary<TModel, ICollider>> _layerMaskColliders;

        public IReadOnlyDictionary<TModel, ICollider> AllColliders =>
            _layerMaskColliders.Values.SelectMany(value => value)
                .ToDictionary(keyValuePair => keyValuePair.Key, v => v.Value);

        public CollidersWorld()
        {
            _layerMaskColliders = new Dictionary<LayerMask, Dictionary<TModel, ICollider>>();
        }

        public void Add(TModel model, ICollider collider, LayerMask layerMask)
        {
            if (_layerMaskColliders.ContainsKey(layerMask))
            {
                _layerMaskColliders[layerMask].Add(model, collider);
            }

            else
            {
                _layerMaskColliders.Add(layerMask, new Dictionary<TModel, ICollider> { { model, collider } });
            }
        }

        public void Remove(TModel model, LayerMask layerMask)
        {
            _layerMaskColliders[layerMask].Remove(model);
        }

        public IReadOnlyDictionary<TModel, ICollider> Colliders(LayerMask layerMask)
        {
            return _layerMaskColliders[layerMask];
        }
    }
}