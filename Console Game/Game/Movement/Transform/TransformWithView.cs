using System;
using System.Numerics;

namespace Console_Game
{
    public sealed class TransformWithView : ITransform, ITransformWithView
    {
        private readonly ITransform _transform;
        private readonly ITransformView _transformView;

        public TransformWithView(ITransform transform, ITransformView transformView)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _transformView = transformView ?? throw new ArgumentNullException(nameof(transformView));
        }

        public Vector2 Position => _transform.Position;

        public Quaternion Rotation => _transform.Rotation;

        public void Teleport(Vector2 position)
        {
            _transform.Teleport(position);
            _transformView.Teleport(position);
        }

        public void Rotate(Quaternion rotation)
        {
            _transform.Rotate(rotation);
            _transformView.Rotate(rotation);
        }

        public void Enable()
        {
            _transformView.Teleport(Position);
            _transformView.Rotate(_transform.Rotation);
        }
    }
}