using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame.Physics
{
    public sealed class CollidersWorld<TModel> : ICollidersWorld<TModel>
    {
        private readonly Dictionary<Layer, Dictionary<TModel, ICollider>> _layersColliders;

        public CollidersWorld()
        {
            _layersColliders = new Dictionary<Layer, Dictionary<TModel, ICollider>>();
        }

        public IReadOnlyDictionary<TModel, ICollider> AllColliders =>
            _layersColliders.Values.SelectMany(value => value)
                .ToDictionary(keyValuePair => keyValuePair.Key, v => v.Value);

        public void Add(TModel model, ICollider collider, Layer layer)
        {
            if (_layersColliders.ContainsKey(layer))
            {
                _layersColliders[layer].Add(model, collider);
            }

            else
            {
                _layersColliders.Add(layer, new Dictionary<TModel, ICollider> { { model, collider } });
            }
        }

        public void Remove(TModel model)
        {
            var layersWithModel = _layersColliders.ToList().FindAll(collider => collider.Value.ContainsKey(model));

            foreach (var layer in layersWithModel)
            {
                _layersColliders[layer.Key].Remove(model);
            }
        }

        public IReadOnlyDictionary<TModel, ICollider> Colliders(Layer layer)
        {
            return _layersColliders[layer];
        }
    }
}