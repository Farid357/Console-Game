using System;
using System.Numerics;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class SmoothMovement : IMovement, IGameLoopObject
    {
        private readonly ITransform _transform;
        private readonly float _rotateSpeed;
        private readonly float _moveSpeed;
        private float _deltaTime;

        public SmoothMovement(float moveSpeed, float rotateSpeed, ITransform transform)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _moveSpeed = moveSpeed.ThrowIfLessOrEqualsToZeroException();
            _rotateSpeed = rotateSpeed.ThrowIfLessOrEqualsToZeroException();
        }
        
        public IReadOnlyTransform Transform => _transform;

        public void Update(float deltaTime) => _deltaTime = deltaTime;

        public void Move(Vector2 direction)
        {
            var currentPosition = _transform.Position;
            var nextPosition = Vector2.Lerp(currentPosition, currentPosition + direction * _moveSpeed * _deltaTime, 0.1f);
            _transform.Teleport(nextPosition);
        }

        public void Rotate(Quaternion rotation)
        {
            var currentRotation = _transform.Rotation;
            var nextRotation = Quaternion.Lerp(currentRotation, rotation,  _rotateSpeed * _deltaTime);
            _transform.Rotate(nextRotation);
        }
    }
}