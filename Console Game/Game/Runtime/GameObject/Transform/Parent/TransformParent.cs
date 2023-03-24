using System;
using System.Collections.Generic;
using System.Numerics;

namespace Console_Game
{
    public sealed class TransformParent : ITransformParent
    {
        private readonly List<ITransform> _children;
        private readonly ITransform _transform;

        public TransformParent(List<ITransform> children, ITransform transform)
        {
            _children = children ?? throw new ArgumentNullException(nameof(children));
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public IReadOnlyList<ITransform> Children => _children;

        public Vector2 Position => _transform.Position;

        public Quaternion Rotation => _transform.Rotation;
       
        public void Add(ITransform child) => _children.Add(child);

        public void Remove(ITransform child) => _children.Remove(child);

        public void Teleport(Vector2 position)
        {
            _transform.Teleport(position);

            foreach (var child in _children)
            {
                child.Teleport(child.Position + position);
            }
        }

        public void Rotate(Quaternion rotation)
        {
            _transform.Rotate(rotation);
            
            foreach (var child in _children)
            {
                child.Rotate(child.Rotation + rotation);
            }
        }
    }
}