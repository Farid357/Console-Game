using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class SmoothMovement : IMovement, IGameLoopObject
    {
        private readonly ITransform _transform;
        private float _deltaTime;

        public SmoothMovement(ITransform transform)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }
        
        public IReadOnlyTransform Transform => _transform;

        public void Update(float deltaTime) => _deltaTime = deltaTime;

        public void Move(Vector3 direction)
        {
            var currentPosition = _transform.Position;
            var nextPosition = Vector3.Lerp(currentPosition, currentPosition + direction * _deltaTime, 0.1f);
            _transform.Teleport(nextPosition);
        }
    }
}